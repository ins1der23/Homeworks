using System;
// Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.

string FromNumberTo1(int anyNumber)
{
    if (anyNumber == 1) return $"{anyNumber} ";
    return $"{anyNumber} " + FromNumberTo1(anyNumber - 1);
}

Console.WriteLine(FromNumberTo1(10));
