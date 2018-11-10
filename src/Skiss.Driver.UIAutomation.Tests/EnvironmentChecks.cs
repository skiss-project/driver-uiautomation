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
    using System.Windows.Automation;
    using FluentAssertions;
    using NUnit.Framework;

    public class EnvironmentChecks
    {
        [Test]
        [Category("EnvironmentCheck")]
        public void WindowsDesktop_GivenThatDesktopStuffIsAvailable_ExposesTrayWnd()
        {
            /*
                This is to see if we can find the main hwnd of something to use in tests on CI builds.
                If this fails, we have a hard time to test stuff around System.Diagnostics.Process and
                their MainWindowHandle values.
             */
            var pid = AutomationElement.RootElement.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ClassNameProperty, "Shell_TrayWnd")).Current.ProcessId;

            Process.GetProcessById(pid).MainWindowHandle.Should().NotBe(IntPtr.Zero);
        }
    }
}
