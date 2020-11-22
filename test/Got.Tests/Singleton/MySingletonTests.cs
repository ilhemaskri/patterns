using GoF.Singleton;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace Got.Tests.Singleton
{
    [TestFixture]
    public class MySingletonTests
    {
        [Test]
        public void MySingleton_When2TimesCalled_OnlyOneInstanceExists()
        {
            var s1 = MySingleton.GetInstance();
            var s2 = MySingleton.GetInstance();

            s1.Should().BeSameAs(s2);
        }
    }
}
