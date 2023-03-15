public class Shared
{
    // офрмление текста задания
    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }

    // получение случайного положительного N
    public static int GetPositiveRandom(int numberTo)
    {
        return new Random().Next(1, numberTo + 1);
    }
    // возврат в строку чисел от N до 1
    public static string NumberToOneString(int anyNumber)
    {
        if (anyNumber == 1) return $"{anyNumber} ";
        return $"{anyNumber} " + NumberToOneString(anyNumber - 1);
    }

    // получение int числа от пользователя
    static int GetInteger(string text)
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
    // получение разных положительных M и N
    public static (int, int) GetFirstLessSecondNaturals(string message)
    {
        Console.WriteLine(message);
        int firstNum = 0; int secondNum = 0;
        bool flag = (true);
        do
        {
            firstNum = GetInteger("Введите первое число");
            secondNum = GetInteger("Введите второе число");
            flag = (secondNum == firstNum || firstNum < 1 || secondNum < 1);
            if (flag) Console.WriteLine("Условие ввода не выполнено, введите еще раз");
        } while (flag);
        if (firstNum > secondNum)
        {
            int temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;
        }
        return (firstNum, secondNum);
    }

    // получение суммы между M и N
    public static int SumBetween(int firstNum, int secondNum)
    {
        if (secondNum == firstNum) return secondNum;
        return secondNum + SumBetween(firstNum, secondNum - 1);
    }

    // вычисление функции Акермана

    public static int Ackerman(int firstNum, int secondNum)
    {
        if (firstNum == 0)
            return secondNum + 1;
        else
          if ((firstNum != 0) && (secondNum == 0))
            return Ackerman(firstNum - 1, 1);
        else
            return Ackerman(firstNum - 1, Ackerman(firstNum, secondNum - 1));
    }
    // вывод в строку результата вычисления функции Аккермана
    public static string AckermanResultToString(int m, int n, int ackerman)
    {
        return $"m = {m}, n = {n} -> A({m},{n}) = {ackerman}";
    }

}

