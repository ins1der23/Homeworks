public static class ColumnMean
{

    // вывод средних значений колонок в одномерный массив
    public static double[] MeanOfColumns(int[,] anyMatrix)
    {
        int sum = 0;
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        double[] result = new double[columns];
        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                sum += anyMatrix[i, j];
            }
            result[j] = Math.Round((double)sum / rows, 1, MidpointRounding.ToZero);
            sum = 0;
        }
        return result;
    }

    // вывод в строку одномерного массива
    public static string ArrayJoinToString(double[] array)
    {
        return $"{String.Join("; ", array)}";
    }
}