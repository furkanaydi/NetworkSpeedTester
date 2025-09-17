using System;
using System.Windows.Forms;

namespace NetworkSpeedTester
{
    /// <summary>
    /// Entry point for the NetworkSpeedTester application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  STAThread is required for WinForms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize application configuration which handles high DPI settings
            // and default font choices. This is only available on .NET 6+.
            ApplicationConfiguration.Initialize();

            // Start the main form. When the form closes the application exits.
            Application.Run(new MainForm());
        }
    }
}
