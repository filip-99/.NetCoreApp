namespace my_books.Data.Models
{
    // Zajednička model klasa za model Author i Book
    public class Book_Author
    {
        // Pošto nisu dovoljni samo preneseni ključevi od model Author i Book, dodajemo ID za ovu model klasu
        public int Id { get; set; }

        // Dodajemo svojstva navigacije tj. referencu ka modelima u zavisnosti od odnosa za model klase Author i Book
        // Prvo imamo promenjivu koja će predstavljati preneseni ključ
        public int BookId { get; set; }
        // Zatim promenjivu koja ukazuje na to da postoji veza između ove model klase i klase Book
        public Book Book { get; set; }

        // Takođe uradimo isto i za Autora
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
