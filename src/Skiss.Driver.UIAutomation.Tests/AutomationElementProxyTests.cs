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
