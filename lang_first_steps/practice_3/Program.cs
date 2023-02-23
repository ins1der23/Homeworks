using System;
using System.Reflection;
using System.Data;
using static SharedMethods;
using static DistMethods;
using static TenetMethods;
using static CubesMethods;

// Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.

Console.WriteLine(Task("Проверить число на палиндром"));

int SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
while (SomeNumber < 10000 || SomeNumber > 99999)
{
    Console.WriteLine("Число не пятизначное...");
    SomeNumber = ToNumber("Введите пятизначное число для проверки: ");
}
if (TenetChecking(SomeNumber)) Console.WriteLine("НИЧЁСЕ!!! ПАЛИНДРОМ!!!");
else Console.WriteLine("НЕ ПАЛИНДРОМ...ГЛАВНОЕ, НЕ СДАВАТЬСЯ!");

// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.

Console.WriteLine(Task("Найти координаты между точками в 3D"));

Console.WriteLine("Введите кординаты точки A");
double[] APoint = CreateDblArray(3);
UserFilling(APoint);
Console.WriteLine("Введите кординаты точки B");
double[] BPoint = CreateDblArray(3);
UserFilling(BPoint);
Console.WriteLine("Координаты точки A (XYZ): {0}", PrintDblArray(APoint));
Console.WriteLine("Координаты точки B (XYZ): {0}", PrintDblArray(BPoint));
Console.WriteLine("Расстояние между точками = {0}", Math.Round(Dist3D(APoint, BPoint), 2));

// Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.

Console.WriteLine(Task("Показать таблицу кубов чисел от 1 до N"));
int NumberTo = ToNumber("Введите число N для вывода кубов чисел от 1 до N: ");
int[] CubesArray = ArrayFromN(NumberTo);
FillCubesToN(CubesArray, NumberTo);
Console.WriteLine(PrintArray(CubesArray));
