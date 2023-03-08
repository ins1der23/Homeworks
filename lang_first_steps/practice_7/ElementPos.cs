public static class ElementPosition
{
    public static (int, int) PositionCheck(int rows, int columns)
    {
        int input1 = Shared.GetInteger("Введите номер строки искомой позиции");
        int input2 = Shared.GetInteger("Введите номер столбца искомой позиции");
        bool flag = false;
        flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        while (flag)
        {
            Console.WriteLine("Указанной позиции нет в массиве");
            input1 = Shared.GetInteger("Введите еще раз номер строки");
            input2 = Shared.GetInteger("Введите еще раз номер столбца");
            flag = (input1 > rows || input1 < 1 || input2 > columns || input2 < 1);
        }
        return (input1, input2);
    }
    public static int NumToIndex(int n)
    {
        return n - 1;
    }

}