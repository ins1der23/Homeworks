static class Utils
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
    
    
    public static DateTime GetDate(string text)
    {
        Console.Clear();
        DateTime date = new();
        bool flag = true;
        do
        {
            Console.Write($"{text}: ");
            flag = DateTime.TryParse(Console.ReadLine(), out date);
        } while (!flag);
        return date;
    }

     public static string GetString(string textString) // получение заполненной string с клавиатуры
    {
        Console.Clear();
        string output;
        bool flag;
        do
        {
            Console.Write($"{textString}: ");

            output = string.Empty + Console.ReadLine();
            if (output.Equals(string.Empty)) flag = false;
            else
            {
                flag = true;
                foreach (char ch in output)
                {
                    if (!char.IsLetter(ch)) flag = false;
                }
            }
        } while (!flag);
        return output;
    }

}