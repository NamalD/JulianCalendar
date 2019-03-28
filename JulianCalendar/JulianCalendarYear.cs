using System;
using System.Collections.Generic;

namespace JulianCalendar
{
    public class JulianCalendarYear
    {
        public int Year { get; set; }
        private ICollection<JulianCalendarMonth> _months;

        public JulianCalendarYear(int year)
        {
            Year = year;

            _months = new List<JulianCalendarMonth>();
            GenerateMonths();
        }
        
        public IEnumerable<JulianCalendarMonth> Months
        {
            get
            {
                return _months;
            }
        }

        private void GenerateMonths()
        {
            _months.Clear();

            for (int monthNumber = 0; monthNumber < 12; monthNumber++)
            {
                var month = new JulianCalendarMonth();
                _months.Add(month);
            }
        }

        public object Month(Month month)
        {
            throw new NotImplementedException();
        }
    }
}