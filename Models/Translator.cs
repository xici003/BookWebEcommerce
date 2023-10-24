using System.ComponentModel.DataAnnotations;

namespace BookWebEcommerce.Models
{
    public class Translator
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Genre { get; set; }
        public string Bio { get; set; }

        //Relationship
        public ICollection<Book> Books { get; set; }
    }
}
