using System;
public class Shared
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

    //  число от ...
    public static int BoundInput(int check, string message, int startBound)
    {
        bool flag = true;
        flag = (check >= startBound);
        while (!flag)
        {
            Console.WriteLine(message);
            check = GetInteger("Введите еще раз ");
            flag = (check >= startBound);
        }
        return check;
    }

    // создание int двумерного массива
    public static int[,] CreateIntMatrix(int rows, int columns)
    {
        int[,] someMatrix = new int[rows, columns];
        return someMatrix;
    }

    // заполнение int массива случаныйми числами
    public static void FillIntMatrixRandom(int[,] anyMatrix, int numberFrom, int numberTo, int i = 0, int j = 0)
    {
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        if (i >= rows || j >= columns) return;
        {
            anyMatrix[i, j] = new Random().Next(numberFrom, numberTo);
            FillIntMatrixRandom(anyMatrix, numberFrom, numberTo, i, j + 1);
            FillIntMatrixRandom(anyMatrix, numberFrom, numberTo, i + 1, j);
        }
    }

    // возврат в строку значений double двумерного массива
    public static string MatrixIntToString(int[,] anyMatrix)
    {
        string output = String.Empty;
        int rows = anyMatrix.GetLength(0);
        int columns = anyMatrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                output += anyMatrix[i, j] + " ";
            }
            output += Environment.NewLine;
        }
        return output;
    }
}





