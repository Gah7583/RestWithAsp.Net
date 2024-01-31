using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Hypermedia.Utils;

namespace RestWithAsp.Net.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        List<BookVO> GetBooks();
        PageSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirection, int pageSize, int page);
        BookVO GetById(int id);
        void Delete(int id);

    }
}
