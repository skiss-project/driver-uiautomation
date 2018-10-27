// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public abstract class TypeAction<T> : ElementAction<T>
        where T : Element<T>
    {
        private readonly T continuation;

        public TypeAction(T continuation)
        {
            Guard.AgainstNull(continuation, nameof(continuation));
            this.continuation = continuation;
        }

        public T Type(string text)
        {
            Guard.AgainstNull(text, nameof(text));
            EnsureCapability(Capability.Typable);
            PerformType(text);
            return continuation;
        }

        protected abstract void PerformType(string text);
    }
}
