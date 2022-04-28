using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WertUndReferenzTypen
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Punkt p1 = new Punkt();
            p1.X = 5;
            p1.Y = 10;

            Punkt p2 = new Punkt();

            //werte kopieren (?)
            p2 = p1;

            p1.X = 7;
            p1.Y = 2;

            Console.WriteLine($"P1({p1.X}/{p1.Y})");
            Console.WriteLine($"P2({p2.X}/{p2.Y})");

            DisplayPunkt(p1);
            Console.WriteLine($"P1({p1.X}/{p1.Y})");

            p1 = GetNewPointValues(p1);

        }

        private static void DisplayPunkt(Punkt point)
        {
            if(point.X > 100)
            {
                point.X = 99;
            }

            Console.WriteLine($"Punkt wird dargestellt: p({point.X}/{point.Y})");
        }
    }
}
