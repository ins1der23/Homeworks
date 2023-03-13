using System.Xml.Serialization;
public static class Show3DArray
{
    // получение трех случайных чисел для задания размерности массива
    public static (int, int, int) GetThreeRandoms(int numberFrom = 2, int numberTo = 5)
    {
        int firstNum = new Random().Next(numberFrom, numberTo + 1);
        int secondNum = new Random().Next(numberFrom, numberTo + 1);
        int thirdNum = new Random().Next(numberFrom, numberTo + 1);
        return (firstNum, secondNum, thirdNum);
    }
    // создание массива
    public static int[,,] Create3DArray(int height, int width, int depth)
    {
        int[,,] some3DArray = new int[height, width, depth];
        return some3DArray;
    }
    // заполнение строки уникальными числами

    public static void UniqueLine(int[] anyArray)
    {
        int size = anyArray.Length;
        bool uniqueCheck = true;
        for (int i = 0; i < size; i++)
        {
            anyArray[i] = new Random().Next(10, 20);
            for (int j = i - 1; j >= 0; j--)
                if (anyArray[i] == anyArray[j]) uniqueCheck = false;
            if (!uniqueCheck) i = i - 1;
            uniqueCheck = true;
        }
    }
    public static void Fill3DArrayUnique(int[,,] any3DArray)
    {
        int height = any3DArray.GetLength(0);
        int width = any3DArray.GetLength(1);
        int depth = any3DArray.GetLength(2);
        var uniques = new HashSet<int>();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    int someRandom;
                    do
                    {
                        someRandom = new Random().Next(10,100);
                    } while (uniques.Contains(someRandom));
                    uniques.Add(someRandom);
                    any3DArray[i, j, k] = someRandom;
                }
            }
        }
    }
}