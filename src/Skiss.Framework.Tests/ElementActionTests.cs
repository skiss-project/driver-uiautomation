// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Framework.Tests
{
    using System;
    using AutoFixture;
    using FluentAssertions;
    using NUnit.Framework;

    public class ElementActionTests
    {
        private Capability capability;

        private object element;

        private string identifier;

        private ElementActionForTest sut;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();

            capability = fixture.Create<Capability>();
            element = fixture.Create<object>();
            identifier = fixture.Create<string>();

            sut = new ElementActionForTest();
        }

        [Test]
        public void EnsureCapability_GivenIdentifierDoesNotMatchCapability_ThrowsException()
        {
            sut.HasCapabilityReturn = (false, element);

            Action ensuring = () => sut.EnsureCapability(capability);

            var exception = ensuring
                .Should().ThrowExactly<MissingCapabilityException>()
                .And;

            exception.Capability.Should().Be(capability);
            exception.Element.Should().BeSameAs(element);
        }

        [Test]
        public void EnsureCapability_GivenIdentifierMatchesCapability_DoesNotThrowException()
        {
            sut.HasCapabilityReturn = (true, element);

            Action ensuring = () => sut.EnsureCapability(capability);

            ensuring.Should().NotThrow();
        }

        private class ElementActionForTest : ElementAction<CommonTestElement>
        {
            public (bool, object) HasCapabilityReturn { get; set; }

            public new void EnsureCapability(Capability capability)
                => base.EnsureCapability(capability);

            protected override (bool, object) HasCapability(Capability capability)
                => HasCapabilityReturn;
        }
    }
}
