using System;
public class Count
{
    public static int[] CreateArray(int size)
    {
        return new int[size];
    }
    public static int GetInteger(string text)
    {
        int num = 0;
        bool flag = true;
        do
        {
            Console.Write($"{text}: ");
            flag = int.TryParse(Console.ReadLine(), out num);
        } while (!flag);
        return num;
    }
    public static int RangeForNumber(int check, int bound1, int bound2, string message)
    {
        bool flag = true;
        flag = (check < bound1 || check > bound2);
        while (flag)
        {
            Console.WriteLine(message);
            check = GetInteger("Введите еще раз ");
        }
        return check;
    }
    public static void FillArrayRecursive(int[] anyArray, int i = 0)
    {
        if (i >= anyArray.Length) return;
        anyArray[i] = GetInteger($"Введите {i + 1}-е число");
        FillArrayRecursive(anyArray, i + 1);
    }
    public static string ArrayToString(int[] anyArray)
    {
        string output = String.Empty;
        for (int i = 0; i < anyArray.Length; i++)
        {
            output = output + " " + anyArray[i];
        }
        return output;
    }

    public static int CountPositiveRecursive(int[] anyArray, int i = 0, int counter = 0)
    {
        if (i >= (anyArray.Length)) return counter;
        if (anyArray[i] > 0)
        {
            counter = counter + CountPositiveRecursive(anyArray, i + 1, counter) + 1;
        }
        return counter;

        // {
        //     counter++;
        //     counter += 
        //     return counter;
        // }



    }


}


