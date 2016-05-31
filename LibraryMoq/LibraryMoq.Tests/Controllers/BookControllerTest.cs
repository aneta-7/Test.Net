using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMoq.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using LibraryMoq.Controllers;
using System.Web.Mvc;

namespace LibraryMoq.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
        IBookRepository repository;
        Mock<IBookRepository> repositoryMock;
        BooksController controller;

        [TestInitialize]
        public void setUp()
        {
            repositoryMock = new Mock<IBookRepository>();

            controller = new BooksController(repositoryMock.Object);

            this.repository = repositoryMock.Object;

        }

        [TestMethod]
        public void AllBooksTest()
        {
            var books = new List<Book>();
            books.Add(new Book() { ID = 1 ,Title = "ad", AuthorId = 1, ISBN="42343"});
            books.Add(new Book() { ID = 2, Title = "bd", AuthorId = 2, ISBN="32434"});
            books.Add(new Book() { ID = 3, Title = "cd", AuthorId = 1, ISBN ="42342"});

            repositoryMock.Setup(x => x.Books).Returns(books.AsQueryable());

            IQueryable<Book> allBooks = repository.Books.AsQueryable();
            Assert.IsNotNull(allBooks);
            Assert.AreEqual(3, allBooks.Count());    
        }

        [TestMethod]
        public void CreateBookTest()
        {
            var book = new Book()
            {
                Title = "nowa",
                AuthorId = 1,
                ISBN = "323234"
            };

            var result = controller.Create(book) as RedirectToRouteResult;

            repositoryMock.Verify(x => x.AddBook(book), Times.Once());
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void TestMethod3()
        {
            var book = new Book();

            controller.ModelState.AddModelError("key", "error");

            var result = controller.Create(book) as ViewResult;

            repositoryMock.Verify(x => x.AddBook(book), Times.Never());

            var model = result.ViewData.Model as Book;

            Assert.AreEqual(book, model);
        }

        [TestMethod]
        public void FindByIDTest()
        {
            var books = new List<Book>();
            books.Add(new Book() { ID = 1, Title = "ad", AuthorId = 1, ISBN = "42343" });
            books.Add(new Book() { ID = 2, Title = "bd", AuthorId = 2, ISBN = "32434" });
            books.Add(new Book() { ID = 3, Title = "cd", AuthorId = 1, ISBN = "42342" });
            
            repositoryMock.Setup(x => x.Books).Returns(books.AsQueryable());
            repositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns((int i) => books.Where(x => x.ID == i).Single());

            Book testBook = this.repository.GetBookById(2);

            Assert.IsNotNull(testBook);
            Assert.AreEqual("bd", testBook.Title);

        }

        [TestMethod]
        public void UpdateTitleBook()
        {
            var books = new List<Book>();
            books.Add(new Book() { ID = 1, Title = "ad", AuthorId = 1, ISBN = "42343" });
            books.Add(new Book() { ID = 2, Title = "bd", AuthorId = 2, ISBN = "32434" });
            books.Add(new Book() { ID = 3, Title = "cd", AuthorId = 1, ISBN = "42342" });

            repositoryMock.Setup(x => x.Books).Returns(books.AsQueryable());
            repositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns((int i) => books.Where(x => x.ID == i).Single());

            Book testBook = this.repository.GetBookById(2);

            testBook.Title = "nowaNazwa";

            this.repository.UpdateBook(testBook);

            Assert.AreEqual("nowaNazwa", this.repository.GetBookById(2).Title);
        }
    }
}
