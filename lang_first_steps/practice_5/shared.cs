public class Shared
{

    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }
    public static int GetInteger(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    public static bool CompareLess(int anyNumber, int bound)
    {
        return anyNumber < bound;
    }

    public static int InputTill(string message, int someNumber, int border)
    {
        while (CompareLess(someNumber, border))
        {
            Console.WriteLine(message);
            someNumber = GetInteger("Введите еще раз ");
        }
        return someNumber;
    }


    public static int[] CreateArray(int size)
    {
        return new int[size];
    }

    public static void FillArrayRandom(int[] anyArray, int bound1, int bound2)
    {
        for (int i = 0; i < anyArray.Length; i++)
        {
            anyArray[i] = new Random().Next(bound1, bound2);
        }
    }
    public static string PrintArray(int[] someArray)
    {
        string output = String.Empty;
        for (int i = 0; i < someArray.Length; i++)
        {
            output = output + " " + someArray[i];

        }
        return output;
    }
    public static int CountEven(int[] anyArray)
    {
        int count = 0;
        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] % 2 == 0) count++;
        }
        return count;
    }

    public static int SumOfOddPos(int[] anyArray)
    {
        int sum = 0;
        for (int i = 1; i < anyArray.Length; i = i + 2)
        {
            sum = sum + anyArray[i];
        }
        return sum;
    }

    public static double[] CreateDblArray(int size)
    {
        return new double[size];
    }

    public static void FillDblArrayRandom(double[] anyArray, int bound1, int bound2)
    {
        for (int i = 0; i < anyArray.Length; i++)
        {
            anyArray[i] = new Random().Next(bound1 * 100, bound2 * 100) / 100.0;
        }
    }
    public static string PrintDblArray(double[] someArray)
    {
        string output = String.Empty;
        for (int i = 0; i < someArray.Length; i++)
        {
            output = output + " " + someArray[i];

        }
        return output;
    }
    public static double DiffMaxMin(double[] anyArray)
    {
        int minI = 0;
        int maxI = 0;
        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] > anyArray[maxI]) maxI = i;
            if (anyArray[i] < anyArray[minI]) minI = i;
        }
        return anyArray[maxI] - anyArray[minI];
}
}