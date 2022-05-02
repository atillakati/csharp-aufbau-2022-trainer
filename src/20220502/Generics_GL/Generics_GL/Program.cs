using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_GL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialValue = -1;
            int elementCount = 15;


            var myNumbers = CreateIntArray(elementCount, int.MinValue);
            var dateList = CreateDateArray(elementCount, DateTime.Now);

            var numbers = CreateArray<DateTime>(elementCount, DateTime.Now);
            var numbers2 = CreateArray<decimal>(elementCount, 0.00m);

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers2.Count());            
        }
        

        private static T[] CreateArray<T>(int elementCount, T initialValue)
        {
            var array = new T[elementCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initialValue;
            }

            return array;
        }

        private static DateTime[] CreateDateArray(int elementCount, DateTime initialValue)
        {
            var array = new DateTime[elementCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initialValue;
            }

            return array;
        }

        private static int[] CreateIntArray(int elementCount, int initialValue)
        {
            var array = new int[elementCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = initialValue;
            }

            return array;
        }
    }
}
