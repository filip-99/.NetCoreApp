using my_books.Data.Models;
using my_books.Data.ViewModels;

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
    }
}
