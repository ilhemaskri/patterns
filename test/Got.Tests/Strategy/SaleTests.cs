using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Moq;
using GoF.Strategy;

namespace Got.Tests.Strategy
{

    [TestFixture]
    public class SaleTests
    {
        [Test]
        public void PercentageDiscount_WhenInitialAmountIs_100_And_20PercentDiscountProvided_ThenReturn80()
        {
            // Arrange
            var pricingStrategy = new PercentageDiscountStrategy(20);
            var sale = new Sale(100, pricingStrategy);

            // Act
            var total = sale.GetTotal();

            // Assert
            total.Should().Be(80);
        }

        [Test]
        [TestCase(100, 100, 90)]
        [TestCase(100, 99, 99)]
        [TestCase(100, 101, 91)]
        public void AbsoluteDiscountOverThresholdStrategy(decimal threshold, decimal amount, decimal expectedResult)
        {
            // Arrange
            var absoluteDiscountOverThresholdStrategy = new AbsoluteDiscountOverThresholdStrategy(threshold, 10m);

            // Act
            var result = new Sale(amount, absoluteDiscountOverThresholdStrategy).GetTotal();

            // Assert
            result.Should().Be(expectedResult);
        }

        [Test]
        public void DoubleDiscountAfterLunchStrategy_WhenBefore12_ThenSingleDiscount()
        {
            // Arrange
            var timeSourceMock = new Mock<ITimeSource>();
            timeSourceMock.Setup(x => x.Now).Returns(new DateTime(2018, 1, 1, 11, 59, 59));

            var doubleDiscountAfterLunchStrategy = new DoubleDiscountAfterLunchStrategy(timeSourceMock.Object, 10m);

            // Act
            var result = new Sale(100, doubleDiscountAfterLunchStrategy).GetTotal();

            timeSourceMock.Verify(x => x.Now, Times.Once);
            result.Should().Be(90);
        }

        [Test]
        public void DoubleDiscountAfterLunchStrategy_WhenAfter12_ThenDoubleDiscount()
        {
            // Arrange
            var timeSourceMock = new Mock<ITimeSource>();
            timeSourceMock.Setup(x => x.Now).Returns(new System.DateTime(2018, 1, 1, 12, 01, 00));

            var doubleDiscountAfterLunchStrategy = new DoubleDiscountAfterLunchStrategy(timeSourceMock.Object, 10m);

            // Act
            var result = new Sale(100, doubleDiscountAfterLunchStrategy).GetTotal();

            // Assert
            timeSourceMock.Verify(x => x.Now, Times.Once);
            result.Should().Be(80);
        }

        [Test]
        public void NoPricingStrategy_When100_Then100()
        {
            // Arrange
            var sale = new Sale(100, new NullPricingStrategy());

            // Act
            var result = sale.GetTotal();

            // Assert
            result.Should().Be(100);
        }
    }
}
