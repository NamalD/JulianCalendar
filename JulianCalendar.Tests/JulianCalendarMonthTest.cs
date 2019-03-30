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

        // Month lengths
        [Test]
        public void Days_MonthsWith31Days_Has31DayObjects(
            [Values
            (
                CalendarMonth.January,
                CalendarMonth.March,
                CalendarMonth.May,
                CalendarMonth.July,
                CalendarMonth.August,
                CalendarMonth.October,
                CalendarMonth.December
            )] CalendarMonth calendarMonth)
        {
            // Arrange
            const int validYear = 7602;
            const int expectedDays = 31;

            var month = RevisedJulianCalendar.Instance.Year(validYear).Month(calendarMonth);

            // Act
            var days = month.Days;

            // Assert
            Assert.That(days, Has.Count.EqualTo(expectedDays));
        }

        [Test]
        public void Days_MonthsWith30Days_Has30DayObjects(
        [Values
        (
            CalendarMonth.April,
            CalendarMonth.June,
            CalendarMonth.September,
            CalendarMonth.November
        )] CalendarMonth calendarMonth)
        {
            // Arrange
            const int validYear = 1777;
            const int expectedDays = 30;

            var month = RevisedJulianCalendar.Instance.Year(validYear).Month(calendarMonth);

            // Act
            var days = month.Days;

            // Assert
            Assert.That(days, Has.Count.EqualTo(expectedDays));
        }

        [Test]
        public void Days_FebruaryNonLeapYear_Has28Days()
        {
            // Arrange
            const int validYear = 2003;
            const CalendarMonth monthKey = CalendarMonth.February;
            const int expectedDays = 28;

            var month = RevisedJulianCalendar.Instance.Year(validYear).Month(monthKey);

            // Act
            var days = month.Days;

            // Assert
            Assert.That(days, Has.Count.EqualTo(expectedDays));
        }

        [Test]
        public void Days_FebruaryLeapYear_Has29Days()
        {
            // Arrange
            const int validYear = 4000;
            const CalendarMonth monthKey = CalendarMonth.February;
            const int expectedDays = 29;

            var month = RevisedJulianCalendar.Instance.Year(validYear).Month(monthKey);

            // Act
            var days = month.Days;

            // Assert
            Assert.That(days, Has.Count.EqualTo(expectedDays));
        }
    }
}
