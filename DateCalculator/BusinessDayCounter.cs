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

            var totalDays = (secondDate - firstDate).TotalDays;
            var numberOfWeekends = (totalDays + (int) firstDate.DayOfWeek) / 7 * 2;

            return (int) (totalDays - numberOfWeekends);
            //todo
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            //todo
            return 0;
        }
    }
}