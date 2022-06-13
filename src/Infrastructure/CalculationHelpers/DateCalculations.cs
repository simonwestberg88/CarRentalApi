namespace Infrastructure.CalculationHelpers;

public static class DateCalculations
{
    public static int CalculateDays(DateTime startDateTime, DateTime endDateTime)
    {
        //if 0 return 1 (can not rent for less time than a day)
        //if less than 0 then the end date time is wrong, handle error
        var test =(int)Math.Ceiling((endDateTime - startDateTime).TotalDays); 
        return (int)Math.Ceiling((endDateTime - startDateTime).TotalDays);
    }
}