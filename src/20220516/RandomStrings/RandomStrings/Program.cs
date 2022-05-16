using System;


namespace RandomStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new AdvRandom();

            Console.WriteLine(rnd.Next(1, 46));
            Console.WriteLine(rnd.Next(1, 46));

            Console.WriteLine(rnd.NextDouble()*10.0);
            Console.WriteLine(rnd.NextDouble() * 10.0);

            Console.WriteLine(rnd.NextString(15));
            Console.WriteLine(rnd.NextString(10));
        }
    }
}
