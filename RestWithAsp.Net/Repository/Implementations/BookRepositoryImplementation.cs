using RestWithAsp.Net.Data;
using RestWithAsp.Net.Model;
using System;

namespace RestWithAsp.Net.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly RestWithAspDotNetContext _context;

        public BookRepositoryImplementation(RestWithAspDotNetContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public void Delete(int id)
        {
            var result = GetBookById(id);
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
        {
            return _context.Books.Any(book => book.Id.Equals(id));
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(book => book.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = GetBookById(book.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return book;
        }
    }
}
