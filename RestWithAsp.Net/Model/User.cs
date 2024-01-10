using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAsp.Net.Model
{
    [Table("Users")]
    public class User
    {
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("User Name")]
        public string UserName { get; set; }

        [Column("Full Name")]
        public string FullName { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Refresh Token")]
        public string? RefreshToken { get; set; }

        [Column("Refresh Token Expiry Time")]
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
