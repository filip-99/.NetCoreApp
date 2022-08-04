using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        // Najpre dodajemo kontekst fail, da bi omogućili rad sa bazom
        // Pošto koristimo Entity Framework Core zbog toga je ovakva struktura
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context=context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
