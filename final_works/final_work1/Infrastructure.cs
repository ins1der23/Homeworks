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
    /// Метод создания массива строк заданного размера
    /// </summary>
    /// <param name="size">Размер нового массива</param>
    /// <returns>Новый str массив</returns>
    public static string[] CreateStringArray(this int size)
    {
        return new string[size];
    }

    /// <summary>
    /// Заполнение str массива 
    /// </summary>
    /// <param name="anyArray"> Массив для заполнения </param>
    /// <returns> void </returns>

    public static void FillStringArray(this string[] anyArray)
    {
        int size = anyArray.Length;
        for (int i = 0; i < size; i++)
            anyArray[i] = Console.ReadLine();
    }
}

