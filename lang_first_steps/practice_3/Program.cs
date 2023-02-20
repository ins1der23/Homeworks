using System.Data;
using static SharedMethods;
using static DistMethods;
using static TenetMethods;


// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.

Console.WriteLine(Task("проверить число на палиндром"));

int SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
while (SomeNumber < 10000 || SomeNumber > 99999)
{
    Console.WriteLine("Число не пятизначное...");
    SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
}
if (TenetChecking(SomeNumber)) Console.WriteLine("НИЧЁСЕ!!! ПАЛИНДРОМ!!!");
else Console.WriteLine("НЕ ПАЛИНДРОМ...ГЛАВНОЕ, НЕ СДАВАТЬСЯ!");

// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
Console.WriteLine(Task("найти координты между точками в 3D"));

Console.WriteLine("Введите кординаты точки A");
double[] APoint = CreateArray(3);
UserFilling(APoint);
Console.WriteLine("Введите кординаты точки B");
double[] BPoint = CreateArray(3);
UserFilling(BPoint);
Console.WriteLine("Координаты точки A (XYZ): {0}", PrintArray(APoint));
Console.WriteLine("Координаты точки B (XYZ): {0}", PrintArray(BPoint));
Console.WriteLine("Расстояние между точками = {0}", Math.Round(Dist3D(APoint, BPoint), 2));


// Задача 23
// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
// 3 -> 1, 8, 27
// // 5 -> 1, 8, 27, 64, 125

// 1. Ввод числа с клавиатуры
// 2. Расчет кубов числа 
// 3. вывод значений

// Задача 21

// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53






