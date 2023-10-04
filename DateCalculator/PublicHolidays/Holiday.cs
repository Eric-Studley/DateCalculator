namespace DateCalculator.PublicHolidays
{
    public abstract class Holiday
    {
        public string Name { get; set; }
        public abstract DateTime GetDate(int year);
    }
}
