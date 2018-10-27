// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    using System;

    public class MissingCapabilityException : Exception
    {
        public MissingCapabilityException(Capability capability, object element)
        {
            Capability = capability;
            Element = element;
        }

        public Capability Capability { get; }

        public object Element { get; }
    }
}
