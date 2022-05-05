using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaUndLinq
{
    public delegate void DisplayHandler(string message);

    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayHandler handler;
            Func<string, bool> EinHandler;


            //klassischer Aufruf über Delegate
            handler = DisplayMessage;
            handler?.Invoke("Hallo Welt!");

            //anonyme Methoden
            handler = delegate (string msg)
            {
                //hier passiert was!
                Console.WriteLine(msg);
            };
            handler?.Invoke("Anonyme Methode ausführen...");

            //Lambda Expressions
            handler = (string msg) =>
            {
                Console.WriteLine("-----------------");
                Console.WriteLine(msg);
                Console.WriteLine("-----------------");
            };
            handler?.Invoke("Lambda Methode ausführen...");

            handler = (msg) => Console.WriteLine(msg);
            handler = x => Console.WriteLine(x);

            handler?.Invoke("Das ist das X");

            int[] zahlen = new[] { 2, 3, 5, 8, 9, 15, 20, 55, 59 };

            var gefilterteZahlen = Filter(zahlen, x => x > 10);
            gefilterteZahlen = Filter(zahlen, x => x % 2 == 0);
            gefilterteZahlen = Filter(zahlen, x => x < 20);

            //ohne Lambda!!!!
            gefilterteZahlen = Filter(zahlen, SmallerThan20 );

            //var res = zahlen.Where(x => x == 5);
            var res = zahlen.Select(x => "Zahl " + x.ToString());
        }

        private static bool SmallerThan20(int zahl)
        {
            return zahl < 20;            
        }
        
        static T[] Filter<T>(T[] data, Predicate<T> kriterium)
        {
            List<T> result = new List<T>();

            foreach (var item in data)
            {
                if (kriterium.Invoke(item))
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
