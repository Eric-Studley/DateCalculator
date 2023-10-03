using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateCalculator
{
    public class BusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (secondDate <= firstDate) return 0;

            var totalDays = (int) (secondDate - firstDate).TotalDays - 1;
            var numberOfWeekends = (int) (totalDays + (int) firstDate.DayOfWeek + 1) / 7 * 2;

            if (firstDate.DayOfWeek == DayOfWeek.Saturday) numberOfWeekends--;
            if (secondDate.DayOfWeek == DayOfWeek.Sunday) numberOfWeekends--;

            return totalDays - numberOfWeekends;
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (secondDate <= firstDate) return 0;

            var totalDays = WeekdaysBetweenTwoDates(firstDate, secondDate);

            foreach (var holiday in publicHolidays)
            {
                if (firstDate < holiday && holiday < secondDate && holiday.DayOfWeek != DayOfWeek.Saturday && holiday.DayOfWeek != DayOfWeek.Sunday)
                {
                    totalDays--; 
                }
            }

           return totalDays;
        }
    }
}