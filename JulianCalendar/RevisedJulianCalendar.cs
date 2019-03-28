using System;
using System.Collections.Generic;

namespace JulianCalendar
{
    public class RevisedJulianCalendar
    {
        private static RevisedJulianCalendar _instance;
        private static readonly object _lock = new object();
        private static IDictionary<int, JulianCalendarYear> _years = new Dictionary<int, JulianCalendarYear>();

        public static RevisedJulianCalendar Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ?? (_instance = new RevisedJulianCalendar());
                }
            }
        }

        public JulianCalendarYear Year(int year)
        {
            if (year < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be positive");
            }

            if (!_years.TryGetValue(year, out JulianCalendarYear calendarYear))
            {
                calendarYear = new JulianCalendarYear(year);
                _years.Add(year, calendarYear);
            }

            return calendarYear;
        }
    }
}