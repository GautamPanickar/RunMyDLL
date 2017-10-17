namespace RunMyDLL
{
    partial class RunAT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RunButton = new System.Windows.Forms.Button();
            this.ChooseROOTButton = new System.Windows.Forms.Button();
            this.RootFolderLabel = new System.Windows.Forms.Label();
            this.ROOTFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ProjectsCheckListBox = new System.Windows.Forms.CheckedListBox();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.GenerateLabel = new System.Windows.Forms.Label();
            this.ReportTypeListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // RunButton
            // 
            this.RunButton.BackColor = System.Drawing.Color.Green;
            this.RunButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RunButton.Location = new System.Drawing.Point(311, 242);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(118, 43);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "RUN";
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // ChooseROOTButton
            // 
            this.ChooseROOTButton.BackColor = System.Drawing.Color.Goldenrod;
            this.ChooseROOTButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChooseROOTButton.Location = new System.Drawing.Point(311, 38);
            this.ChooseROOTButton.Name = "ChooseROOTButton";
            this.ChooseROOTButton.Size = new System.Drawing.Size(117, 46);
            this.ChooseROOTButton.TabIndex = 14;
            this.ChooseROOTButton.Text = "Choose ROOT folder";
            this.ChooseROOTButton.UseVisualStyleBackColor = false;
            this.ChooseROOTButton.Click += new System.EventHandler(this.ChooseROOTButton_Click);
            // 
            // RootFolderLabel
            // 
            this.RootFolderLabel.AutoSize = true;
            this.RootFolderLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.RootFolderLabel.Location = new System.Drawing.Point(308, 12);
            this.RootFolderLabel.Name = "RootFolderLabel";
            this.RootFolderLabel.Size = new System.Drawing.Size(56, 13);
            this.RootFolderLabel.TabIndex = 15;
            this.RootFolderLabel.Text = "RootLabel";
            this.RootFolderLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // ProjectsCheckListBox
            // 
            this.ProjectsCheckListBox.AllowDrop = true;
            this.ProjectsCheckListBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ProjectsCheckListBox.CheckOnClick = true;
            this.ProjectsCheckListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectsCheckListBox.FormattingEnabled = true;
            this.ProjectsCheckListBox.Items.AddRange(new object[] {
            "Annotation",
            "Authentication",
            "DataValidation",
            "Exception",
            "MarksEntry",
            "Message",
            "QigSelection",
            "ResponseAllocation",
            "ResponseNavigation",
            "ResponseScreenAbilities",
            "ResponseSubmission",
            "TeamManagement",
            "TranslationPackage",
            "UserOptions"});
            this.ProjectsCheckListBox.Location = new System.Drawing.Point(12, 12);
            this.ProjectsCheckListBox.Name = "ProjectsCheckListBox";
            this.ProjectsCheckListBox.Size = new System.Drawing.Size(211, 274);
            this.ProjectsCheckListBox.TabIndex = 16;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.Color.Teal;
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ResultTextBox.Location = new System.Drawing.Point(0, 302);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(529, 339);
            this.ResultTextBox.TabIndex = 18;
            this.ResultTextBox.Text = "";
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Location = new System.Drawing.Point(308, 104);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(186, 13);
            this.FilenameLabel.TabIndex = 19;
            this.FilenameLabel.Text = "Provide a filename to save the report..";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(311, 130);
            this.FileNameTextBox.Multiline = true;
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(117, 32);
            this.FileNameTextBox.TabIndex = 20;
            // 
            // GenerateLabel
            // 
            this.GenerateLabel.AutoSize = true;
            this.GenerateLabel.Location = new System.Drawing.Point(308, 173);
            this.GenerateLabel.Name = "GenerateLabel";
            this.GenerateLabel.Size = new System.Drawing.Size(51, 13);
            this.GenerateLabel.TabIndex = 22;
            this.GenerateLabel.Text = "Generate";
            // 
            // ReportTypeListBox
            // 
            this.ReportTypeListBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ReportTypeListBox.CheckOnClick = true;
            this.ReportTypeListBox.FormattingEnabled = true;
            this.ReportTypeListBox.Items.AddRange(new object[] {
            "HTML",
            "XML"});
            this.ReportTypeListBox.Location = new System.Drawing.Point(311, 189);
            this.ReportTypeListBox.Name = "ReportTypeListBox";
            this.ReportTypeListBox.Size = new System.Drawing.Size(120, 34);
            this.ReportTypeListBox.TabIndex = 23;
            // 
            // RunAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 641);
            this.Controls.Add(this.ReportTypeListBox);
            this.Controls.Add(this.GenerateLabel);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ProjectsCheckListBox);
            this.Controls.Add(this.RootFolderLabel);
            this.Controls.Add(this.ChooseROOTButton);
            this.Controls.Add(this.RunButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RunAT";
            this.Text = "RunAT 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RunAT_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button ChooseROOTButton;
        private System.Windows.Forms.Label RootFolderLabel;
        private System.Windows.Forms.FolderBrowserDialog ROOTFolderBrowserDialog;
        private System.Windows.Forms.CheckedListBox ProjectsCheckListBox;
        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label GenerateLabel;
        private System.Windows.Forms.CheckedListBox ReportTypeListBox;
    }
}

