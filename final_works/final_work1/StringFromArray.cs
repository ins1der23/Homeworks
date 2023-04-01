using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System;
public static class StringsFromArray
{
    /// <summary>
    /// Метод создания результирующего массива из элементов определенный длины исходного 
    /// массива"
    /// </summary>
    /// <param name="anyArray"> Исходный массив </param>
    /// <param name="symbolsNum"> Длина элемента </param>
    /// <returns> Результирующий массив </returns>
    public static string[] GetWords(this string[] anyArray, int symbolsNum = 3)
    {
        int counter = 0;
        int size = anyArray.Length;
        bool[] suitableI = new bool[size];
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
                if (counter == size - 1) break;
            }
        return result;
    }

    public static string[] GetWordsBad(this string[] anyArray, int symbolsNum = 3)
    {
        int counter = 0;
        int size = anyArray.Length;
        int i = 0;
        bool flag = anyArray[i].Length <= symbolsNum;
        for (i = 0; i < size; i++)
            if (anyArray[i].Length <= symbolsNum)
                counter++;
        string[] result = new string[counter];
        counter = 0;
        for (i = 0; i < size; i++)
            if (anyArray[i].Length <= symbolsNum)
            {
                result[counter] = anyArray[i];
                counter++;
                if (counter == size - 1) break;
            }
        return result;
    }
}