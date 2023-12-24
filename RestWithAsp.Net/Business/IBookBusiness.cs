using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        List<Book> GetBooks();
        Book GetById(int id);
        void Delete(int id);

    }
}
