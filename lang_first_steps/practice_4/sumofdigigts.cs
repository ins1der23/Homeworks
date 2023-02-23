public class SumOfDigitsTask
{
    public static int SumOfDigits(int someNumber)
    {
        int sum = 0;
        while (someNumber > 0)
        {
            sum = sum + (someNumber % 10);
            someNumber = someNumber / 10;
        }
        return sum;
    }
}