using static SharedMethods;
using static PowTask;
using static SumOfDigitsTask;
using static ArrayTask;

// Задача 25: Напишите метод, который принимает на вход два числа (A и B) и возводит число A в натуральную степень B.
// нельзя использовать Math.Pow
Console.WriteLine(Task("Возведем число A в натуральную степень B"));
double someNumber = GetDouble("Введите число A ");
int pow = GetInteger("Введите степень B (натуральное число) ");
pow = NaturalCheck(pow, "Число не натуральное");
Console.WriteLine("{0} в степени {1} равно {2}", someNumber, pow, ToPow(someNumber, pow));

// Задача 27: Напишите метод, который принимает на вход число и выдаёт сумму цифр в числе.
Console.WriteLine(Task("Посчитаем сумму цифр в числе"));
int theNumber = Math.Abs(GetInteger("Введите число "));
Console.WriteLine("Сумма цифр числа равна {0}", SumOfDigits(theNumber));

// Задача 29: Напишите метод, который задаёт массив из N элементов и выводит их на экран.

Console.WriteLine(Task("Заполним таблицу случайными числами"));
int size = GetInteger("Введите количество чисел в таблице ");
int[] sheet = CreateArray(size);
int start = GetInteger("Укажите нижнюю границу диапазона чисел в таблице ");
int finish = GetInteger("Укажите верхнюю границу диапазона чисел в таблице ");
FillArrayRandom(sheet, start, finish);
System.Console.WriteLine(PrintArray(sheet));
