using System.ComponentModel.DataAnnotations;

namespace BookWebEcommerce.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description {get; set;}

        //Relationship
        public ICollection<Book>? Books { get; set; }
    }
}
