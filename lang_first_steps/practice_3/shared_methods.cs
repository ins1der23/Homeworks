public class SharedMethods
{
    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + " " + "А сейчас можно " + message + "!" + Environment.NewLine + " ";
    }

    public static int ToNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }
}

