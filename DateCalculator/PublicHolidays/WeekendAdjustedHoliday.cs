using DateCalculator.Enums;
using DateCalculator.Extensions;

namespace DateCalculator.PublicHolidays
{
    public class WeekendAdjustedHoliday : Holiday
    {
        public Month Month { get; set; }
        public int Day { get; set; }
        public override DateTime GetDate(int year)
        {
            DateTime date = new DateTime(year, (int)Month + 1, Day);

            if (!date.IsWeekend()) return date; 

            var daysUntilMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(daysUntilMonday);
        }
    }
}
