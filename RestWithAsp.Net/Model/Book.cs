using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Net.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Launch Date")]
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        [Required]
        [Precision(20,2)]
        public decimal Price { get; set; }
    }
}
