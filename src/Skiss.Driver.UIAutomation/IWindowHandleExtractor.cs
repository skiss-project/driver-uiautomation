// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using System;

    internal interface IWindowHandleExtractor
    {
        IntPtr GetMainWindowHandle(IProcess process);
    }
}
