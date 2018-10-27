// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public abstract class ClickAction<T> : ElementAction<T>
        where T : Element<T>
    {
        private readonly T continuation;

        public ClickAction(T continuation)
        {
            Guard.AgainstNull(continuation, nameof(continuation));
            this.continuation = continuation;
        }

        public T Click()
        {
            EnsureCapability(Capability.Clickable);
            PerformClick();
            return continuation;
        }

        protected abstract void PerformClick();
    }
}
