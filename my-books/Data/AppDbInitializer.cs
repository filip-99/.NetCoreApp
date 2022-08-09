using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    // Ovu klasu će mo koristiti da preko nje ubacujemo podatke u bazu
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // Osiguravamo da će se konekcija sa bazom zatvoriti van ovih zagrada vitičastih
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Sada kreiramo promenjivu i deklarišemo je kao kontekst. Što nam omogućava rad sa bazom podataka
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                // Sada uz pomoć konteksta proveravamo da li u bazi ima podataka tj. knjiga
                // Tj. Da li nema knjiga. Ako nema dodaćemo
                if (!context.Books.Any())
                {
                    // Pošto želimo da unesemo više od jedne knjige u bazu, potrebno je da dodamo opseg tj. ovaj AddRange metod
                    context.Books.AddRange(new Book()
                    {
                        // Id se ne dodaje jer je identity, pa će samo da krene od 1 kako dodajemo knjige u tabelu

                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        // Za datum kada je knjiga pročitana stavićemo -> današnji datum (znači gleda se datum u trenutku kada se ova knjiga unosi u bazu oduzmi 10 dana)
                        DateRead = DateTime.Now.AddDays(-10),
                        Genre = "Biography",
                        Rate = 4,
                        Cover = "https...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Cover = "https...",
                        DateAdded = DateTime.Now
                    });
                    // Takođe da bi smo sačuvali ovaj niz moramo sačuvati ovaj kontekst
                    context.SaveChanges();
                }

            }
        }
    }
}
