using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    // Dodata nova klasa, koja će nam koristiti za prikaz svih knjiga za određenog autora
    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
