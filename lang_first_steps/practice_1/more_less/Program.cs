Console.WriteLine("Введите два числа, я подумаю и скажу, какое больше");
double a = double.Parse(Console.ReadLine());
double b = double.Parse(Console.ReadLine());
if (a != b)
{
    if (a > b)
    {
        Console.WriteLine("Первое число больше второго");
    }
    else
    {
        Console.WriteLine("Второе число больше первого");
    }
}
else
{
    Console.WriteLine("Числа равны");
}