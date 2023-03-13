public static class MinLine
{
    // получение двух разных случайных чисел
    public static (int, int) NotEqualRandoms()
    {
        int firstNum = 0;
        int secondNum = 0;
        bool flag = true;
        flag = (firstNum == secondNum);
        do
        {
            firstNum = new Random().Next(2,21);
            secondNum = new Random().Next(2,21);
            flag = (firstNum == secondNum);
            return (firstNum, secondNum);
        } while (true);
    }







}
