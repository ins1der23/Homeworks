Console.WriteLine("Введите число");
int n = int.Parse(Console.ReadLine());;
Console.WriteLine("Сейчас вы увидите магию");
if(n>0)
{
    if(n%2!=0)
    {
        n=n-1;
    }
    while(n>=2)
    {
        Console.WriteLine(n);
        n=n-2;
    }
}
else
{
    if(n%2!=0)
    {
        n=n+1;
    }
    while(n<=0)
    {
        Console.WriteLine(n);
        n=n+2;
    }
}