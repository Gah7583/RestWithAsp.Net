using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void Delete(int id);
        bool Exists(int id);
    }
}
