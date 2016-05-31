using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryMVC.Models;
using System.Collections.Generic;
using LibraryMVC.Controllers;
using System.Web.Mvc;

namespace LibraryMVC.Tests.Controllers
{
    [TestClass]
    public class AuthorControllerTest
    {
        Author author1 = null;
        Author author2 = null;
        Author author3 = null;
        Author author4 = null;
        Author author5 = null;
        
        List<Author> authors = null;
        DummyAuthorRepository authorsRepo = null;
        UnitOfWork2 uow = null;
        AuthorsController controller = null;

        public AuthorControllerTest()
        {
            author1 = new Author { ID = 1, Name = "test1", Surname = "ABCDE" };
            author2 = new Author { ID = 2, Name = "test2", Surname = "ABCDE" };
            author3 = new Author { ID = 3, Name = "test3", Surname = "ABCDE" };
            author4 = new Author { ID = 4, Name = "test4", Surname = "ABCDE" };
            author5 = new Author { ID = 5, Name = "test5", Surname = "ABCDE" };

            authors = new List<Author>
        {
            author1,
            author2,
            author3,
            author4
        };

            authorsRepo = new DummyAuthorRepository(authors);

            uow = new UnitOfWork2(authorsRepo);

            controller = new AuthorsController(uow);
        }

        [TestMethod]
        public void IndexAuthor()
        {
            List<Author> authors = authorsRepo.GetAllAuthors();


            int page = (authors.Count) / 3 + 1;
            ViewResult result = controller.Index(page) as ViewResult;

            //       var model = (List<author>)result.ViewData.Model;

            CollectionAssert.Contains(authors, author1);
            CollectionAssert.Contains(authors, author2);
            CollectionAssert.Contains(authors, author3);
            CollectionAssert.Contains(authors, author4);
            // CollectionAssert.Contains(authors, author5);
        }

        [TestMethod]
        public void DetailsAuthor()
        {
            ViewResult result = controller.Details(1) as ViewResult;

            Assert.AreEqual(result.Model, author1);
        }


        [TestMethod]
        public void CreateAuthor()
        {
            Author newAuthor = new Author { ID = 7, Name = "new", Surname = "ABCDE" };

            controller.Create(newAuthor);

            List<Author> authors = authorsRepo.GetAllAuthors();

            CollectionAssert.Contains(authors, newAuthor);

        }

        [TestMethod]
        public void EditAuthor()
        {
            Author editedAuthor = new Author { ID = 1, Name = "new", Surname = "ABCDE" };

            controller.Edit(editedAuthor);

            List<Author> authors = authorsRepo.GetAllAuthors();

            CollectionAssert.Contains(authors, editedAuthor);

        }

        [TestMethod]
        public void EditAuthor2()
        {
            controller.Edit(1);
            Author editedAuthor = new Author { ID = 1, Name = "new", Surname = "ABCDE" };

            uow.authorRepository.UpdateAuthor(editedAuthor);
            uow.authorRepository.Save();

            List<Author> authors = authorsRepo.GetAllAuthors();

            CollectionAssert.Contains(authors, editedAuthor);

        }


        [TestMethod]
        public void Deletedauthor()
        {
            controller.Delete(1);

            List<Author> authors = authorsRepo.GetAllAuthors();

            CollectionAssert.DoesNotContain(authors, author1);
        }

        [TestMethod]
        public void Deleteauthor2()
        {
            FormCollection form = null;
            controller.Delete(1, form);

            Author author = uow.authorRepository.GetAuthorById(1);
            uow.authorRepository.DeleteAuthor(author);

            uow.authorRepository.Save();

            CollectionAssert.DoesNotContain(authors, author1);



        }
    }
}
