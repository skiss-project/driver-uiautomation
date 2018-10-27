// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using System.Collections;

    internal interface IAutomationElementCollection : ICollection
    {
        IAutomationElement this[int index] { get; }

        void CopyTo(IAutomationElement[] array, int index);
    }
}
