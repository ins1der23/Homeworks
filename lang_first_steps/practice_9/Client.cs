using static Shared;
public static class Client
{
    public static void RunPractice9()
    {
        Console.WriteLine(Task("Покажем числа от N до 1"));
        int someNumber = GetPositiveRandom(20);
        Console.WriteLine($"Число N = {someNumber}");
        Console.WriteLine(NumberToOneString(someNumber));

        Console.WriteLine(Task("Покажем числа от M до N"));
        var twoNumbers = GetFirstLessSecondNaturals("Введите два целых разных числа больше 0");
        Console.WriteLine(SumBetween(twoNumbers.Item1, twoNumbers.Item2));

        Console.WriteLine(Task("Покажем функцию Аккермана"));
        int firstNum = GetPositiveRandom(3);
        int secondNum = GetPositiveRandom(3);
        Console.WriteLine(AckermanResultToString(firstNum, secondNum, Ackerman(firstNum, secondNum)));
    }
}
