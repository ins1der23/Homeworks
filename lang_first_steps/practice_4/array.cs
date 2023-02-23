public class ArrayTask
{
    public static int[] CreateArray(int size)
    {
        return new int[size];
    }

    public static void FillArrayRandom(int[] collection, int bound1, int bound2)
    {
        for (int i = 0; i < collection.Length; i++)
        {
            collection[i] = new Random().Next(bound1, bound2);
        }
    }

    public static string PrintArray(int[] someArray)
    {
        string output = String.Empty;
        for (int i = 0; i < someArray.Length; i++)
        {
            output = output + " " + someArray[i];
        }

        return output;
    }
}