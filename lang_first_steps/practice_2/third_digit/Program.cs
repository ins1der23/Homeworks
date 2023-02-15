// **Задача 13:** Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

int ToThreeDigit(int AnyNumber)
{
    if (AnyNumber > 100)
    {
        while (AnyNumber > 999)
        {
            AnyNumber = AnyNumber / 10;
        }
    }
    return AnyNumber % 10;
}
int SomeNumber = new Random().Next(1, 9999);
Console.WriteLine("Число = {0}", SomeNumber);
if (SomeNumber < 100) Console.WriteLine("Третьей цифры нет");
else Console.WriteLine("Третья цифра числа = {0},", ToThreeDigit(SomeNumber));
