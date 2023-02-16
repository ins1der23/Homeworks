// **Задача 21:** Программа проверяет пятизначное число на палиндром

bool TenetChecking(int AnyNumber)
{
    return AnyNumber / 10000 == AnyNumber % 10 && AnyNumber / 1000 % 10 == AnyNumber % 100 / 10;
}

Console.Write("Введите пятизначное число для проверки: ");
int SomeNumber = int.Parse(Console.ReadLine());
while (SomeNumber < 10000 || SomeNumber > 99999)
{
    Console.WriteLine("Число не пятизначное...");
    Console.Write("Введите еще раз ");
    SomeNumber = int.Parse(Console.ReadLine());
}
if (TenetChecking(SomeNumber)) Console.WriteLine("АФИГЕТЬ!!! ПАЛИНДРОМ!!!");
else Console.WriteLine("ГЛАВНОЕ, НЕ СДАВАТЬСЯ...");