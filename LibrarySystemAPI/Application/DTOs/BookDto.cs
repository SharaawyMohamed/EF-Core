using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Range(1450, 2100)]
        public int PublicationYear { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{10}")]
        public string ISBN { get; set; }
    }

}
