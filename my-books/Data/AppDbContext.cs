using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    // Nasledili smo klasu DbContext što znači da možemo koristiti njene metode i ostalo za komunikaciju sa bazom
    public class AppDbContext : DbContext
    {
        // Kreiramo konstruktor i da bi uključio potrebne elemente u njega, treba da izgleda ovako:
        // Ova izvedena klasa imaće pristup osnovnoj klasi i svim njenim parametrima zato nam koristi base(options) uz konstruktor. Gde će mo pozivom ove klase imati pristup osnovnoj klasi, koja nam omogućava rad sa bazom
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Potrebno je sada da konfigurišemo ova 3 modela (Author.cs, Book.cs i Book_Author.cs) kako bi uspešno apdejtovali bazu
        // Ovo se konfiguriše korišćenjem Fluent API-ja za Entity Framework Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sada definišemo odnos između Book i Book_Author
            modelBuilder.Entity<Book_Author>()
                // HasOne - jedna Knjiga
                .HasOne(b => b.Book)
                // WithMany - Može imati više (više je na strani Book_Author)
                .WithMany(ba => ba.Book_Authors)
                // Sada definišemo javni ključ
                .HasForeignKey(bi => bi.BookId);

            // Sada isto ovako definišemo odnos između Author i Book_Author
            modelBuilder.Entity<Book_Author>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(ai => ai.AuthorId);
        }

        // Sada vršimo referenciranje model klase sa tabelom u bazi podataka
        // Promenjiva će biti tipa DbSet i nazvaćemo je kao tabelu u bazi Books. Sada možemo manipulisati tabelom uz pomoć ovog naziva "Books"
        public DbSet<Book> Books { get; set; }

        // Sada vršimo referenciranje modela klasa sa tabelama u bazi podataka, kao što je urađeno za Books
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    

    }
}