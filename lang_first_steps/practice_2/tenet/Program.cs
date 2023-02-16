// **Задача 21:** Программа проверяет пятизначное число на палиндром

bool TenetChecking(int AnyNumber)
{
    return AnyNumber / 10000 == AnyNumber % 10 && AnyNumber / 1000 % 10 == AnyNumber % 100 / 10;
}

int ToNumber(string message)
{
Console.Write(message);
int result = int.Parse(Console.ReadLine());
return result;
}

int SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
while (SomeNumber < 10000 || SomeNumber > 99999)
{
    Console.WriteLine("Число не пятизначное...");
    SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
}
if (TenetChecking(SomeNumber)) Console.WriteLine("АФИГЕТЬ!!! ПАЛИНДРОМ!!!");
else Console.WriteLine("ГЛАВНОЕ, НЕ СДАВАТЬСЯ...");