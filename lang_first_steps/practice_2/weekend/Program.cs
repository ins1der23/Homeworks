

// **Задача 15:** Напишите программу, которая принимает на вход цифру, обозначающую день недели, и проверяет, является ли этот день выходным.

// 6 -> да
// 7 -> да
// 1 -> нет

bool WeekendCheck(int DayNumber)
{
    return DayNumber > 5;
}

Console.WriteLine("Введите число, обозначающие день недели");
int CheckedNumber = int.Parse(Console.ReadLine());
while (CheckedNumber < 1 || CheckedNumber > 7)
{
    Console.WriteLine("Не является днем недели");
    Console.Write("Введите число еще раз ");
    CheckedNumber = int.Parse(Console.ReadLine());
}

if (WeekendCheck(CheckedNumber)) Console.WriteLine("Выходной");
else Console.WriteLine("Не выходной");

