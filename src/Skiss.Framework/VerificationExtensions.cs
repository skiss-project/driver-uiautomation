// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    using System;

    public static class VerificationExtensions
    {
        public static T Now<T>(this T self, Action<T> action)
        {
            Guard.AgainstNull(action, nameof(action));
            action(self);
            return self;
        }
    }
}
