// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using Skiss.Framework;

    public class UIAutomationDriver : IDriver
    {
        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public ClickAction<T> FindClickable<T>(string identifier)
            where T : Element<T>
        {
            throw new System.NotImplementedException();
        }

        public ReadAction<T> FindReadable<T>(string identifier)
            where T : Element<T>
        {
            throw new System.NotImplementedException();
        }

        public TypeAction<T> FindTypable<T>(string identifier)
            where T : Element<T>
        {
            throw new System.NotImplementedException();
        }

        public T Start<T>(string task)
            where T : Element<T>, new()
        {
            throw new System.NotImplementedException();
        }
    }
}
