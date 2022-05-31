using System;

namespace Wifi.ToolsLibrary.TestApp
{
    internal class Book 
    {
        public string Titel { get; set; }
        public string Autor { get; set; }

        /// <summary>
        /// Die Parse Methode implementiert für den Datentyp Book
        /// </summary>
        /// <param name="bookString">Format: Titel, Autor (comma seperated)</param>
        /// <returns>A new instance of Book with provided data</returns>
        /// <exception cref="FormatException">Occures, when provided data could not be parsed.</exception>
        public static Book Parse(string bookString)
        {
            var parts = bookString.Split(',');
            if(parts.Length == 2)
            {
                return new Book { Autor = parts[1].Trim(), Titel = parts[0].Trim() };
            }

            throw new FormatException("Please enter for Book the titel, autor as string.");
        }
    }
}
