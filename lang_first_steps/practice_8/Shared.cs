using System;
public static class Shared
{
    // офрмление текста задания
    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }

    // получение числа от пользователя
    public static int GetInteger(string text)
    {
        int num = 0;
        bool flag = true;
        do
        {
            Console.Write($"{text}: ");
            flag = int.TryParse(Console.ReadLine(), out num);
        } while (!flag);
        return num;
    }

    //  дипазон для числа
    public static int BoundInput(int check, string message, int startBound, int endBound)
    {
        bool flag = true;
        flag = (check >= startBound && check <= endBound);
        while (!flag)
        {
            Console.WriteLine(message);
            check = GetInteger("Введите еще раз ");
            flag = (check >= startBound && check <= endBound);
        }
        return check;
    }

    // создание int двумерного массива
    public static int[,] CreateIntMatrix(int rows, int columns)
    {
        int[,] someMatrix = new int[rows, columns];
        return someMatrix;
    }

    // прибавить единицу
    public static int PlusOne(int number)
    {
        return number + 1;
    }

    // заполнение строки int массива случайными числами рекурсивно
    public static void LineFillRandomRecursive(int[,] anyMatrix, int numberFrom, int numberTo, int i, int j = 0)
    {
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        if (i >= rows || j >= columns) return;
        {
            anyMatrix[i, j] = new Random().Next(numberFrom, numberTo);
            LineFillRandomRecursive(anyMatrix, numberFrom, numberTo, i, j + 1);
        }
    }

    // заполнение int массива случайными числами
    public static void FillMatrixRandom(int[,] anyMatrix, int numberFrom, int numberTo)
    {
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            LineFillRandomRecursive(anyMatrix, numberFrom, numberTo, i);
        }
    }
    // возврат в строку значений int двумерного массива
    public static string MatrixToString(int[,] anyMatrix)
    {
        string output = String.Empty;
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                output += $"{anyMatrix[i, j],4}";
            }
            output += Environment.NewLine;
        }
        return output;
    }

    public static string ArrayJoinToString(int[] array)
    {
        return $"[{String.Join(' ', array)}]";
    }
}

