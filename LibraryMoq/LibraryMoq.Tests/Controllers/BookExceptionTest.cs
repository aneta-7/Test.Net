using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibraryMoq.Models;
using LibraryMoq.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMoq.Tests.Controllers
{
    [TestClass]
    public class BookExceptionTest
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
        public void DeleteBook()
        {
            var id = 10;

            repositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns<Book>(null);

            controller = new BooksController(repositoryMock.Object);
            var result = controller.Delete(id) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
      //      Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));

        }
        [TestMethod]
        public void EditBook()
        {
            var id = 12;

            repositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns<Book>(null);

            controller = new BooksController(repositoryMock.Object);

            var result = controller.Edit(id);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

        }

        [TestMethod]
        public void DetailsBookReturnNotFound()
        {
            var id = 12;

            repositoryMock.Setup(x => x.GetBookById(It.IsAny<int>())).Returns<Book>(null);

            controller = new BooksController(repositoryMock.Object);

            var result = controller.Details(id);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void CreateBook()
        {

            var books = new List<Book>();
            books.Add(null);
            books.Add(null);
            repositoryMock.Setup(x => x.Books).Returns(books.AsQueryable());

            controller = new BooksController(repositoryMock.Object);

            var result = controller.Create(null);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }
    }
}
