﻿using RestWithAsp.Net.Data.Converter.Implementations;
using RestWithAsp.Net.Data.VO;
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
