using BookWebEcommerce.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWebEcommerce.Models
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
		public virtual Author? Author { get; set; }

		public int PublisherId { get; set; }
		[ForeignKey("PublisherId")]
		public virtual Publisher? Publisher { get; set; }

		public int TranslatorId { get; set; }
		[ForeignKey("TranslatorId")]
		public virtual Translator? Translator { get; set; }
	}
}
