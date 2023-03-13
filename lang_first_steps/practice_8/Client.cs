using System.Runtime.InteropServices;
using System;
using static Shared;
using static DecreasingSort;
using static MinLine;
using static Show3DArray;
public static class Client

{
    public static void RunDecreasingSort()
    {
        int rows = GetTwoRandoms().Item1;
        int columns = GetTwoRandoms().Item2;
        int[,] someChart = CreateIntMatrix(rows, columns);
        int numberFrom = GetInteger("Введите минимально возможное значение числа в таблице");
        int numberTo = GetInteger("Введите максимально возможное значение числа в таблице");
        Console.WriteLine();
        FillMatrixRandom(someChart, numberFrom, (PlusOne(numberTo)));
        Console.WriteLine(MatrixToString(someChart));
        LinesMatrixSort(someChart);
        Console.WriteLine(MatrixToString(someChart));
    }
    public static void RunMinLine()
    {
        int rows = NotEqualRandoms().Item1;
        int columns = NotEqualRandoms().Item2;
        int[,] someChart = CreateIntMatrix(rows, columns);
        FillMatrixRandom(someChart, 1, 5);
        Console.WriteLine(MatrixToString(someChart));
        int[] sums = SumOfLines(someChart);
        Console.WriteLine($"Суммы строк в таблице: {String.Join(' ', sums)}");
        int min = MinInArray(sums);
        bool[] countMinimal = FindNumberInArray(sums, min);
        Console.WriteLine(ConditionToString(countMinimal, "Строки с минимальной суммой: "));
    }
    public static void RunShow3DArray()
    {
        int height = GetThreeRandoms(2,3).Item1;
        int width = GetThreeRandoms(2,3).Item2;
        int depth = GetThreeRandoms(2,3).Item3;
        int[,,] someCubeArray = new int[height, width, depth];
        Fill3DArrayUnique(someCubeArray);


    }
}