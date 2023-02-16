// **Задача 10:** Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает **вторую** цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

int SecondDigit(int Any3DgNumber)
{
    return Any3DgNumber / 10 % 10;
}

int ToNumber(string message)
{
    Console.Write(message);
    int result = int.Parse(Console.ReadLine());
    return result;
}

Console.WriteLine("Введите трехзначное число, увидите чудо");
int SomeNumber = ToNumber("Число = ");
while (SomeNumber < 100 || SomeNumber > 999)
{
    Console.WriteLine("Так вы чуда не увидите. Введите ТРЕХЗНАЧНОЕ число");
    SomeNumber = ToNumber("Число = ");
}
Console.WriteLine("Чудо = {0}", SecondDigit(SomeNumber));