using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunMyDLL
{
    public static class ATConfigurations
    {
        /// <summary>
        /// Gets or sets the common xunit console path.
        /// </summary>
        /// <value>
        /// The common xunit console path.
        /// </value>
        public static string CommonXunitConsolePath { get; set; }

        /// <summary>
        /// Gets or sets the common DLL path.
        /// </summary>
        /// <value>
        /// The common DLL path.
        /// </value>
        public static string CommonDLLPath { get; set; }

        /// <summary>
        /// Gets or sets the project name prepender.
        /// </summary>
        /// <value>
        /// The project name prepender.
        /// </value>
        public static string ProjectNamePrepender { get; set; }

        /// <summary>
        /// Gets or sets the xunit command.
        /// </summary>
        /// <value>
        /// The xunit command.
        /// </value>
        public static string XunitCommand { get; set; }

        /// <summary>
        /// Gets or sets the HTML tag.
        /// </summary>
        /// <value>
        /// The HTML tag.
        /// </value>
        public static string HTMLTag { get; set; }

        /// <summary>
        /// Gets or sets the XML tag.
        /// </summary>
        /// <value>
        /// The XML tag.
        /// </value>
        public static string XMLTag { get; set; }

        /// <summary>
        /// Gets or sets the automation prepender.
        /// </summary>
        /// <value>
        /// The automation prepender.
        /// </value>
        public static string AutomationPrepender { get; set; }
    }
}
