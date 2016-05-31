using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMVC.Models;
using PagedList;

namespace LibraryMVC.Controllers
{
    public class BooksController : Controller
    {
        private UnitOfWork unitOfWork = null;

        public BooksController()
            : this(new UnitOfWork())
        {

        }

        public BooksController(UnitOfWork uow)
        {
            this.unitOfWork = uow;
        }


        public ActionResult Index(int? page)
        {
            List<Book> books = unitOfWork.bookRepository.GetAllBooks();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Details(int id)
        {
            Book book = unitOfWork.bookRepository.GetBookById(id);

            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.bookRepository.AddBook(book);
                unitOfWork.bookRepository.Save();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = unitOfWork.bookRepository.GetBookById(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.bookRepository.UpdateBook(book);
                unitOfWork.bookRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            Book book = unitOfWork.bookRepository.GetBookById(id);
            unitOfWork.bookRepository.DeleteBook(book);
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Book book = unitOfWork.bookRepository.GetBookById(id);
                unitOfWork.bookRepository.DeleteBook(book);
                unitOfWork.bookRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}