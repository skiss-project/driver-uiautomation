// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.AutomationTarget.WinForms.UITests
{
    using Skiss.Framework;

    internal class CalculatorWindow : Element<CalculatorWindow>
    {
        public TypeAction<CalculatorWindow> Operand1 => FindTypable("firstOperand");

        public TypeAction<CalculatorWindow> Operand2 => FindTypable("secondOperand");

        public ClickAction<CalculatorWindow> Button => FindClickable("invoke");

        public ReadAction<CalculatorWindow> Result => FindReadable("results");
    }
}
