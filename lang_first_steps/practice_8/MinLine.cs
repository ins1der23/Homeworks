public static class MinLine
{
    // получение двух разных случайных чисел
    public static (int, int) NotEqualRandoms()
    {
        int firstNum = 0;
        int secondNum = 0;
        bool flag = true;
        flag = (firstNum == secondNum);
        do
        {
            firstNum = new Random().Next(2, 21);
            secondNum = new Random().Next(2, 21);
            flag = (firstNum == secondNum);
            return (firstNum, secondNum);
        } while (true);
    }
    //подсчет суммы строки в массиве
    public static int LineSum(int[,] anyChart, int i, int j = 0, int sum = 0)
    {
        int rows = anyChart.GetLength(0);
        int columns = anyChart.GetLength(1);
        if (j >= columns) return sum;
        {
            sum += anyChart[i, j];
            sum = LineSum(anyChart, i, j + 1, sum);
        }
        return sum;
    }
    //  вывод в int массив сумм строк двумерного массива 
    public static int[] SumOfLines(int[,] anyChart)
    {
        int rows = anyChart.GetLength(0);
        int columns = anyChart.GetLength(1);
        int[] sum = new int[rows];
        for (int i = 0; i < rows; i++)
            sum[i] = LineSum(anyChart, i);
        return sum;
    }
    // поиск индексов строк с минимальной суммой
    public static int MinIndex(int[] anyArray)
    {
        int size = anyArray.Length;
        int minI = 0;
        for (int i = 1; i < size; i++)
            if (anyArray[i] < anyArray[minI]) minI = i;
        return minI;
    }

}
