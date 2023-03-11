public static class RunDecreasingSort
{
    static int Partition(int[] anyArray, int start, int end)
    {
        int marker = start;
        for (int i = start; i <= end; i++)
        {
            if (anyArray[i] >= anyArray[end])
            {
                if (anyArray[i] != anyArray[marker])
                {
                    int temp = anyArray[marker];
                    anyArray[marker] = anyArray[i];
                    anyArray[i] = temp;
                }
                marker++;
            }
        }
        return marker - 1;
    }
    public static void DecreasingSort(int[] anyArray, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        int pivot = Partition(anyArray, start, end);
        DecreasingSort(anyArray, start, pivot - 1);
        DecreasingSort(anyArray, pivot + 1, end);
    }
}