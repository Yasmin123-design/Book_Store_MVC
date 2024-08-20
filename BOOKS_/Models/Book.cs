using System.ComponentModel.DataAnnotations;
using BOOKS_.Models;
namespace BOOKS_.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public DateTime AddOn { get; set; }

        public Book()
        {
            AddOn = DateTime.Now;
        }
    }
}
