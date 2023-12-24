using RestWithAsp.Net.Model;
using RestWithAsp.Net.Repository;

namespace RestWithAsp.Net.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Book> GetBooks()
        {
            return _repository.GetAllBooks();
        }

        public Book GetById(int id)
        {
            return _repository.GetBookById(id);
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
