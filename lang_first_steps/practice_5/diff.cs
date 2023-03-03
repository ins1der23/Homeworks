public class Diff
{
public static double[] CreateDblArray(int size)
    {
        return new double[size];
    }
    public static void FillDblArrayRandom(double[] anyArray, int bound1, int bound2)
    {
        for (int i = 0; i < anyArray.Length; i++)
        {
            anyArray[i] = new Random().Next(bound1 * 100, bound2 * 100) / 100.0;
        }
    }
    public static string PrintDblArray(double[] someArray)
    {
         return $"[{String.Join("  ", someArray)}]";
    }
    public static double DiffMaxMin(double[] anyArray)
    {
        int minI = 0;
        int maxI = 0;
        for (int i = 1; i < anyArray.Length; i++)
        {
            if (anyArray[i] > anyArray[maxI]) maxI = i;
            else if (anyArray[i] < anyArray[minI]) minI = i;
        }
        return anyArray[maxI] - anyArray[minI];
    }
}