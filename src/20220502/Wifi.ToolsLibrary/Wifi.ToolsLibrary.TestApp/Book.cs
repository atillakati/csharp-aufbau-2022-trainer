using System;

namespace Wifi.ToolsLibrary.TestApp
{        
    internal class Book 
    { 
        public string Title { get; set; }

        public string Autor { get; set; }

        public decimal Price { get; set; }
        
        public int PublishYear { get; set; }

        public static Book Parse(string bookData)
        {
            //Titel, Autor  => CSV
            var parts = bookData.Split(',');
            if(parts.Length != 2)
            {
                throw new FormatException("Please provide data as comma separated values: eg. Title, Autor");
            }

            return new Book
            {
                Title = parts[0].Trim(),
                Autor = parts[1].Trim()
            };
        }
    }
}
