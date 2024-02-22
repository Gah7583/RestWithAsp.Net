using RestWithAsp.Net.Data.Converter.Implementations;
using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Hypermedia.Utils;
using RestWithAsp.Net.Model;
using RestWithAsp.Net.Repository.Generic;

namespace RestWithAsp.Net.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public PageSearchVO<BookVO> FindWithPagedSearch(string? title, string sortDirection, int pageSize, int page)
        {
            var sort = !string.IsNullOrWhiteSpace(sortDirection) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = pageSize < 1 ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"SELECT * FROM BOOKS B WHERE 1 = 1";
            if (!string.IsNullOrWhiteSpace(title)) query += $" AND B.[TITLE] LIKE '%{title}%'";
            query += $" ORDER BY B.[TITLE] {sort} OFFSET {offset} ROWS FETCH NEXT {size} ROWS ONLY";

            string countQuery = @"SELECT COUNT(*) FROM BOOKS B WHERE 1 = 1";
            if (!string.IsNullOrWhiteSpace(title)) query += $" AND B.[TITLE] LIKE '%{title}%'";

            var books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PageSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public List<BookVO> GetBooks()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO GetById(int id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }
    }
}
