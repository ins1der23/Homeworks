Random rnd = new Random();
double a = rnd.Next(1,100);
double b = rnd.Next(1,100);
double c = rnd.Next(1,100);
Console.WriteLine("A={0}, B={1}, C={2}.", a, b, c);
if (a == b)
{
    if (b == c)
    {
        Console.WriteLine("no max");
    }
    else
    {
        if (b > c)
        {
            Console.WriteLine("A and B are max");
        }
        else
        {
            Console.WriteLine("C is max");
        }
    }
}
else
{
    if (b == c)
    {
        if (b > a)
        {
            Console.WriteLine("B and C are max");
        }
        else
        {
            Console.WriteLine("A is max");
        }
    }
    else
    {
        if (a == c)
        {
            if (a > b)
            {
                Console.WriteLine("A and C are max");
            }
            else
            {
                Console.WriteLine("B is max");
            }
        }
        else
        {
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine("A is max");
                }
                else
                {
                    Console.WriteLine("C is max");
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine("B is max");
                }
                else
                {
                    Console.WriteLine("C is max");
                }
            }
        }
    }
}