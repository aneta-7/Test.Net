using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LibraryMVC.Models
{
    public class UnitOfWork
    {

        private BookContext db = null;

        public UnitOfWork()
        {
            db = new BookContext();
            bookRepository = new BookRepository(db);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork(IBookRepository booksRepo)
        {
            bookRepository = booksRepo;
        }

        public IBookRepository bookRepository
        {
            get;
            private set;
        }
    }
}