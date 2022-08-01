using System;

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
        public string Author { get; set; }
        public int? Rate { get; set; }
        public string Cover { get; set; }
    }
}
