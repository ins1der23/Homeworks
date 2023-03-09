using System.Net.Http;
using System.Linq;
public static class ElementPosition
{
// проверка позиции с возвратом значений в int
    public static (int, int) PositionCheckToInt(int rows, int columns)
    {
        string input = Console.ReadLine();
        int input1 = Shared.GetInteger("Введите номер строки искомой позиции");
        int input2 = Shared.GetInteger("Введите номер столбца искомой позиции");
        bool flag = false;
        flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        while (flag)
        {
            Console.WriteLine("Указанной позиции нет в массиве");
            input1 = Shared.GetInteger("Введите еще раз номер строки");
            input2 = Shared.GetInteger("Введите еще раз номер столбца");
            flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        }
        return (input1, input2);
    }
// проверка позиции с возвратом значений в строку
    public static string PositionCheck(int rows, int columns)
    {
        int input1 = Shared.GetInteger("Введите номер строки искомой позиции");
        int input2 = Shared.GetInteger("Введите номер столбца искомой позиции");
        bool flag = false;
        flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        while (flag)
        {
            Console.WriteLine("Указанной позиции нет в массиве");
            input1 = Shared.GetInteger("Введите еще раз номер строки");
            input2 = Shared.GetInteger("Введите еще раз номер столбца");
            flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        }
        return $"{input1},{input2}";
    }
// преобразование строки с числами через запятую в int массив
    public static int[] StringToArray(string numbers)
    {
        var numbersArray = numbers.Split(",")
                                  .Select(e => (int.Parse(e)))
                                  .ToArray();
        return numbersArray;
    }
    // преобразование номера строки/столбца в индекс
    public static int NumToIndex(int n)
    {
        return n - 1;
    }

}