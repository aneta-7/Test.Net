using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMoq.Models;
using Moq;
using LibraryMoq.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryMoq.Tests.Controllers
{
    [TestClass]
    public class AuthorControllerTest
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
        public void AddAuthorsTest()
        {
            var authors = new List<Author>();
            authors.Add(new Author() { ID = 1, Name = "ad", Surname= "bb" });
            authors.Add(new Author() { ID = 2, Name = "bd", Surname = "cc" });
            authors.Add(new Author() { ID = 3, Name = "cd", Surname = "dd"});

            repositoryMock.Setup(x => x.Authors).Returns(authors.AsQueryable());
            IQueryable<Author> allAuthors = repository.Authors.AsQueryable();
            Assert.IsNotNull(allAuthors);
            Assert.AreEqual(3, allAuthors.Count());
        }

        [TestMethod]
        public void CreateAuthorTestTest()
        {
            var author = new Author()
            {
                Name = "nowa",
                Surname = "nowe"
            };

            var result = controller.Create(author) as RedirectToRouteResult;

            repositoryMock.Verify(x => x.AddAuthor(author), Times.Once());
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void TestMethod3()
        {
            var author = new Author();

            controller.ModelState.AddModelError("key", "error");

            var result = controller.Create(author) as ViewResult;

            repositoryMock.Verify(x => x.AddAuthor(author), Times.Never());

            var model = result.ViewData.Model as Author;

            Assert.AreEqual(author, model);

        }

        [TestMethod]
        public void FindByIDTest()
        {
            var authors = new List<Author>();
            authors.Add(new Author() { ID = 1, Name = "ad", Surname = "bb" });
            authors.Add(new Author() { ID = 2, Name = "bd", Surname = "cc" });
            authors.Add(new Author() { ID = 3, Name = "cd", Surname = "dd" });

            repositoryMock.Setup(x => x.Authors).Returns(authors.AsQueryable());
            repositoryMock.Setup(x => x.GetAuthorById(It.IsAny<int>())).Returns((int i) => authors.Where(x => x.ID == i).Single());

            Author testAuthor = this.repository.GetAuthorById(2);

            Assert.IsNotNull(testAuthor);
            Assert.AreEqual("bd", testAuthor.Name);

        }

        [TestMethod]
        public void UpdateTitleBook()
        {
            var authors = new List<Author>();
            authors.Add(new Author() { ID = 1, Name = "ad", Surname = "bb" });
            authors.Add(new Author() { ID = 2, Name = "bd", Surname = "cc" });
            authors.Add(new Author() { ID = 3, Name = "cd", Surname = "dd" });

            repositoryMock.Setup(x => x.Authors).Returns(authors.AsQueryable());
            repositoryMock.Setup(x => x.GetAuthorById(It.IsAny<int>())).Returns((int i) => authors.Where(x => x.ID == i).Single());

            Author testAuthor = this.repository.GetAuthorById(2);

            testAuthor.Name = "nowaNazwa";

            this.repository.UpdateAuthor(testAuthor);

            Assert.AreEqual("nowaNazwa", this.repository.GetAuthorById(2).Name);
        }
    }
}