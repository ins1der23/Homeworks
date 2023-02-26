using static Shared;

// Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2

int size = GetInteger("Введите размер таблицы для заполнения ");
if (CompareLess(size, 1)) size = InputTill("Число меньше 1, не может быть размером таблицы", size, 1);
int[] someArray = CreateArray(size);
FillArrayRandom(someArray,100,1000);
Console.WriteLine(PrintArray(someArray));
Console.WriteLine("Количество четных чисел в таблице - {0}", CountEven(someArray));

// Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.

// [3, 7, 23, 12] -> 19

// [-4, -6, 89, 6] -> 0

int length = GetInteger("Введите размер таблицы для заполнения ");
if (CompareLess(length, 1)) length = InputTill("Число меньше 1, не может быть размером таблицы", length, 1);
int[] customArray = CreateArray(length);
FillArrayRandom(customArray, -9,10);
Console.WriteLine(PrintArray(customArray));
Console.WriteLine("Сумма элементов на нечетных позициях - {0}", SumOfOddPos(customArray));