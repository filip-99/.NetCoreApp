using System.Collections.Generic;

namespace my_books.Data.Models
{
    // Kreirali smo model klasu za Izdavača
    public class Publisher
    {
        // Najpre definišemo atribute, koji će predstavljati kolone za tabelu Publishers
        public int Id { get; set; }
        public string Name { get; set; }

        // Nakon toga definišemo svojstva tj. odnos između modela Publisher i Book
        // Kreiramo atribut tipa List koji sadrži više knjiga, jer izdavač može imati više izdatih knjiga
        public List<Book> Books { get; set; }
    }
}
