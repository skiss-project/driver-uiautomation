// Skiss - A .NET framework for simple, kind of interactive, system specs
// Copyright (C) 2018  Simon Wendel
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
            getting.Should().ThrowExactly<ArgumentNullException>()
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
