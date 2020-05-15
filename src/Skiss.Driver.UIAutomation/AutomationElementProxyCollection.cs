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
    using System.Collections;
    using System.Linq;
    using System.Windows.Automation;
    using GuardStatements;

    internal class AutomationElementProxyCollection : IAutomationElementCollection
    {
        private IList elements;

        public AutomationElementProxyCollection(AutomationElementCollection elements)
        {
            Guard.AgainstNull(elements, nameof(elements));

            SyncRoot = new object();

            this.elements = elements
                .Cast<AutomationElement>()
                .Select(e => new AutomationElementProxy(e))
                .ToList<IAutomationElement>();
        }

        public int Count
            => elements.Count;

        public bool IsSynchronized
            => false;

        // property does not return "this" as the original does
        public object SyncRoot { get; }

        public IAutomationElement this[int index]
            => elements[index] as IAutomationElement;

        public void CopyTo(IAutomationElement[] dest, int index)
            => elements.CopyTo(dest, index);

        public void CopyTo(Array dest, int index)
            => elements.CopyTo(dest, index);

        public IEnumerator GetEnumerator()
            => elements.GetEnumerator();
    }
}
