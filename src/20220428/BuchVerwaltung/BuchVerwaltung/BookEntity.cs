namespace BuchVerwaltung
{
    internal class BookEntity
    {
        public string Titel { get; internal set; }
        public string Autor { get; internal set; }
        public int DateOfPublish { get; internal set; }
        public string Isbn { get; internal set; }
        public BookGenre Genre { get; internal set; }
        public decimal Price { get; internal set; }
    }
}