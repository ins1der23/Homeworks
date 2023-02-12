Random rnd = new Random();
int a = rnd.Next(-100,101);
Console.WriteLine("A={0}",a);
if(a%2==0)
{
    Console.WriteLine("Число четное");
}
else
{
    Console.WriteLine("Число нечетное");
}