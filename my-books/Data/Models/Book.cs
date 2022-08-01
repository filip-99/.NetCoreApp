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
        public string Author { get; set; }
        // Zatim imamo polje za ocenu pročitane knjige, koje je takođe opciono, jer možda je nismo pročitali
        public int? Rate { get; set; }
        // Zatim sve knjige će imati naslovnu sliku ili kover
        public string Cover { get; set; }
        // Zatim će mo imati datum i vreme, kada smo knjigu dodali u svojoj kolekciji
        public DateTime DateAdded { get; set; }
    }
}
