// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework.Tests
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using Skiss.Framework;

    public class ReadActionTests
    {
        private ReadActionForTest sut;

        [SetUp]
        public void Setup()
        {
            sut = new ReadActionForTest();
        }

        [Test]
        public void TextGetter_GivenCapabilityNotProvided_ThrowsException()
        {
            var element = new object();
            sut.HasCapabilityReturn = (false, element);

            Action getting = () => { var t = sut.Text; };

            var exception = getting.Should().ThrowExactly<MissingCapabilityException>().And;
            exception.Capability.Should().Be(Capability.Readable);
            exception.Element.Should().Be(element);
        }

        [Test]
        public void TextGetter_GivenCapabilityProvided_CallsGetTextOnSubClass()
        {
            sut.HasCapabilityReturn = (true, new object());
            sut.Text.Should().Be("Great success!");
        }

        private class ReadActionForTest : ReadAction<CommonTestElement>
        {
            public (bool, object) HasCapabilityReturn { get; set; }

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;

            protected override string GetText()
            {
                return "Great success!";
            }
        }
    }
}
