using System;
using System.Collections.Generic;

namespace JulianCalendar
{
    public class JulianCalendarMonth
    {
        public CalendarMonth Month { get; }
        public JulianCalendarYear Year { get; }

        private IDictionary<int, JulianCalendarDay> _days;

        public JulianCalendarMonth(JulianCalendarYear year, CalendarMonth month)
        {
            _days = new Dictionary<int, JulianCalendarDay>();

            Year = year;
            Month = month;

            GenerateDays();
        }

        private void GenerateDays()
        {
            _days.Clear();

            for (int date = 1; date <= 31; date++)
            {
                var day = new JulianCalendarDay();
                _days.Add(date, day);
            }
        }

        public JulianCalendarDay Day(int date)
        {
            if (!_days.ContainsKey(date))
            {
                throw new ArgumentOutOfRangeException(nameof(date), "Invalid date");
            }

            return _days[date];
        }
    }
}