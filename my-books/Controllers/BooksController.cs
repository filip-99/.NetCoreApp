using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Implementiraćemo servis koji smo kreirali, a potom konfigurisali za ubacivanje podataka u bazu
        private BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService=booksService;
        }

        // Kreiramo HTTP metodu za prikaz svih knjiga u bazi
        // Nazvaćemo API krajnju tačku get-all-books
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        // Kreiramo sada API End-Point tj. krajnju tačku za vraćanje samo jedne knjige iz baze
        // Kroz HttpGet zahtev prosleđujemo id da bi dobili podatke o knjizi sa tim id-em
        // Bitno je da bude tačan naziv jer će API End-Point morati da mapira parametar sa parametrom u metodi
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        // Sada će mo implementirati EndPoint tj. krajnje tačke
        // Prva će biti HttpPost jer šaljemo podatke u bazu
        // Da bi osigurali da se radi baš o ovoj krajnjoj tački dodelićemo naziv
        [HttpPost("add-book-with-authors")]
        // Tip metode IActionResult || AddBook - naziv metode || [FromBody] zahtev tj. request će dostaviti podatke koji se prosleđuju ovom parametru book tipa BookVP
        // Prosleđeni parametar [FromBody]BookVM book znači da se očekuje pri unosu da se popune sva polja u klasi BookVM
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            // Ok() - ovo je samo jedan od tipova koje metoda može da vrati
            return Ok();
        }

        // API End-Point je HttpPut metod
        [HttpPut("update-book-by-id/{id}")]
        // Imaćemo metodu i 2 parametra, id koji se prosleđuje kroz url zahteva i podatke koje klijent šalje kao request tj. iz tela zahteva 
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updateBook = _booksService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        // Kreiramo zahtev za brisanje podataka iz baze
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok(_booksService);
        }

    }
}
