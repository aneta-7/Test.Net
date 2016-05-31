using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{

    public interface AutorInterface
    {
        Autor findAutor(String surname);
        Book findBook(String book);
    }

    public class LibraryClass : AutorInterface
    {
        public List<Book> books { get; set; } = new List<Book>();
        public List<Autor> autors { get; set; } = new List<Autor>();

        public Book findBook(String title)
        {
            var find = from Book oBook in books where oBook.Title == title select oBook;

            return find.FirstOrDefault();

        }

        public Autor findAutor(String surname)
        {
            var find = from Autor oAutor in autors where oAutor.Surname == surname select oAutor;

            return find.FirstOrDefault();
        }

        public Autor findLibrarianList(String surname)
        {
            autors = new List<Autor>(new[]
           {  new Autor ("Adam", "Mickiewicz"),
               new Autor ("Jan", "Kochanowski"),
               new Autor ("Eliza", "Orzeszkowa"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Eliza", "Orzeszkowa"),
               new Autor ("Mikolaj", "Rej"),
               new Autor ("Juliusz", "Slowacki")
            });

            var find = from Autor oAutor in autors where oAutor.Surname == surname select oAutor;



            return find.FirstOrDefault();
        }

        public int ISBNlength(String isbn)
        {
            int length;
            length = isbn.Length;
            return length;
        }

        public bool minTitle(String title)
        {
            int minLength = 2;
            int length;
            length = title.Length;
            if (length < minLength)
                return false;
            return true;
        }

        public bool autorLength(String name, String surname)
        {
            if (name.Length < 2 || surname.Length < 2)
                return false;
            return true;
        }

        public bool librarianLength(String name, String surname)
        {
            if (name.Length < 2 || surname.Length < 2)
                return false;
            return true;
        }

        public bool phoneLength(String number)
        {
            if (number.Length < 11 || number.Length > 11)
                return false;
            return true;
        }

        public bool phoneIncludeLetter(String number)
        {
            bool result = Regex.IsMatch(number, @"^[a-zA-Z]+$");
            if (result == true)
                return false;
            return true;
        }

        public bool zipCodeLength(String zipCode)
        {
            if (zipCode.Length > 6 || zipCode.Length < 6)
                return false;
            return true;
        }

        public bool zipCodeInclude(String zipCode)
        {
            if (zipCode.Contains("-"))
                return true;
            return false;
        }

        public int addBook(List<Book> bookList)
        {
            int size = bookList.Count;
            return size;
        }

    }
}
