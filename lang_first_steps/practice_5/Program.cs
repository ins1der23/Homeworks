using System;
using static Shared;
using static Even;
using static Odd;
using static Diff;
// Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

Console.WriteLine(Task("Сейчас посчитаем количество четных числе в таблице"));
int size = GetInteger("Введите размер таблицы для заполнения");
if (CompareLess(size, 1)) size = InputTill("Число меньше 1, не может быть размером таблицы", size, 1);
int[] someArray = CreateArray(size);
FillArrayRandom(someArray, 100, 1000);
Console.WriteLine(PrintArray(someArray));
Console.WriteLine("Количество четных чисел в таблице - {0}", CountEven(someArray));

// Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.

Console.WriteLine(Task("А сейчас посчитаем количество чисел в таблице, стоящих на нечетных позициях"));
int length = ArraySize("Введите размер таблицы для заполнения");
int[] customArray = CreateArray(length);
FillArrayRandom(customArray, -9, 10);
Console.WriteLine(PrintArray(customArray));
Console.WriteLine("Сумма элементов на нечетных позициях - {0}", SumOfOddPos(customArray));

// Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.

Console.WriteLine(Task("А сейчас найдем разницу между максимальным и минимальным числом в таблице"));
int quant = GetInteger("Введите размер таблицы для заполнения");
if (CompareLess(quant, 1)) quant = InputTill("Число меньше 1, не может быть размером таблицы", quant, 1);
double[] someSheet = CreateDblArray(quant);
FillDblArrayRandom(someSheet, -99, 100);
Console.WriteLine(PrintDblArray(someSheet));
Console.WriteLine("Разница между максимальным и минимлаьным числом - {0}", DiffMaxMin(someSheet));