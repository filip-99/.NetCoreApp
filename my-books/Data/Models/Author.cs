namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string fullName { get; set; }

        // Dodajemo navigaciona svojstva, ali pre toga potrebno je da kreiramo zajednički model za Autora i Knjihu
    }
}
