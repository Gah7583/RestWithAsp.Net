using RestWithAsp.Net.Data.Converter.Contract;
using RestWithAsp.Net.Data.VO;
using RestWithAsp.Net.Model;

namespace RestWithAsp.Net.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
