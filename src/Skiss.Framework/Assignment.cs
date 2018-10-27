// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework
{
    public static class Assignment<T>
        where T : Element<T>, new()
    {
        public static T Start(string task)
        {
            Guard.AgainstNull(task, nameof(task));
            return DriverManager.Current.Start<T>(task);
        }
    }
}
