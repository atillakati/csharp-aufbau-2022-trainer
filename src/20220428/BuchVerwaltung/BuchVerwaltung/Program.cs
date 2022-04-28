using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchVerwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Schreiben Sie eine Applikation mit der Bücher verwaltet werden können.
             * Die Bücher sollen über einen eigenen Datentyp (struct) abgebildet werden.
             * Folgende Information über ein Buch sollen verwaltet werden:
             * 
             * - Titel
             * - Autor
             * - ErscheinungsJahr
             * - ISBN
             * - Preis
             * - Genre
             * 
             * Was kann die Applikation:
             * 
             * - Bücher einlesen
             * - Bücher (schön) darstellen
             *             
             * */

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Die unendliche Geschichte",
                    Author = "Michael Ende",
                    DateOfPublish=1980,
                    Genre = BookGenre.SienceFiction,
                    Isbn ="X-4354863215-9",
                    Price = 32.5m
                },
                new Book
                {
                    Title ="Die Nadel",
                    Author = "Ken Follet",
                    DateOfPublish=1970,
                    Isbn="X-32154656544-9",
                    Price = 55.90m,
                    Genre = BookGenre.Crime
                }
            };

            Console.WriteLine("\nMeine Bücher:\n");

            ConsoleTableBuilder.From(books)
                               .WithFormat(ConsoleTableBuilderFormat.Default)
                               .ExportAndWriteLine(TableAligntment.Center);

        }
    }
}
