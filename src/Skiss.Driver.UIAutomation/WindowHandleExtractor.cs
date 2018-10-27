// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation
{
    using System;
    using Polly;

    internal class WindowHandleExtractor : IWindowHandleExtractor
    {
        private const int NumberOfRetries = 9;

        private static readonly IntPtr IllegalHandle = IntPtr.Zero;

        private readonly Policy<IntPtr> policy;

        public WindowHandleExtractor()
        {
            var retry = Policy
                .HandleResult(IllegalHandle)
                .WaitAndRetry(NumberOfRetries, ExponentialBackoff);

            var fallback = Policy
                .HandleResult(IllegalHandle)
                .Fallback(ReportThisAsFailure);

            policy = fallback.Wrap(retry);
        }

        public IntPtr GetMainWindowHandle(IProcess process)
        {
            Guard.AgainstNull(process, nameof(process));
            return policy.Execute(() => process.MainWindowHandle);
        }

        private TimeSpan ExponentialBackoff(int attempt)
            => TimeSpan.FromMilliseconds(Math.Pow(2, attempt));

        private IntPtr ReportThisAsFailure()
            => throw new InvalidOperationException();
    }
}
