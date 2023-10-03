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
        [ClassData(typeof(BusinessDayTestData))]
        public void WeekdaysBetweenTwoDatesTests(DateTime startDate, DateTime endDate, int expectedResult)
        {
            var counter = new BusinessDayCounter();

            var result = counter.WeekdaysBetweenTwoDates(startDate, endDate);

            Assert.Equal(result, expectedResult);
        }
    }

    public class BusinessDayTestData : TheoryData<DateTime, DateTime, int>
    {
        public BusinessDayTestData()
        {
            Add(new DateTime(2013, 10, 7), new DateTime(2013, 10, 9), 1);
            Add(new DateTime(2013, 10, 5), new DateTime(2013, 10, 14), 5);
            Add(new DateTime(2013, 10, 7), new DateTime(2014, 1, 1), 61);
            Add(new DateTime(2013, 10, 7), new DateTime(2013, 10, 5), 0);
        }
    }
}
