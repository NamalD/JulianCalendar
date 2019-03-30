using System;
using System.Collections.Generic;

namespace JulianCalendar
{
    public class JulianCalendarMonth
    {
        public CalendarMonth Month { get; }
        public JulianCalendarYear Year { get; }
        public IDictionary<int, JulianCalendarDay> Days { get; }

        public JulianCalendarMonth(JulianCalendarYear year, CalendarMonth month)
        {
            Days = new Dictionary<int, JulianCalendarDay>();

            Year = year;
            Month = month;

            GenerateDays();
        }

        private void GenerateDays()
        {
            Days.Clear();

            for (int date = 1; date <= 31; date++)
            {
                var day = new JulianCalendarDay();
                Days.Add(date, day);
            }
        }

        public JulianCalendarDay Day(int date)
        {
            if (!Days.ContainsKey(date))
            {
                throw new ArgumentOutOfRangeException(nameof(date), "Invalid date");
            }

            return Days[date];
        }
    }
}