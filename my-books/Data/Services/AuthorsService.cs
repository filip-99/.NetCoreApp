using my_books.Data.Models;
using my_books.Data.ViewModels;
using System.Linq;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        // Najpre dodajemo kontekst fail, da bi omogućili rad sa bazom
        // Pošto koristimo Entity Framework Core zbog toga je ovakva struktura
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context=context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorId)
        {
            // Promenjiva _author dobija sledeću vrednost:
            // Pristupamo tabeli Authors, zadajemo uslov sa Where, parametar author se odnosi na tabelu celu, a author.Id se odnosi na kolonu
            // Ako u koloni Id postoji vrednost == prosleđenom parametru u funkciji, onda selektuj ga
            var _author = _context.Authors.Where(author => author.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                // Izvuči iz reda puno ime autora
                FullName=n.FullName,
                // Izvuči sve njegove knjige, tako što će da se pomoću promenjive Book_Authors uđe u klasu Book_Author
                // I pošto ona među atribute sadrži i Book koji referencira na klasu Book, pomoću njega će mo ući u klasu
                // Na ovaj način uzimamo naslove iz tabela, jer su klase povezane sa tabelama
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
