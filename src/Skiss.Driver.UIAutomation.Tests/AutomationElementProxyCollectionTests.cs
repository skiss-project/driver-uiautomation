// Copyright (c) Simon Wendel. All rights reserved.

namespace Skiss.Driver.UIAutomation.Tests
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Windows.Automation;
    using FluentAssertions;
    using NUnit.Framework;

    internal class AutomationElementProxyCollectionTests
    {
        private AutomationElementCollection elements;

        private AutomationElementProxyCollection sut;

        [SetUp]
        public void Setup()
        {
            elements = AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            sut = new AutomationElementProxyCollection(elements);
        }

        [Test]
        public void Constructor_GivenNullElementCollection_ThrowsException()
        {
            Action constructing = () => new AutomationElementProxyCollection(null);

            constructing
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("elements");
        }

        [Test]
        public void Constructor_GivenElementCollection_InitializesProxyCollection()
        {
            CompareCollections(sut, elements);
        }

        [Test]
        public void Indexer_GivenIndex_ReturnsElement()
        {
            for (int index = 0; index < elements.Count; ++index)
            {
                var expected = elements[index];
                var expectedId = expected.Current.AutomationId + expected.Current.ProcessId;

                var proxy = sut[index];
                var proxyId = proxy.Current.AutomationId + proxy.Current.ProcessId;

                proxyId.Should().Be(expectedId);
            }
        }

        [Test]
        public void IsSynchronizedGetter_Always_ReturnsFalse()
        {
            sut.IsSynchronized.Should().BeFalse();
        }

        [Test]
        public void SyncRootGetter_Always_ReturnsOtherInstanceThanSut()
        {
            sut.SyncRoot.Should().NotBeNull();
            sut.SyncRoot.Should().NotBeSameAs(sut);
        }

        [Test]
        public void CopyTo_GivenNullArrayInstace_ThrowsException()
        {
            Action copying = () => sut.CopyTo((Array)null, 0);

            copying
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("dest");
        }

        [Test]
        public void CopyTo_GivenArrayInstance_CopiesElementProxiesToArray()
        {
            var array = Array.CreateInstance(typeof(IAutomationElement), sut.Count);
            sut.CopyTo(array, 0);
            CompareCollections(array, elements);
        }

        [Test]
        public void CopyTo_GivenNullElementArray_ThrowsException()
        {
            Action copying = () => sut.CopyTo((IAutomationElement[])null, 0);

            copying
                .Should().ThrowExactly<ArgumentNullException>()
                .Which.ParamName.Should().Be("dest");
        }

        [Test]
        public void CopyTo_GivenElementArray_CopiesElementProxiesToArray()
        {
            var array = new IAutomationElement[elements.Count];
            sut.CopyTo(array, 0);
            CompareCollections(array, elements);
        }

        private void CompareCollections(IEnumerable proxyCollection, IEnumerable elementCollection)
        {
            var proxies = proxyCollection.Cast<IAutomationElement>();
            var elements = elementCollection.Cast<AutomationElement>();

            proxies.Count().Should().Be(elements.Count());

            proxies.Select(p => p.Current.AutomationId + p.Current.ProcessId)
                .Should().BeEquivalentTo(elements.Select(e => e.Current.AutomationId + e.Current.ProcessId));
        }
    }
}
