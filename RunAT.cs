using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace RunMyDLL
{
    public partial class RunAT : Form
    {
        private string ProjectRootPath = null;

        private string XunitConsolePath = null;

        private string XunitCommand = null;        

        private List<string> ProjectNames = new List<string>();

        Process process;

        /// <summary>
        /// Initializes a new instance of the <see cref="RunAT"/> class.
        /// </summary>
        public RunAT()
        {
            InitializeComponent();
            ATConfigurations.CommonXunitConsolePath = (string)ConfigurationManager.AppSettings["CommonXunitConsolePath"];
            ATConfigurations.CommonDLLPath = (string)ConfigurationManager.AppSettings["CommonDLLPath"];
            ATConfigurations.ProjectNamePrepender = (string)ConfigurationManager.AppSettings["ProjectNamePrepender"];
            ATConfigurations.XunitCommand = (string)ConfigurationManager.AppSettings["XunitCommand"];
            ATConfigurations.HTMLTag = (string)ConfigurationManager.AppSettings["HTMLTag"];
            ATConfigurations.XMLTag = (string)ConfigurationManager.AppSettings["XMLTag"];
            ATConfigurations.AutomationPrepender = (string)ConfigurationManager.AppSettings["AutomationPrepender"];

            // Making the textbox undeditable by default
            ResultTextBox.ReadOnly = true;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the The ChooseROOTFolderButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ChooseROOTButton_Click(object sender, EventArgs e)
        {
            if (ROOTFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ProjectRootPath = ROOTFolderBrowserDialog.SelectedPath;
                this.RootFolderLabel.Text = ProjectRootPath;
                XunitConsolePath = ProjectRootPath + ATConfigurations.CommonXunitConsolePath;
            }
        }

        /// <summary>
        /// Handles the Click event of the RunButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            List<string> selectedProjects = new List<string>();
            selectedProjects = this.GetTheSelectedProjects();
            List<string> selectedReportTypes = new List<string>();
            selectedReportTypes = this.GetTheSlectedReportType();
            if (ProjectRootPath == null)
            {
                MessageBox.Show("Select your solution root folder!", "Sorry", MessageBoxButtons.OK);
            }
            else if (selectedProjects.Count == 0)
            {
                MessageBox.Show("Select atleast 1 project to run!", "Sorry", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrEmpty(FileNameTextBox.Text))
            {
                MessageBox.Show("Please provide a filename for the report!", "Sorry", MessageBoxButtons.OK);
            }
            else if (selectedReportTypes.Count == 0)
            {
                MessageBox.Show("Select a file type for the report!", "Sorry", MessageBoxButtons.OK);
            }
            else
            {
                if (FileNameTextBox.Text.Contains('.'))
                {
                    MessageBox.Show("Please renter the filename without extension or charcters like '.'!", "Sorry", MessageBoxButtons.OK);
                }
                else
                {
                    string rootFolderName = ATConfigurations.AutomationPrepender;
                    List<string> projects = new List<string>();
                    projects = this.GetTheProjectNames(selectedProjects, rootFolderName);
                    string reportFileName = FileNameTextBox.Text;
                    XunitCommand = this.XunitCommandMaker(projects, reportFileName, selectedReportTypes);
                    try
                    {
                        if (XunitCommand != null)
                        {
                            string xunitConsolePath = ProjectRootPath + ATConfigurations.CommonXunitConsolePath + "\\";
                            process = new Process();
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.Arguments = "/C" + xunitConsolePath + XunitCommand;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.Verb = "runas";
                            process.OutputDataReceived += proc_DataReceived;
                            process.Start();
                            process.BeginOutputReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the DataReceived event of the proc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataReceivedEventArgs"/> instance containing the event data.</param>
        private void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            ResultTextBox.BeginInvoke(new Action(() => 
                                     {                                        
                                         ResultTextBox.Text = ResultTextBox.Text + "\n" + e.Data;
                                     }));
        }


        /// <summary>
        /// Gets the selected projects.
        /// </summary>
        /// <returns>The list of selected projects</returns>
        private List<string> GetTheSelectedProjects()
        {
            List<string> selectedProjects = new List<string>();
            foreach (string item in ProjectsCheckListBox.CheckedItems)
            {
                selectedProjects.Add(item);
            }

            return selectedProjects;
        }

        /// <summary>
        /// Gets the type of the slected report.
        /// </summary>
        /// <returns></returns>
        private List<string> GetTheSlectedReportType()
        {
            List<string> selectedType = new List<string>();
            foreach (string item in ReportTypeListBox.CheckedItems)
            {
                selectedType.Add(item);
            }

            return selectedType;
        }

        /// <summary>
        /// Gets the project names.
        /// </summary>
        /// <param name="projects">The projects.</param>
        /// <param name="rootFolderName">Name of the root folder.</param>
        /// <returns>the complete name of the project</returns>
        private List<string> GetTheProjectNames(List<string> projects, string rootFolderName)
        {
            List<string> projectNames = new List<string>();
            foreach (string project in projects)
            {
                projectNames.Add(rootFolderName + ATConfigurations.ProjectNamePrepender + project.ToString());
            }

            return projectNames;
        }

        /// <summary>
        /// Xunits the command maker.
        /// </summary>
        /// <param name="projects">The projects.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="reportTypes">The report types.</param>
        /// <returns>The xunit command</returns>
        private string XunitCommandMaker(List<string> projects, string fileName, List<string> reportTypes)
        {
            string xunitCommand = ATConfigurations.XunitCommand;
            foreach (string project in projects)
            {
                xunitCommand = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", xunitCommand, " ", ProjectRootPath, "\\", project, ATConfigurations.CommonDLLPath, project, ".dll");
            }

            foreach (string reportType in reportTypes)
            {
                if (reportType == "HTML")
                {
                    xunitCommand = xunitCommand + " " + ATConfigurations.HTMLTag + " " + fileName + ".html";
                }
                else
                {
                    xunitCommand = xunitCommand + " " + ATConfigurations.XMLTag + " " + fileName + ".xml";
                }
            }

            return xunitCommand;
        }

        /// <summary>
        /// On closing the form
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Closing event</param>
        private void RunAT_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (process != null)
            {
                var process = Process.GetProcessesByName("xunit.console");
                if (process.Length > 0)
                {
                    process[0].Kill();
                    Thread killerThread = new Thread(() => this.KillAllProcessesSpawnedBy(process[0].Id));
                    killerThread.Start();
                }
            }
        }

        /// <summary>
        /// Killing all child process of the parent
        /// </summary>
        /// <param name="parentProcessId">The parent process ID</param>
        private  void KillAllProcessesSpawnedBy(int parentProcessId)
        {
            String myQuery = string.Format("select * from win32_process where ParentProcessId={0}", parentProcessId);
            ObjectQuery objQuery = new ObjectQuery(myQuery);
            ManagementObjectSearcher objSearcher = new ManagementObjectSearcher(objQuery);
            ManagementObjectCollection processList = objSearcher.Get();

            foreach (ManagementObject item in processList)
            {
                try
                {
                    int processId = Convert.ToInt32(item["ProcessId"].ToString());
                    if (processId > 0)
                    {
                        this.KillAllProcessesSpawnedBy(processId);
                        Process.GetProcessById(processId).Kill();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }            
        }
    }
}
