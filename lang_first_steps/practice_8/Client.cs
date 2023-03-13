using System;
using static Shared;
using static DecreasingSort;
using static MinLine;
public static class Client
{
    public static void RunDecreasingSort()
    {
        int rows = new Random().Next(5, 20);
        int columns = new Random().Next(5, 20);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        int numberFrom = GetInteger("Введите минимально возможное значение числа в таблице");
        int numberTo = GetInteger("Введите максимально возможное значение числа в таблице");
        Console.WriteLine();
        FillMatrixRandom(someMatrix, numberFrom, (PlusOne(numberTo)));
        Console.WriteLine(MatrixToString(someMatrix));
        LinesMatrixSort(someMatrix);
        Console.WriteLine(MatrixToString(someMatrix));
    }
    public static void RunMinLine()
    {
        var sizes = NotEqualRandoms();
        int[,] someChart = CreateIntMatrix(sizes.Item1, sizes.Item2);
        Fill





    }
}