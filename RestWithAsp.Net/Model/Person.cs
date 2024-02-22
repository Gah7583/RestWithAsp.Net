using RestWithAsp.Net.Model.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Net.Model
{
    [Table("Persons")]
    public class Person : BaseEntity
    {
        [Column("First Name")]
        [Required]
        [Display(Name = "First Name")]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Column("Last Name")]
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(80)]
        public string LastName { get; set; }

        [Column("Address")]
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Column("Gender")]
        [Required]
        [StringLength(6)]
        public string Gender { get; set; }

        [Column("Enabled")]
        [DefaultValue (true)]
        [Required]
        public bool Enabled { get; set; }
    }
}
