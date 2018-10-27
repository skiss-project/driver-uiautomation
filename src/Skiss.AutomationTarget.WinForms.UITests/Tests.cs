// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.AutomationTarget.WinForms.UITests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Driver.UIAutomation;
    using Skiss.Framework;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.Current = new UIAutomationDriver();
        }

        [Test]
        [Ignore("No implementation to back this")]
        public void WinFormsTarget_GivenExecutable_ShouldStartAndStop()
        {
            Assignment<CalculatorWindow>
                .Start("Skiss.AutomationTarget.WinForms.exe")
                .Stop();
        }

        [Test]
        [Ignore("No implementation to back this")]
        public void WinFormsTarget_WhenAddingOneAndTwo_ResultIsThree()
        {
            Assignment<CalculatorWindow>
                .Start("Skiss.AutomationTarget.WinForms.exe")
                .Operand1.Type("1")
                .Operand2.Type("2")
                .Button.Click()
                .Now(x => x.Result.Text.Should().Be("3"))
                .Stop();
        }
    }
}
