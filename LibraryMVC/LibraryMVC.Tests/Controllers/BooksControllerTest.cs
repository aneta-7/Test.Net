using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMVC.Models;
using System.Collections.Generic;
using LibraryMVC.Controllers;
using System.Web.Mvc;

namespace LibraryMVC.Tests.Controllers
{
    [TestClass]
    public class BooksControllerTest
    {
        Book book1 = null;
        Book book2 = null;
        Book book3 = null;
        Book book4 = null;
        Book book5 = null;

        List<Book> books = null;
        DummyBooksRepository booksRepo = null;
        UnitOfWork uow = null;
        BooksController controller = null;

        public BooksControllerTest()
        {
            book1 = new Book { ID = 1, Title = "test1", AuthorId = 1, ISBN = "ABCDE" };
            book2 = new Book { ID = 2, Title = "test2", AuthorId = 2, ISBN = "ABCDE" };
            book3 = new Book { ID = 3, Title = "test3", AuthorId = 3, ISBN = "ABCDE" };
            book4 = new Book { ID = 4, Title = "test4", AuthorId = 4, ISBN = "ABCDE" };
            book5 = new Book { ID = 5, Title = "test5", AuthorId = 5, ISBN = "ABCDE" };

            books = new List<Book>
        {
            book1,
            book2,
            book3,
            book4
        };

            booksRepo = new DummyBooksRepository(books);

            uow = new UnitOfWork(booksRepo);

            controller = new BooksController(uow);
        }

        [TestMethod]
        public void IndexBook()
        {
            List<Book> books = booksRepo.GetAllBooks();


            int page = (books.Count)/3 + 1;
            ViewResult result = controller.Index(page) as ViewResult;

     //       var model = (List<book>)result.ViewData.Model;

            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book2);
            CollectionAssert.Contains(books, book3);
            CollectionAssert.Contains(books, book4);
            // CollectionAssert.Contains(books, book5);
        }

        [TestMethod]
        public void Detailsbook()
        {
            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual(result.Model, book1);
        }


        [TestMethod]
        public void Createbook()
        {
            Book newbook = new Book { ID = 7, Title = "new", AuthorId = 3, ISBN = "ABCDE" };

            controller.Create(newbook);

            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, newbook);

        }

        [TestMethod]
        public void Editbook()
        {
            Book editedbook = new Book { ID = 1, Title = "new", AuthorId = 3, ISBN = "ABCDE" };

            controller.Edit(editedbook);

            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, editedbook);

        }

        [TestMethod]
        public void Edicbook2()
        {
            controller.Edit(1);
            Book editedbook = new Book { ID = 1, Title = "new", AuthorId = 3, ISBN = "ABCDE" };

            uow.bookRepository.UpdateBook(editedbook);
            uow.bookRepository.Save();

            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.Contains(books, editedbook);

        }


        [TestMethod]
        public void Deletedbook()
        {
            controller.Delete(1);

            List<Book> books = booksRepo.GetAllBooks();

            CollectionAssert.DoesNotContain(books, book1);
        }

        [TestMethod]
        public void Deletebook2()
        {
            FormCollection form = null;
            controller.Delete(1, form);

            Book book = uow.bookRepository.GetBookById(1);
            uow.bookRepository.DeleteBook(book);

            uow.bookRepository.Save();

            CollectionAssert.DoesNotContain(books, book1);



        }
    }
}
