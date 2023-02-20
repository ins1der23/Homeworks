using System;
public class CubesMethods
{
    public static int Cubes(int AnyInteger)
    {
        return AnyInteger * AnyInteger * AnyInteger;
    }
    public static int[] ArrayFromN(int size)
    {
        if (size <= 0) size = Math.Abs(size) + 2;
        return new int[size];
    }

    public static string PrintArray(int[] AnyArray)
    {
        string output = String.Empty;
        int index = 0;
        int size = AnyArray.Length;
        while (index < size)
        {
            output = output + AnyArray[index] + " ";
            index++;
        }
        return output;
    }

    public static void FillCubesToN(int[] AnyArray, int SomeNumber)
    {
        int TempSize = AnyArray.Length - 1;
        if (SomeNumber > 0)
        {
            while (TempSize >= 0)
            {
                AnyArray[TempSize] = Cubes(1 + TempSize);
                TempSize--;
            }
        }
        else
        {
            while (TempSize >= 0)
            {
                AnyArray[TempSize] = Cubes(1 - TempSize);
                TempSize--;
            }
        }
    }
}