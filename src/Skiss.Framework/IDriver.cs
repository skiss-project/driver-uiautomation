// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public interface IDriver
    {
        T Start<T>(string task)
            where T : Element<T>, new();

        TypeAction<T> FindTypable<T>(string identifier)
            where T : Element<T>;

        ClickAction<T> FindClickable<T>(string identifier)
            where T : Element<T>;

        ReadAction<T> FindReadable<T>(string identifier)
            where T : Element<T>;

        void Stop();
    }
}
