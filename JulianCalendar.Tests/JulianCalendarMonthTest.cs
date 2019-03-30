using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace JulianCalendar.Tests
{
    class JulianCalendarMonthTest
    {
        [Test]
        public void Constructor_Month_IsSet()
        {
            // Arrange
            const int validYear = 2010;
            const CalendarMonth validMonth = CalendarMonth.April;

            var year = RevisedJulianCalendar.Instance.Year(validYear);

            // Act
            var month = year.Month(validMonth);

            // Assert
            Assert.That(month.Month, Is.EqualTo(validMonth));
        }

        [Test]
        public void Day_ValidDate_ReturnsDayObject()
        {
            // Arrange
            const int validYear = 1806;
            const CalendarMonth validMonth = CalendarMonth.January;
            const int validDate = 1;

            var month = RevisedJulianCalendar.Instance.Year(validYear).Month(validMonth);

            // Act
            var day = month.Day(validDate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(day, Is.Not.Null);
                Assert.That(day, Is.TypeOf<JulianCalendarDay>());
            });
        }

        [Test]
        public void Year_Parent_SameObject()
        {
            // Arrange
            const int validYear = 1304;
            const CalendarMonth validMonth = CalendarMonth.December;

            // Act
            var year = RevisedJulianCalendar.Instance.Year(validYear);
            var month = year.Month(validMonth);
            var parentYear = month.Year;

            // Assert
            Assert.That(parentYear, Is.SameAs(year));
        }
    }
}
