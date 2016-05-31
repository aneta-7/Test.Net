using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMoq.Models;
using LibraryMoq.Controllers;
using Moq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMoq.Tests.Controllers
{
    [TestClass]
    public class AuthorExceptionTest
    {

        IAuthorRepository repository;
        Mock<IAuthorRepository> repositoryMock;
        AuthorsController controller;

        [TestInitialize]
        public void setUp()
        {
            repositoryMock = new Mock<IAuthorRepository>();

            controller = new AuthorsController(repositoryMock.Object);

            this.repository = repositoryMock.Object;

        }


        [TestMethod]
        public void DeleteAuthor()
        {
            var id = 10;

            repositoryMock.Setup(x => x.GetAuthorById(It.IsAny<int>())).Returns<Author>(null);

            controller = new AuthorsController(repositoryMock.Object);
            var result = controller.Delete(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(HttpStatusCodeResult));


        }
        [TestMethod]
        public void EditAuthor()
        {
            var id = 12;

            repositoryMock.Setup(x => x.GetAuthorById(It.IsAny<int>())).Returns<Author>(null);

            controller = new AuthorsController(repositoryMock.Object);

            var result = controller.Edit(id) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
        //    Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));

        }

        [TestMethod]
        public void DetailsAuthorReturnNotFound()
        {
            var id = 12;

            repositoryMock.Setup(x => x.GetAuthorById(It.IsAny<int>())).Returns<Author>(null);

            controller = new AuthorsController(repositoryMock.Object);

            var result = controller.Details(id);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }



        [TestMethod]
        public void CreateAuthor()
        {

            var authors = new List<Author>();
            authors.Add(null);
            authors.Add(null);
            repositoryMock.Setup(x => x.Authors).Returns(authors.AsQueryable());

            controller = new AuthorsController(repositoryMock.Object);

            var result = controller.Create(null);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

        }
    }
}


