using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fehlerbehandlung
{
    internal class Program
    {
        /*
            * Schreiben Sie eine Applikation, welches das Geburtsjahr des Users abfrägt.
            * Anschliessend soll das Alter berechnet und "schön" (farbig?) auf der Console 
            * ausgegeben werden.
            * 
            * Gestalten Sie die Abfrage fehlertolerant = Fehleingaben dürfen die Applikation
            * nicht vorzeitig beenden. Achten Sie auf eine klare User-Führung!
            */
        static void Main(string[] args)
        {           
            var geburtsjahr = 0;
            var alter = 0;
            bool inputNotValid = true;

            DisplayHeader("Altersberechnung V1.0", true);

            do
            {

                Console.Write("Bitte Geburtsjahr eingeben: ");
                try
                {
                    var input = Console.ReadLine();

                    if(string.IsNullOrEmpty(input) || input.Length < 4)
                    {
                        Console.WriteLine("ERROR: Ungültige Eingabe.");
                        continue;
                    }

                    geburtsjahr = int.Parse(input);
                    inputNotValid = false;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine($"Leider ungültige Eingabe: {ex.Message}");
                    inputNotValid = true;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"ERROR:{ex.Message}");
                    inputNotValid = true;
                }
                //finally
                //{
                //    Console.WriteLine("Hier bin ich!");
                //}
            } 
            while (inputNotValid);
            
            alter = DateTime.Now.Year - geburtsjahr;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Sie sind {alter} Jahre alt.");
            Console.ResetColor();
        }

        private static void DisplayHeader(string headerString, bool addNewLine)
        {
            Console.WriteLine(new string('#', Console.WindowWidth-1));

            var centerXPoint = (Console.WindowWidth - headerString.Length) / 2;
            Console.CursorLeft = centerXPoint;
            Console.WriteLine(headerString);

            Console.WriteLine(new string('#', Console.WindowWidth - 1));

            if (addNewLine)
            {
                Console.WriteLine();
            }
        }
    }
}
