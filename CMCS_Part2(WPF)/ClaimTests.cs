﻿using NUnit.Framework;

namespace CMCS.Tests
{
    [TestFixture]
    public class ClaimTests
    {
        [Test]
        public void CalculateTotalAmount_ValidInput_ReturnsCorrectTotal()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = 50
            };

            // Act
            double result = claim.CalculateTotalAmount();

            // Assert using Assert.That
            Assert.That(result, Is.EqualTo(500));  // Use Assert.That instead of Assert.AreEqual
        }

        [Test]
        public void CalculateTotalAmount_ZeroHours_ReturnsZero()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = 0,
                HourlyRate = 50
            };

            // Act
            double result = claim.CalculateTotalAmount();

            // Assert using Assert.That
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalAmount_ZeroRate_ReturnsZero()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = 0
            };

            // Act
            double result = claim.CalculateTotalAmount();

            // Assert using Assert.That
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateTotalAmount_NegativeHours_ReturnsNegativeTotal()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = -10,
                HourlyRate = 50
            };

            // Act
            double result = claim.CalculateTotalAmount();

            // Assert using Assert.That
            Assert.That(result, Is.EqualTo(-500));
        }

        [Test]
        public void CalculateTotalAmount_NegativeRate_ReturnsNegativeTotal()
        {
            // Arrange
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = -50
            };

            // Act
            double result = claim.CalculateTotalAmount();

            // Assert using Assert.That
            Assert.That(result, Is.EqualTo(-500));
        }
    }
}

