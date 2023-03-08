using static Shared;
using static FillMatrixRandom;

public static class Client

{
    public static void RunFillMatrix()
    {
        Console.WriteLine(Task("Заполним массив случайными числами"));
        int rows = GetInteger("Введите количество строк");
        rows = BoundInput(rows, "Число строк не может быть меньше 1", 1);
        int columns = GetInteger("Введите число столбцов");
        columns = BoundInput(columns, "Число столбцов не может быть меньше 1", 1);
        double[,] someMatrix = CreateDoubleMatrix(rows, columns);
        FillMatrixRandomRecurs(someMatrix, -10, 10);
        Console.WriteLine(MatrixToString(someMatrix));
    }
    public static void RunElementPosition()
    {
        Console.WriteLine(Task("Найдем элемент в массиве"));
        int rows = GetInteger("Введите количество строк");
        rows = BoundInput(rows, "Число строк не может быть меньше 1", 1);
        int columns = GetInteger("Введите число столбцов");
        columns = BoundInput(columns, "Число столбцов не может быть меньше 1", 1);
        int[] someMatrix = CreateIntMatrix(rows, columns);







    }




}