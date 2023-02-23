using System.Net.Http.Headers;
public class SharedMethods
{

    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }
       public static int GetInteger(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }
     public static int NaturalCheck(int check, string message)
    {
        while (check < 0)
        {
            Console.WriteLine(message);
            check = GetInteger("Введите еще раз ");
        }
        return check;
    }
}


