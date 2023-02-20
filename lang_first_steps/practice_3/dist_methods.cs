public class DistMethods
{
    public static double[] CreateArray(int size)
    {
        return new double[size];
    }

    public static double GetNumber(string message)
    {
        Console.Write(message);
        return double.Parse(Console.ReadLine());
    }

    public static void UserFilling(double[] AnyArray)
    {
        int size = AnyArray.Length;
        int index = 0;
        while (index < size)
        {
            AnyArray[index] = Math.Round(GetNumber("Введите координату " + (index + 1) + ": "), 2);
            index++;
        }
    }

    public static string PrintArray(double[] AnyArray)
    {
        string output = String.Empty;
        int size = AnyArray.Length;
        int index = 0;
        while (index < size)
        {
            output = output + AnyArray[index] + " ";
            index++;
        }
        return output;
    }

    public static double Dist3D(double[] FirstPoint, double[] SecondPoint)
    {
        return Math.Sqrt(Math.Pow((SecondPoint[0] - FirstPoint[0]), 2) + Math.Pow((SecondPoint[1] - FirstPoint[1]), 2) + Math.Pow((SecondPoint[2] - FirstPoint[2]), 2));
    }

}