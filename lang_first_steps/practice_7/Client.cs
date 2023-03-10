using static Shared;
using static FillMatrixRandom;
using static ElementPosition;
using static ColumnMean;

public static class Client
{
    public static void RunFillMatrix()
    {
        Console.WriteLine(Task("Заполним массив случайными вещественными числами"));
        int rows = GetInteger("Введите количество строк");
        int startBound = 1;
        rows = BoundInput(rows, "Число строк не может быть меньше 1", startBound);
        int columns = GetInteger("Введите число столбцов");
        columns = BoundInput(columns, "Число столбцов не может быть меньше 1", startBound);
        double[,] someMatrix = CreateDoubleMatrix(rows, columns);
        int numberFrom = -9; int numberTo = 10;
        FillMatrixDblRandom(someMatrix, numberFrom, numberTo);
        Console.WriteLine(MatrixDblToString(someMatrix));
    }
    public static void RunElementPosition()
    {
        Console.WriteLine(Task("Найдем элемент в массиве"));
        Console.WriteLine();
        int rows = new Random().Next(2, 10);
        int columns = new Random().Next(2, 10);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        int numberFrom = 1; int numberTo = 100;
        FillIntMatrixRandom(someMatrix, numberFrom, numberTo);
        Console.WriteLine(MatrixIntToString(someMatrix));
        int[] position = StringToArray(PositionCheck(rows, columns));
        int rowNum = position[0];
        int colNum = position[1];
        Console.WriteLine("Число в строке {0}, столбце {1} = {2}", rowNum, colNum, someMatrix[NumToIndex(rowNum), NumToIndex(colNum)]);
    }
    public static void RunMeanColumn()
    {
        Console.WriteLine(Task("Посчитаем среднее арифметическое столбцов массива"));
        Console.WriteLine();
        int rows = new Random().Next(2, 10);
        int columns = new Random().Next(2, 10);
        int[,] someMatrix = CreateIntMatrix(rows, columns);
        int numberFrom = 1; int numberTo = 10;
        FillIntMatrixRandom(someMatrix, numberFrom, numberTo);        Console.WriteLine(MatrixIntToString(someMatrix));
        double[] means = MeanOfColumns(someMatrix);
        System.Console.WriteLine("Среднее арифметическое каждого столбца: " + Environment.NewLine + ArrayJoinToString(means) + ".");
    }
}