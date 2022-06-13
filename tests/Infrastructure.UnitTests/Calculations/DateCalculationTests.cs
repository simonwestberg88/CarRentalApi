using Infrastructure.CalculationHelpers;


namespace Infrastructure.UnitTests.Calculations;

public class DateCalculationTests
{
    [Theory, MemberData(nameof(DateCalculationTestData))]
    public void CalculateDateTest(DateTime startDate, DateTime endDate, int expectedNumberOfDays)
    {
        var result = DateCalculations.CalculateDays(startDate, endDate);
        result.Should().Be(expectedNumberOfDays);
    }
    
    public static IEnumerable<object[]> DateCalculationTestData =>
        new List<object[]>
        {
            new object[] { "2020-01-01 10:00", "2020-01-02 10:00", 1 },
            new object[] { "2020-01-01 10:00", "2020-01-01 11:00", 1 },
            new object[] { "2020-01-01 10:00", "2020-01-04 10:00", 3 },
            new object[] { "2020-01-01 10:00", "2020-01-04 11:00", 4 },
        };
}