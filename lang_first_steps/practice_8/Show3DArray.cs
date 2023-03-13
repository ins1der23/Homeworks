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
    // заполнение массива  уникальными случайными числами
    public static void Fill3DArrayUnique(int[,,] any3dArray)
    {
        int height = any3dArray.GetLength(0);
        int width = any3dArray.GetLength(1);
        int depth = any3dArray.GetLength(2);
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
                        someRandom = new Random().Next(10, 100);
                    } while (uniques.Contains(someRandom));
                    uniques.Add(someRandom);
                    any3dArray[i, j, k] = someRandom;
                }
            }
        }
    }
    // возврат в строку 3D массива
    public static string CubeArrayToString(int[,,] any3dArray)
    {
        int height = any3dArray.GetLength(0);
        int width = any3dArray.GetLength(1);
        int depth = any3dArray.GetLength(2);
        string output = String.Empty;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                for (int k = 0; k < depth; k++)
                {
                    output += $"{any3dArray[i, j, k]} ({i},{j},{k}) ";
                }
                output += Environment.NewLine;
            }
        }
        return output;
    }
}