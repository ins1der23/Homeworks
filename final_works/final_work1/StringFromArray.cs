using System.ComponentModel;
using System.Data;
using System;
public static class StringsFromArray
{

    static int[] CreateIntArray(this int size)
    {
        return new int[size];
    }

    public static string[] GetWords(this string[] anyArray, int symbolsNum = 3)
    {
        int counter = 0;
        foreach (var word in anyArray) if (word.Length <= symbolsNum) counter++;
        string[] result = counter.CreateStringArray();
        counter = 0;
        foreach (var word in anyArray)
            if (word.Length <= symbolsNum)
            {
                result[counter] = word;
                counter++;
            }
        return result;
    }
}