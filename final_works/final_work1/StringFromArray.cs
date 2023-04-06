using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System;
public static class StringsFromArray
{
    /// <summary>
    /// Метод создания результирующего массива из элементов определенный длины исходного 
    /// массива
    /// </summary>
    /// <param name="anyArray"> Исходный массив </param>
    /// <param name="symbolsNum"> Длина элемента </param>
    /// <returns> Результирующий массив </returns>
    public static string[] GetWords(this string[] anyArray, int symbolsNum = 3)
    {
        int size = anyArray.Length;
        bool[] suitableI = new bool[size];
        int counter = 0;
        for (int i = 0; i < size; i++)
            if (anyArray[i].Length <= symbolsNum)
            {
                counter++;
                suitableI[i] = true;
            }
        string[] result = new string[counter];
        counter = 0;
        for (int i = 0; i < size; i++)
            if (suitableI[i])
            {
                result[counter] = anyArray[i];
                counter++;
                if (counter == result.Length) break;
            }
        return result;
    }
}