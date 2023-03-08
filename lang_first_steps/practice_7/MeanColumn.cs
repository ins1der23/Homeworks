public static class ColumnMean
{
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
            result[j] = (double)sum / rows;
            sum = 0;
        }
        return result;
    }



}