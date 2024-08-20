using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BOOKS_.Models
{
    public class Reader
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Image { get; set; }

        [Remote("Limit","Reader",ErrorMessage ="Age is invalid,Age Must Be 18 Or More!!!")]
        public int Age { get; set; }
    }
}
