// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.AutomationTarget.WinForms
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AwesomeCalculatorForm());
        }
    }
}
