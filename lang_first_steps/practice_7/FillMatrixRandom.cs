


public static class FillMatrixRandom
{
    // создание double двумерного массива
    public static double[,] CreateDoubleMatrix(int rows, int columns)
    {
        double[,] someMatrix = new double[rows, columns];
        return someMatrix;
    }

    // рекурсивное заполнение двумерного массива случайными вещественными числами
    public static void FillMatrixRandomRecurs(double[,] anyMatrix, int numberFrom, int numberTo, int i = 0, int j = 0)
    {
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        if (i >= rows || j >= columns) return;
        {
            anyMatrix[i, j] = new Random().Next(numberFrom * 10, numberTo * 10) / 10.0;
            FillMatrixRandomRecurs(anyMatrix, numberFrom, numberTo, i, j + 1);
            FillMatrixRandomRecurs(anyMatrix, numberFrom, numberTo, i + 1, j);
        }
    }
}

