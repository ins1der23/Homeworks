public static class DecreasingSort
{
    // получение двух разных случайных чисел
    public static (int, int) TwoRandoms()
    {
        int firstNum = new Random().Next(2, 21);
        int secondNum = new Random().Next(2, 21);
        return (firstNum, secondNum);

    }

    //  метод для Qsort сортировки строки
    static int Partition(int[] anyArray, int start, int end)
    {
        int marker = start;
        for (int i = start; i <= end; i++)
        {
            if (anyArray[i] >= anyArray[end])
            {
                if (anyArray[i] != anyArray[marker])
                {
                    int temp = anyArray[marker];
                    anyArray[marker] = anyArray[i];
                    anyArray[i] = temp;
                }
                marker++;
            }
        }
        return marker - 1;
    }
    // Qsort сортировкa строки
    public static void SortLineDecrease(int[] anyArray, int start, int end)
    {
        if (start >= end) return;
        int pivot = Partition(anyArray, start, end);
        SortLineDecrease(anyArray, start, pivot - 1);
        SortLineDecrease(anyArray, pivot + 1, end);
    }

    // Построчная сортировка двумерного массива
    public static void LinesMatrixSort(int[,] anyMatrix)
    {
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        int[] tempLine = new int[columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++) tempLine[j] = anyMatrix[i, j];
            int start = 0;
            int end = columns - 1;
            SortLineDecrease(tempLine, start, end);
            for (int j = 0; j < columns; j++) anyMatrix[i, j] = tempLine[j];
        }
    }
}