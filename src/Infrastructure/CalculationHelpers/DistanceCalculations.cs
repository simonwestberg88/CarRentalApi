namespace Infrastructure.CalculationHelpers;

public static class DistanceCalculations
{
    public static int Calculate(int meterStart, int meterEnd)
    {
        //handle when negative
        //handle when zero
        return meterEnd - meterStart;
    }
}