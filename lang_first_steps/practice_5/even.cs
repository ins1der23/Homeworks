public class Even
{
    public static int CountEven(int[] anyArray)
    {
        int count = 0;
        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] % 2 == 0) count++;
        }
        return count;
    }
}