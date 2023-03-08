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





}