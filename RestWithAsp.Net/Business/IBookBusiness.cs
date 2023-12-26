using RestWithAsp.Net.Data.VO;

namespace RestWithAsp.Net.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        List<BookVO> GetBooks();
        BookVO GetById(int id);
        void Delete(int id);

    }
}
