using BookEcommerce.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookEcommerce.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public double Price { get; set; }

        [Display(Name = "ImageURL")]
        public string ImageURL { get; set; }

        public BookCategory Category { get; set; }

        //Relationship
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public int TranslatorId { get; set; }
        [ForeignKey("TranslatorId")]
        public Translator Translator { get; set; }
    }
}
