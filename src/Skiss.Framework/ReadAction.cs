// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public abstract class ReadAction<T> : ElementAction<T>
        where T : Element<T>
    {
        public ReadAction()
        {
        }

        public string Text
        {
            get
            {
                EnsureCapability(Capability.Readable);
                return GetText();
            }
        }

        protected abstract string GetText();
    }
}
