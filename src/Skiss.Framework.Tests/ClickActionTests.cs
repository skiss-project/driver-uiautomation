// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class ClickActionTests
    {
        private object element;

        private CommonTestElement continuation;

        private ClickActionForTest sut;

        [SetUp]
        public void Setup()
        {
            element = new object();
            continuation = new CommonTestElement();
            sut = new ClickActionForTest(continuation);
        }

        [Test]
        public void Constructor_GivenNullContinuation_ThrowsException()
        {
            Action constructing = () => new ClickActionForTest(null);

            constructing
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("continuation");
        }

        [Test]
        public void Click_GivenCapabilityNotProvided_ThrowsException()
        {
            sut.HasCapabilityReturn = (false, element);

            Action clicking = () => sut.Click();

            var exception = clicking.Should().ThrowExactly<MissingCapabilityException>().And;
            exception.Capability.Should().Be(Capability.Clickable);
            exception.Element.Should().Be(element);
        }

        [Test]
        public void Click_GivenCapabilityProvided_CallsPerformClickOnSubClass()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Click();
            sut.ClickPerformed.Should().BeTrue();
        }

        [Test]
        public void Click_GivenContinuationProvided_ReturnsContinuation()
        {
            sut.HasCapabilityReturn = (true, element);
            sut.Click().Should().BeSameAs(continuation);
        }

        private class ClickActionForTest : ClickAction<CommonTestElement>
        {
            public ClickActionForTest(CommonTestElement continuation)
                : base(continuation)
            {
            }

            public bool ClickPerformed { get; private set; }

            public (bool, object) HasCapabilityReturn { get; set; }

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;

            protected override void PerformClick()
                => ClickPerformed = true;
        }
    }
}
