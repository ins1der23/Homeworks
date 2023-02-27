public class Odd
{
   public static int SumOfOddPos(int[] anyArray)
    {
        int sum = 0;
        for (int i = 1; i < anyArray.Length; i = i + 2)
        {
            sum = sum + anyArray[i];
        }
        return sum;
    }
}