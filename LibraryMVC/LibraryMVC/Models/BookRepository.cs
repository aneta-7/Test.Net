using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public class BookRepository : IBookRepository
    {

        BookContext db = null;

        public BookRepository(BookContext db)
        {
            this.db = db;
        }

        public List<Book> GetAllBooks()
        {            
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return db.Books.SingleOrDefault(book => book.ID == id);
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {

            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            db.Books.Remove(book);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}