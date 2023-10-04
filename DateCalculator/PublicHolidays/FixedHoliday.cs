using DateCalculator.Enums;

namespace DateCalculator.PublicHolidays
{
    public class FixedHoliday : Holiday
    {
        public Month Month { get; set; }
        public int Day { get; set; }

        public override DateTime GetDate(int year)
        {
            return new DateTime(year, (int)Month + 1, Day);
        }
    }
}
