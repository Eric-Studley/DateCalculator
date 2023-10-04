using DateCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator.PublicHolidays
{
    public class OccurenceHoliday : Holiday
    {
        public Month Month { get; set; }
        public Occurence Occurence { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public override DateTime GetDate(int year)
        {
            if (Occurence != Occurence.Last)
            {
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, (int)Month, 1);
                var daysUntilWeekday = ((int)DayOfWeek - (int)firstDayOfMonth.DayOfWeek + 7) % 7;
                var daysToAdd = ((int)Occurence * 7) + daysUntilWeekday + 1;
                return firstDayOfMonth.AddDays(daysToAdd);
            } 
            else
            {
                var lastDayOfMonth = new DateTime(year, (int)Month + 1, DateTime.DaysInMonth(year, (int)Month + 1));

                while (lastDayOfMonth.DayOfWeek != DayOfWeek)
                {
                    lastDayOfMonth = lastDayOfMonth.AddDays(-1);
                }

                return lastDayOfMonth;
            }
            
        }
    }
}
