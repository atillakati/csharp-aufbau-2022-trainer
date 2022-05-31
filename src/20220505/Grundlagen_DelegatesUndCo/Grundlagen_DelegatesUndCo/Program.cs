using System;
using System.Timers;

namespace Grundlagen_DelegatesUndCo
{
    public delegate void OutputHandler(string messageToDisplay);

    internal class Program
    {
        static void Main(string[] args)
        {
            OutputHandler handler = PrintMessage;
            handler = null;

            handler?.Invoke("Hallo Leute");

            if (handler != null)
            {
                handler("Hallo Leute");
            }
            

            PrintColoredMessage("Dies ist ein Test.", PrintMessageWithLines);

            //Timer tmr = new Timer();
            //tmr.Interval = 1000;

            //tmr.Elapsed += OnTimerElapsed;
            //tmr.Start();

            //while (true)
            //{

            //}
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            PrintMessage("Hi!");
        }

        static void PrintColoredMessage(string message, OutputHandler outputHandler)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Yellow;
            outputHandler(message);

            Console.ForegroundColor = oldColor;
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message.ToUpper());
        }

        static void PrintMessageWithLines(string message)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------------");
        }


    }
}
