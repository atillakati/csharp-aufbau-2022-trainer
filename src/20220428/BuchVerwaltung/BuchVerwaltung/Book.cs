using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchVerwaltung
{
    internal struct Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int DateOfPublish { get; set; }
        public string Isbn { get; set; }
        public BookGenre Genre { get; set; }
    }
}
