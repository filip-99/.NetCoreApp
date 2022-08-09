using System;
using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    // BookVM je ViewModel klasa koja sadrži deo podataka iz model klase Book.cs
    // Podaci u ovoj klasi su oni koje unosi korisnik, zato je izostavljen Id jer je identity i recimo datum unosa knjige u bazu, jer se uzima trenutni datum i korisnik ga ne unosi
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string Genre { get; set; }
        public int? Rate { get; set; }
        public string Cover { get; set; }

        // Pošto se veza više između Izdavača i Knjige nalazi na strani knjige, potrebno je dodati novi atribut u tabeli knjige, koji će predstavlja tog izdavača za datu knjigu
        public int PublisherId { get; set; }
        // Sa druge strane potrebno je dodati atribut za autora, jer je veza više na strani i knjige i autora (Foreign Key)
        // Ovo znači da i jedna knjiga može imati više autora, tako da dodajemo listu
        public List<int> AuthorId { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string Genre { get; set; }
        public int? Rate { get; set; }
        public string Cover { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
