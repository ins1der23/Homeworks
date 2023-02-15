// **Задача 10:** Напишите программу, которая принимает на вход трёхзначное число и на выходе показывает **вторую** цифру этого числа.
// 456 -> 5
// 782 -> 8
// 918 -> 1

int SecondDigit(int Any3DgNumber)
{
    return Any3DgNumber / 10 % 10;
}

Console.WriteLine("Введите трехзначноечисло, увидите чудо");
Console.Write("Число = ");
int SomeNumber = int.Parse(Console.ReadLine());
while (SomeNumber < 100 || SomeNumber > 999)
{
    Console.WriteLine("Так вы чуда не увидите. Введите ТРЕХЗНАЧНОЕ число");
    Console.Write("Число = ");
    SomeNumber = int.Parse(Console.ReadLine());
}
Console.WriteLine("Чудо = {0}", SecondDigit(SomeNumber));