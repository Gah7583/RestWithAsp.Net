using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Data
{
    public class RestWithAspDotNetContext : DbContext
    {
        public RestWithAspDotNetContext(DbContextOptions<RestWithAspDotNetContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
