public class TenetMethods
{
    public static bool TenetChecking(int AnyNumber)
    {
        return AnyNumber / 10000 == AnyNumber % 10 && AnyNumber / 1000 % 10 == AnyNumber % 100 / 10;
    }
}