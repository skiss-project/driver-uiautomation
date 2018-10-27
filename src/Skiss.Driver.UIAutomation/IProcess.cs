// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using System;

    internal interface IProcess
    {
        IntPtr MainWindowHandle { get; }
    }
}
