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

            var myBookList = new List<Book>();
            bool shouldRepeat = false;

            do
            {
                var book = GetNewBook();
                myBookList.Add(book);

                shouldRepeat = AskUser();
            }
            while (shouldRepeat);

            DisplayBookList(myBookList);
        }

        private static bool AskUser()
        {
            Console.Write("Noch ein Buch (j/n)? ");
            var input = Console.ReadLine();

            if (input.ToLower() == "j")
            {
                return true;
            }

            return false;
        }

        private static Book GetNewBook()
        {
            var book = new Book();

            Console.Write("Titel: ");
            book.Title = Console.ReadLine();
            Console.Write("Autor: ");
            book.Author = Console.ReadLine();
            Console.Write("Isbn:  ");
            book.Isbn = Console.ReadLine();

            book.Price = GetDecimal("Preis eingeben: ");            
            book.DateOfPublish = GetInt("Veröffentlicht am (yyyy): ");

            book.Genre = GetGenreType();

            return book;
        }

        private static decimal GetDecimal(string inputPrompt)
        {
            decimal inputValue = 0.0m;
            bool inputIsValid = false;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = decimal.Parse(Console.ReadLine());
                    inputIsValid = true;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ERROR: "+ ex.Message);
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }

        private static int GetInt(string inputPrompt)
        {
            int inputValue = 0;
            bool inputIsValid = false;

            do
            {
                try
                {
                    Console.Write(inputPrompt);
                    inputValue = int.Parse(Console.ReadLine());
                    inputIsValid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    inputIsValid = false;
                }
            }
            while (!inputIsValid);

            return inputValue;
        }

        private static BookGenre GetGenreType()
        {
            int number = 1;

            Console.WriteLine("\nBitte auswählen:");

            var possibleValues = Enum.GetNames(typeof(BookGenre));
            foreach (var item in possibleValues)
            {
                Console.WriteLine($"\t{number}:{item}");
                number++;
            }

            //Hint: Use this to write a generic enum input method... 
            //var intValues = Enum.GetValues(typeof(BookGenre)).Cast<int>().ToList();

            Console.Write("Ihre Wahl: ");
            int selection = int.Parse(Console.ReadLine());

            return (BookGenre)(selection - 1);
        }

        private static void DisplayBookList(List<Book> books)
        {
            List<BookEntity> myClassList = new List<BookEntity>();

            //map struct type into class types
            foreach (var book in books)
            {
                var bookEntity = new BookEntity
                {
                    Titel = book.Title,
                    Autor = book.Author,
                    DateOfPublish = book.DateOfPublish,
                    Isbn = book.Isbn,
                    Genre = book.Genre,
                    Price = book.Price
                };

                myClassList.Add(bookEntity);
            }

            //display list of classes
            ConsoleTableBuilder
                            .From(myClassList)
                            .ExportAndWriteLine(TableAligntment.Center);
        }
    }
}
