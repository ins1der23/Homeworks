
// **Задача 13:** Напишите программу, которая выводит третью цифру заданного числа или сообщает, что третьей цифры нет.
// 645 -> 5
// 78 -> третьей цифры нет
// 32679 -> 6

int RandomNumber()
{
    return new Random().Next(1, 9999);
}

string PrintNumber(int AnyNumber)
{
    string output = String.Empty;
    return output + AnyNumber + " ";
    }

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

int SomeNumber = RandomNumber();

Console.WriteLine(PrintNumber(SomeNumber));
if (SomeNumber < 100) Console.WriteLine("Третьей цифры нет");
else Console.WriteLine("Третья цифра числа = {0},", ToThreeDigit(SomeNumber));




