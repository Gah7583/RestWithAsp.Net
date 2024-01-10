using Microsoft.EntityFrameworkCore;
using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Model.Context
{
    public class RestWithAspDotNetContext : DbContext
    {
        public RestWithAspDotNetContext(DbContextOptions<RestWithAspDotNetContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Ayrton",
                    LastName = "Senna",
                    Address = "São Paulo - Brasil",
                    Gender = "Male"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Leonardo",
                    LastName = "da Vinci",
                    Address = "Anchiano - Italy",
                    Gender = "Male"
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Mahatma",
                    LastName = "Gandhi",
                    Address = "Porbandar - India",
                    Gender = "Male"
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Mohamed",
                    LastName = "Ali",
                    Address = "Kentuky - USA",
                    Gender = "Male"
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Nelson",
                    LastName = "Mandela",
                    Address = "Mvezo - South Africa",
                    Gender = "Male"
                }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Working effectively with legacy code",
                    Author = "Michael C. Feathers",
                    LaunchDate = new DateTime(2017, 11, 29, 13, 50, 05, 878),
                    Price = 49.00m
                },
                new Book
                {
                    Id = 2,
                    Title = "Design Patterns",
                    Author = "Ralph Johnson, Erich Gamma, John Vlissides e Richard Helm",
                    LaunchDate = new DateTime(2017, 11, 29, 15, 15, 13, 636),
                    Price = 77.00m
                },
                new Book
                {
                    Id = 3,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    LaunchDate = new DateTime(2009, 01, 10, 0, 0, 0, 0),
                    Price = 67.00m
                },
                new Book
                {
                    Id = 4,
                    Title = "JavaScript",
                    Author = "Crockford",
                    LaunchDate = new DateTime(2017, 11, 07, 15, 09, 01, 674),
                    Price = 67.00m
                },
                new Book
                {
                    Id = 5,
                    Title = "Refactoring",
                    Author = "Steve McConnell",
                    LaunchDate = new DateTime(2017, 11, 07, 15, 09, 01, 674),
                    Price = 58.00m
                }
                );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
