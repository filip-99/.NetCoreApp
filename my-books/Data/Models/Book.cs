using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        // Zatim atribut koji proverava da li je knjiga pročitana
        public bool IsRead { get; set; }
        // Zatim ako je označena pročitanom potrebno je da navedemo datum, ali i ne moramo(zato nam služi znak ?)
        public DateTime? DateRead { get; set; }
        public string Genre { get; set; }
        // Zatim imamo polje za ocenu pročitane knjige, koje je takođe opciono, jer možda je nismo pročitali
        public int? Rate { get; set; }
        // Zatim sve knjige će imati naslovnu sliku ili kover
        public string Cover { get; set; }
        // Zatim će mo imati datum i vreme, kada smo knjigu dodali u svojoj kolekciji
        public DateTime DateAdded { get; set; }


        // Nakon toga definišemo svojstva tj. odnos sa model klasom Publisher
        // Knjiga može imati samo jednog izdavača, pa će imati kao atribut njegov ID koje će predstavljati preneseni ključ (FOREIGN KEY)
        public int PublisherId { get; set; }
        // Pošto možemo imati samo jednog Publishera tj. izdavača za knjigu, definisaćemo jedan parametar tipa Publisher, a ne listu, jer to bi značilo više Publishera
        public Publisher Publisher { get; set; }

        // Sada navigiramo model klasu Book sa model kalsom Author.cs, pa pošto je odnos više prema više iskoristićemo zajedničku klasu Book_Author.cs
        public List<Book_Author> Book_Authors { get; set; }

    }
}
