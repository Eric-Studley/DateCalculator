using DateCalculator.Extensions;
using DateCalculator.PublicHolidays;

namespace DateCalculator
{
    public class BusinessDayCounter : IBusinessDayCounter
    {
        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            if (secondDate <= firstDate) return 0;

            var totalDays = (int) (secondDate - firstDate).TotalDays - 1;
            var numberOfWeekends = (totalDays + (int) firstDate.DayOfWeek + 1) / 7 * 2;

            if (firstDate.IsWeekend()) numberOfWeekends--;
            if (secondDate.IsWeekend()) numberOfWeekends--;

            return totalDays - numberOfWeekends;
        }
        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            if (secondDate <= firstDate) return 0;
       
            var totalDays = WeekdaysBetweenTwoDates(firstDate, secondDate) - publicHolidays
                 .Count(holiday => firstDate < holiday && holiday < secondDate && !holiday.IsWeekend());

            return totalDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<Holiday> publicHolidays)
        {
            if (secondDate <= firstDate) return 0;

            var totalDays = WeekdaysBetweenTwoDates(firstDate, secondDate) - publicHolidays
                .Select(x => x.GetDate(firstDate.Year))
                .Concat(publicHolidays.Select(x => x.GetDate(secondDate.Year)))
                .Distinct()
                .Count(holiday => firstDate < holiday && holiday < secondDate && !holiday.IsWeekend());

            return totalDays;
        }
    }
}