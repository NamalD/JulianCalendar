using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JulianCalendar.Tests
{
    class JulianCalendarYearTest
    {
        [Test]
        public void Months_Collection_HasTwelveMonths()
        {
            // Arrange
            const int validYear = 2014;
            var calendarYear = RevisedJulianCalendar.Instance.Year(validYear);

            // Act
            var months = calendarYear.Months;

            // Assert
            Assert.That(months, Has.Exactly(12).Items);
        }

        [Test]
        public void Month_ValidMonth_ReturnsMonthObject()
        {
            // Arrange
            const int validYear = 2014;
            const CalendarMonth validMonth = CalendarMonth.January;

            var calendarYear = RevisedJulianCalendar.Instance.Year(validYear);

            // Act
            var month = calendarYear.Month(validMonth);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(month, Is.TypeOf<JulianCalendarMonth>());
                Assert.That(month, Is.Not.Null);
            });
        }
    }
}
