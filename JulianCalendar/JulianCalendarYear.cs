using System;
using System.Collections.Generic;

namespace JulianCalendar
{
    public class JulianCalendarYear
    {
        public int Year { get; set; }
        private IDictionary<CalendarMonth, JulianCalendarMonth> _months;

        public JulianCalendarYear(int year)
        {
            Year = year;

            _months = new Dictionary<CalendarMonth, JulianCalendarMonth>();
            GenerateMonths();
        }
        
        public IEnumerable<JulianCalendarMonth> Months
        {
            get
            {
                return _months.Values;
            }
        }

        private void GenerateMonths()
        {
            _months.Clear();

            foreach (var monthKey in (CalendarMonth[]) Enum.GetValues(typeof(CalendarMonth)))
            {
                var month = new JulianCalendarMonth(this, monthKey);
                _months.Add(monthKey, month);
            }
        }

        public JulianCalendarMonth Month(CalendarMonth month)
        {
            return _months[month];
        }
    }
}