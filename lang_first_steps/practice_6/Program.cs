using System;
using static Shared;
using static Point;
using static Count;

// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.

Console.WriteLine(Task("Посчитаем сколько чисел больше 0 ввёл пользователь"));
int size = GetInteger("Введите общее количество чисел");
size = RangeForNumber(size, 1, 20, "Слишком малое или большое количество чисел");
int[] someArray = CreateArray(size);
Console.WriteLine($"Введите {size} чисел");
FillArrayRecursive(someArray, 0);
Console.WriteLine(ArrayToString(someArray));
Console.WriteLine(CountPositiveRecursive(someArray, 0, 0));


// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
Console.WriteLine(Task("Найдем пересчение двух прямы заданных уравнениеми вида y = kx+b"));
double kx1 = GetDouble("Введите коэфициент k1");
double kx2 = GetDouble("Введите коэфициент k2");
double b1 = GetDouble("Введите число b1");
double b2 = GetDouble("Введите число b2");
double ky1 = ReturnDouble(1);
double ky2 = ReturnDouble(1);
if (PositiveCheck(b1)) kx1 = -kx1; else ky1 = -ky1;
if (PositiveCheck(b2)) kx2 = -kx2; else ky2 = -ky2;
double[,] matrixK = { { kx1, ky1 }, { kx2, ky2 } };
double[,] matrixB = { { b1 }, { b2 } };
if (ParallelCheck(kx1, kx2)) Console.WriteLine("Прямые не пересекаются");
else
{
    double[,] crossPoint = CrossPoint(matrixK, matrixB);
    System.Console.WriteLine(ShowMatrix(crossPoint));
}





