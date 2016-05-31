using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        private String title;
        private String isbn;
        private Autor autor;

        public Book(String title, String ISBN, Autor autor)
        {
            this.title = title;
            this.isbn = ISBN;
            this.autor = autor;
        }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String ISBN
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public Autor Autor
        {
            get { return autor; }
            set { autor = value; }
        }

    }
}
