// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.AutomationTarget.WinForms
{
    using System;
    using System.Windows.Forms;

    public partial class AwesomeCalculatorForm : Form
    {
        public AwesomeCalculatorForm()
        {
            InitializeComponent();
        }

        private void InvokeClick(object sender, EventArgs e)
        {
            results.Text = (int.Parse(firstOperand.Text) + int.Parse(secondOperand.Text)).ToString();
        }
    }
}
