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

namespace Skiss.Driver.UIAutomation.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Automation;
    using FluentAssertions;
    using NUnit.Framework;

    public class ProcessProxyTests
    {
        [Test]
        public void Constructor_GivenNullProcess_ThrowsException()
        {
            Action constructing = () => new ProcessProxy(null);

            constructing
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("process");
        }

        [Test]
        public void MainWindowHandleGetter_GivenProcess_ReturnsMainWindowHandle()
        {
            var process = GetTrayProcess();
            var sut = new ProcessProxy(process);
            sut.MainWindowHandle.Should().Be(process.MainWindowHandle);
        }

        private static Process GetTrayProcess()
        {
            // ugly but repeatable way of getting a process with a main window handle
            var tray = AutomationElement.RootElement.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ClassNameProperty, "Shell_TrayWnd"));

            var processId = tray.Current.ProcessId;
            return Process.GetProcessById(processId);
        }
    }
}
