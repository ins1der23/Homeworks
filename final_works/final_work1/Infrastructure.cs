using System;
public static class Infrastructure
{
    /// <summary>
    /// Метод ввода int числа с клавиатуры в заданном дипазоне
    /// </summary>
    /// <param name="startBound"> Нижняя граница диапазона </param>
    /// <param name="endBound"> Верхняя граница диапазона </param>
    /// <param name="message"> Приглашение пользователя к вводу числа </param>
    /// <returns> int число </returns>

    public static int BoundInput(this string message, int startBound = 1, int endBound = 10)
    {
        int num = 0;
        bool flag = true;
        bool check = true;
        do
        {
            Console.Write($"{message}: ");
            flag = int.TryParse(Console.ReadLine(), out num);
            check = (num >= startBound && num <= endBound);
            if (!check) Console.WriteLine("Число за пределами указанного диапазона");
        } while (!flag || !check);
        return num;
    }

    /// <summary>
    /// Метод создания string массива заданного размера
    /// </summary>
    /// <param name="size">Размер нового массива</param>
    /// <returns> Новый string массив </returns>
    public static string[] CreateStringArray(this int size)
    {
        return new string[size];
    }
    /// <summary>
    /// Оформление строки в кавычки
    /// </summary>
    /// <param name="word"> Строка </param>
    /// <returns> Строка в кавычках </returns>
    static string QuoteString(this string word)
    {
        return $"\"{word}\"";
    }

    /// <summary> Метод получения string от пользователя </summary>
    /// <param name="i"> Число, для отображения номера ввода </param>
    /// <returns> Заданную строку </returns> 
    public static string GetString(int i = 1)
    {
        string word = String.Empty;
        bool flag = true;
        do
        {
            Console.WriteLine($"Введите {i}-е символы");
            word = (Console.ReadLine());
            flag = !string.IsNullOrWhiteSpace(word);
        } while (!flag);
        return word;
    }

    /// <summary>
    /// Метод заполнение string массива 
    /// </summary>
    /// <param name="anyArray"> Массив для заполнения </param>
    /// <returns> Заполненный string массив </returns>
    public static string[] FillStringArray(this string[] anyArray)
    {
        int size = anyArray.Length;
        Console.WriteLine($"Введите любые символы {size} раз(а)");
        for (int i = 0; i < size; i++)
            anyArray[i] = GetString(i + 1);
        return anyArray;
    }

    /// <summary>
    /// Метод оформления и вывода в строку значений string массива
    /// </summary>
    /// <param name="anyArray"> Массив для вывода в строку </param>
    /// <param name="separator"> Символ разделяющий элиементы массива </param>
    /// <returns> Оформленная строка с элементами массива </returns>

    public static string ArrayToString(this string[] anyArray, char separator)
    {
        string word = String.Empty;
        string result = String.Empty;
        int size = anyArray.Length;
        for (int i = 0; i < size; i++)
        {
            if (i != size - 1) word = QuoteString(anyArray[i]) + separator;
            else word = QuoteString(anyArray[i]);
            result += word;
        }
        result = ($"[{result}]");
        return result;
    }
}


