using System.Net.Http.Headers;
public class Methods
{

    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }

    public static double GetDouble(string message)
    {
        Console.Write(message);
        return double.Parse(Console.ReadLine());
    }
    public static int GetInteger(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }


    public static int NaturalCheck(int check, string message)
    {
        while (check < 0)
        {
            Console.WriteLine(message);
            check = GetInteger("Введите еще раз ");
        }
        return check;
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
    public static int[] CreateArray(int size)
    {
        return new int[size];
    }

}

