public class PowTask
{
    public static double GetDouble(string message)
    {
        Console.Write(message);
        return double.Parse(Console.ReadLine());
    }
     public static double ToPow(double AnyNubmber, int degree)
    {
        double result = 1;
        for (int i = 0; i < degree; i++)
        {
            result = result * AnyNubmber;
        }
        return result;
    }
}