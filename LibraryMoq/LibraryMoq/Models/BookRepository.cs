using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMoq.Models
{
    public class BookRepository : IBookRepository
    {

        ApplicationDbContext db = null;

        public IQueryable<Book> Books
        {
            get
            {
               return db.Books.AsQueryable();
            }
        }

        public BookRepository()
        {
            db = new ApplicationDbContext();
        }


        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Book> GetAllBooks()
        {            
            return db.Books.ToList();
        }

        public Book GetBookById(int? id)
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