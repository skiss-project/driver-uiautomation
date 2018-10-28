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

namespace Skiss.Driver.UIAutomation
{
    using System;
    using System.Windows.Automation;

    internal class AutomationElementProxy : IAutomationElement
    {
        private static readonly AutomationElementProxy RootProxy = new AutomationElementProxy();

        private readonly AutomationElement element;

        public AutomationElementProxy()
            : this(AutomationElement.RootElement)
        {
        }

        public AutomationElementProxy(AutomationElement element)
        {
            Guard.AgainstNull(element, nameof(element));
            this.element = element;
        }

        public AutomationElement.AutomationElementInformation Current
            => element.Current;

        public IAutomationElement RootElement
            => RootProxy;

        public IAutomationElementCollection FindAll(TreeScope scope, Condition condition)
            => new AutomationElementProxyCollection(element.FindAll(scope, condition));

        public IAutomationElement FindFirst(TreeScope scope, Condition condition)
            => new AutomationElementProxy(element.FindFirst(scope, condition));

        public IAutomationElement FromHandle(IntPtr hwnd)
            => new AutomationElementProxy(AutomationElement.FromHandle(hwnd));

        public bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject)
            => element.TryGetCurrentPattern(pattern, out patternObject);
    }
}
