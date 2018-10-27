// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation.Tests
{
    using System;
    using System.Windows.Automation;
    using FluentAssertions;
    using NUnit.Framework;

    public class AutomationElementProxyTests
    {
        private AutomationElementProxy sut;

        [SetUp]
        public void Setup()
        {
            sut = new AutomationElementProxy();
        }

        [Test]
        public void Constructor_WhenNullaryInvocation_ConstructsRootProxy()
        {
            var rootInfo = AutomationElement.RootElement.Current;
            var proxiedInfo = sut.Current;

            proxiedInfo.Should().Be(rootInfo);
        }

        [Test]
        public void Constructor_GivenNullElement_ThrowsException()
        {
            Action constructing = () => new AutomationElementProxy(null);

            constructing
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("element");
        }

        [Test]
        public void RootElementGetter_Always_ReturnsRootProxy()
        {
            var rootInfo = AutomationElement.RootElement.Current;
            var proxiedInfo = sut.RootElement.Current;

            proxiedInfo.Should().Be(rootInfo);
        }

        [Test]
        public void FindAll_GivenNullCondition_ThrowsException()
        {
            Action finding = () => sut.FindAll(TreeScope.Subtree, null);

            finding
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("condition");
        }

        [Test]
        public void FindFirst_GivenNullCondition_ThrowsException()
        {
            Action finding = () => sut.FindFirst(TreeScope.Subtree, null);

            finding
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("condition");
        }

        [Test]
        public void TryGetCurrentPattern_GivenNullPattern_ThrowsException()
        {
            Action trying = () => sut.TryGetCurrentPattern(null, out var patternObj);

            trying
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("pattern");
        }
    }
}
