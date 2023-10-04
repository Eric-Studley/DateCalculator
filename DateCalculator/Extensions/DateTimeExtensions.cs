namespace DateCalculator.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
