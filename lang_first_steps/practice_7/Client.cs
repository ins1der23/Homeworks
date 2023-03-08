using static Shared;
using static FillMatrixRandom;
using static ElementPosition;

public static class Client
{
    public static void RunFillMatrix()
    {
        Console.WriteLine(Task("Заполним массив случайными вещественными числами"));
        int rows = GetInteger("Введите количество строк");
        rows = BoundInput(rows, "Число строк не может быть меньше 1", 1);
        int columns = GetInteger("Введите число столбцов");
        columns = BoundInput(columns, "Число столбцов не может быть меньше 1", 1);
        double[,] someMatrix = CreateDoubleMatrix(rows, columns);
        FillMatrixDblRandom(someMatrix, -10, 10);
        Console.WriteLine(MatrixDblToString(someMatrix));
    }
    public static void RunElementPosition()
    {
        Console.WriteLine(Task("Найдем элемент в массиве"));
        Console.WriteLine();
        int rows = new Random().Next(2, 10);
        int columns = new Random().Next(2, 10);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        FillIntMatrixRandom(someMatrix, 1, 100);
        Console.WriteLine(MatrixIntToString(someMatrix));
        var position = PositionCheck(rows, columns);
        int rowNum = position.Item1;
        int colNum = position.Item2;
        Console.WriteLine("Число в строке {0}, столбце {1} = {2}", rowNum, colNum, someMatrix[NumToIndex(rowNum), NumToIndex(colNum)]);
    }
    public static void MeanColumn()
    {
        Console.WriteLine(Task("Посчитаем среднее арифметическое столбцов массива"));
        Console.WriteLine();
        int rows = new Random().Next(2, 10);
        int columns = new Random().Next(2, 10);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        FillIntMatrixRandom(someMatrix, 1, 100);




    }



}