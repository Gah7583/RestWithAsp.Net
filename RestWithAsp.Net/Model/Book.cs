using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Net.Model
{
    [Table("Books")]
    public class Book : BaseEntity
    {

        [Column("Title")]
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Column("Author")]
        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Column("Launch Date")]
        [Required]
        [Display(Name = "Launch Date")]
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }

        [Column("Price")]
        [Required]
        [Precision(20,2)]
        public decimal Price { get; set; }
    }
}
