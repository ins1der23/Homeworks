using System;
public class Shared
{
    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }

    public static double RoundTo2(double num)
    {
        return Math.Round(num, 2);
    }
   
  





}





