using JulianCalendar;
using NUnit.Framework;
using System;

namespace Tests
{
    public class RevisedJulianCalendarTest
    {
        [Test]
        public void Year_ValidYear_ReturnsYearObject()
        {
            // Arrange
            const int testYear = 2019;

            // Act
            var year = RevisedJulianCalendar.Instance.Year(testYear);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(year, Is.Not.Null);
                Assert.That(year, Is.TypeOf<JulianCalendarYear>());
            });
        }

        [Test]
        public void Year_NegativeYear_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            const int testYear = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => RevisedJulianCalendar.Instance.Year(testYear));
        }

        [Test]
        public void Year_YearProperty_MatchesParameter()
        {
            // Arrange
            const int testYear = 2019;

            // Act
            var calendarYear = RevisedJulianCalendar.Instance.Year(testYear);

            // Assert
            Assert.That(calendarYear.Year, Is.EqualTo(testYear));
        }

        [Test]
        public void Year_SameYear_ReturnsSameObject()
        {
            // Arrange
            const int testYear = 2019;

            // Act
            var firstYear = RevisedJulianCalendar.Instance.Year(testYear);
            var secondYear = RevisedJulianCalendar.Instance.Year(testYear);

            // Assert
            Assert.That(firstYear, Is.SameAs(secondYear));
        }
    }
}