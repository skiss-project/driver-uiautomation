// Copyright (c) Simon Wendel. All rights reserved.

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
