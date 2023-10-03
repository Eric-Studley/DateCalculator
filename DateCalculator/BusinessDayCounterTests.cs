using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DateCalculator
{
    public class BusinessDayCounterTests
    {
        [Theory]
        [ClassData(typeof(WeekdaysBetweenTwoDatesTestsData))]
        public void WeekdaysBetweenTwoDatesTests(DateTime startDate, DateTime endDate, int expectedResult)
        {
            var counter = new BusinessDayCounter();

            var result = counter.WeekdaysBetweenTwoDates(startDate, endDate);

            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [ClassData(typeof(BusinessDaysTestData))]
        public void BusinessDaysBetweenTwoDatesTests(DateTime startDate, DateTime endDate, IList<DateTime> publicHolidays, int expectedResult)
        {
            var counter = new BusinessDayCounter();

            var result = counter.BusinessDaysBetweenTwoDates(startDate, endDate, publicHolidays);

            Assert.Equal(result, expectedResult);
        }
    }

    public class WeekdaysBetweenTwoDatesTestsData : TheoryData<DateTime, DateTime, int>
    {
        public WeekdaysBetweenTwoDatesTestsData()
        {
            Add(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), 1);
            Add(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14), 5);
            Add(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), 61);
            Add(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5), 0);
        }
    }

    public class BusinessDaysTestData : TheoryData<DateTime, DateTime, IList<DateTime>, int>
    {
        public BusinessDaysTestData()
        {
            var publicHolidays = new List<DateTime> { new DateTime(2013, 12, 25), new DateTime(2013, 12, 26), new DateTime(2014, 1, 1) };

            Add(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), publicHolidays, 1);
            Add(new DateTime(2013, 12, 24), new DateTime(2013, 12, 27), publicHolidays, 0);
            Add(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), publicHolidays, 59);
        }
    }
}
