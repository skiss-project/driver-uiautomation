// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public abstract class ElementAction<T>
        where T : Element<T>
    {
        protected abstract (bool, object) HasCapability(Capability capability);

        private protected void EnsureCapability(Capability capability)
        {
            var (hasCapability, element) = HasCapability(capability);
            if (hasCapability == false)
            {
                throw new MissingCapabilityException(capability, element);
            }
        }
    }
}
