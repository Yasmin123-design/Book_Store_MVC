using System.ComponentModel.DataAnnotations;

namespace BOOKS_.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
