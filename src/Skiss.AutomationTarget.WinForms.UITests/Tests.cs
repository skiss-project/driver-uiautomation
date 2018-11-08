// Skiss - A .NET framework for simple, kind of interactive, system specs
// Copyright (C) 2018  Simon Wendel
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
        public void WinFormsTarget_GivenExecutable_ShouldStartAndKill()
        {
            Assignment<CalculatorWindow>
                .Start("Skiss.AutomationTarget.WinForms.exe")
                .Kill();
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
