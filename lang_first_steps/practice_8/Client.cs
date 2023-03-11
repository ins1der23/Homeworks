using System;
using static Shared;

public static class Client
{

    public static void RunDecreasingSort()
    {
        int rows = new Random().Next(5, 20);
        int columns = new Random().Next(5, 20);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        int numberFrom = GetInteger("Введите минимально возможное значение числа в таблице");
        int numberTo = GetInteger("Введите максимально возможное значение числа в таблице");
        FillMatrixRandom(someMatrix, numberFrom, (PlusOne(numberTo)));
        Console.WriteLine(MatrixToString(someMatrix));


    }




}