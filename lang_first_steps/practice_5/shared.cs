public class Shared
{
    public static string Task(string message)
    {
        string output = String.Empty;
        return output + Environment.NewLine + message.ToUpper() + ".";
    }
 
    public static int GetInteger(string text)
  {
    int num = 0;
    bool flag = true;
    do
    {
      Console.Write($"{text}: ");
      flag = int.TryParse(Console.ReadLine(), out num);
    } while (!flag);
    return num;
  }

    public static bool CompareLess(int anyNumber, int bound)
    {
        return anyNumber < bound;
    }

    public static int InputTill(string message, int someNumber, int border)
    {
        while (CompareLess(someNumber, border))
        {
            Console.WriteLine(message);
            someNumber = GetInteger("Введите еще раз");
        }
        return someNumber;
    }
    public static int[] CreateArray(int size)
    {
        return new int[size];
    }

    public static void FillArrayRandom(int[] anyArray, int bound1, int bound2)
    {
        for (int i = 0; i < anyArray.Length; i++)
        {
            anyArray[i] = new Random().Next(bound1, bound2);
        }
    }
    public static string PrintArray(int[] someArray)
    {
         
    return $"[{String.Join(' ', someArray)}]";
    }
}