using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMoq.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books {get; }
        List<Book> GetAllBooks();
        Book GetBookById(int? id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        void Save();
    }
}