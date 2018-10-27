// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using System;
    using System.Windows.Automation;

    internal interface IAutomationElement
    {
        AutomationElement.AutomationElementInformation Current { get; }

        IAutomationElement RootElement { get; }

        IAutomationElementCollection FindAll(TreeScope scope, Condition condition);

        IAutomationElement FindFirst(TreeScope scope, Condition condition);

        IAutomationElement FromHandle(IntPtr hwnd);

        bool TryGetCurrentPattern(AutomationPattern pattern, out object patternObject);
    }
}
