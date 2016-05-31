using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public class UnitOfWork2
    {

        private BookContext db = null;

        public UnitOfWork2()
        {
            db = new BookContext();
            authorRepository = new AuthorRepository(db);
        }

        // This will be created from test project and passed on to the
        // controllers parameterized constructors
        public UnitOfWork2(IAuthorRepository authorsRepo)
        {
            authorRepository = authorsRepo;
        }

        public IAuthorRepository authorRepository
        {
            get;
            private set;
        }

    }
}