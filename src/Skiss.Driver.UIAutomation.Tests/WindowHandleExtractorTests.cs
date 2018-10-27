// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation.Tests
{
    using System;
    using FluentAssertions;
    using Moq;
    using NUnit.Framework;

    public class WindowHandleExtractorTests
    {
        private Mock<IProcess> process;

        private WindowHandleExtractor sut;

        [SetUp]
        public void Setup()
        {
            process = new Mock<IProcess>();
            sut = new WindowHandleExtractor();
        }

        [Test]
        public void GetMainWindowHandle_GivenNullProcess_ThrowsException()
        {
            Action getting = () => sut.GetMainWindowHandle(null);

            getting
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("process");
        }

        [Test]
        public void GetMainWindowHandle_GivenProcess_RetriesUntilMainWindowHandleCreated(
            [Range(0, 8)]int numberOfFailures)
        {
            var handle = new IntPtr(1337);

            var sequence = process.SetupSequence(p => p.MainWindowHandle);
            for (int fail = 0; fail < numberOfFailures; ++fail)
            {
                sequence.Returns(IntPtr.Zero);
            }

            sequence.Returns(handle);

            sut.GetMainWindowHandle(process.Object).Should().Be(handle);
            process.Verify(p => p.MainWindowHandle, Times.Exactly(numberOfFailures + 1));
        }

        [Test]
        public void GetMainWindowHandle_GivenRetryTenTimes_ThrowsException()
        {
            process.Setup(p => p.MainWindowHandle).Returns(IntPtr.Zero);

            Action getting = () => sut.GetMainWindowHandle(process.Object);

            getting.Should().ThrowExactly<InvalidOperationException>();
            process.Verify(p => p.MainWindowHandle, Times.Exactly(10));
        }
    }
}
