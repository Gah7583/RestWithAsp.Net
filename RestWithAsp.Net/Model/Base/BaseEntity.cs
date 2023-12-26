using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Net.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
