static class Utils // статические утилиты используемые в программе
{




    public static List<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>().ToList<T>(); // преобразование Enum в список 
    public static int GetInteger(string textString) // получение int значения с клавиатуры
    {
        bool flag;
        int choice;
        do
        {
            Console.Write($"{textString}: ");
            flag = int.TryParse(Console.ReadLine(), out choice) || choice == 0;
            Console.Clear();
        } while (!flag);
        return choice;
    }


    public static DateTime GetDate(string textString, bool allowEmpty = false)
    {
        Console.Clear();
        string output;
        DateTime date = DateTime.MinValue;
        bool flag;
        do
        {
            Console.Write($"{textString}: ");
            output = string.Empty + Console.ReadLine();
            if (allowEmpty && output.Equals(string.Empty)) flag = true;
            else flag = DateTime.TryParse(output, out date);
        } while (!flag);
        return date;
    }

    public static string GetString(string textString, bool allowEmpty = false) // получение string с клавиатуры c возможностбъю выбора получения пустой строки
    {
        Console.Clear();
        string output;
        bool flag = true;
        do
        {
            Console.Write($"{textString}: ");
            output = string.Empty + Console.ReadLine();
            if (!allowEmpty && output.Equals(string.Empty)) flag = false;
            foreach (char ch in output)
            {
                if (!char.IsLetter(ch)) flag = false;
            }
        } while (!flag);
        return output;
    }
}