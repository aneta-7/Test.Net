using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryMoq.Models;
using PagedList;

namespace LibraryMoq.Controllers
{
    [HandleError(View = "Error")]
    public class BooksController : Controller
    {


        private IBookRepository bookRepository;


        public BooksController ():this(new BookRepository())
        {
            
        }

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        public ActionResult Index(int? page)
        {
            IQueryable<Book> books = bookRepository.Books.OrderBy(x => x.ID);

            if (books == null)
                return HttpNotFound();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }
 

        public ActionResult Details(int id)
        {
        
            Book book = bookRepository.GetBookById(id);
            if (book == null)
                return HttpNotFound();
           else return View(book);
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
                bookRepository.AddBook(book);
                bookRepository.Save();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
           
            Book book = bookRepository.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                bookRepository.UpdateBook(book);
                bookRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }
            Book book = bookRepository.GetBookById(id);
            if (book == null)
            {
                return new HttpStatusCodeResult(404);
            }
            bookRepository.DeleteBook(book);
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Book book = bookRepository.GetBookById(id);
                if (book == null)
                    return HttpNotFound();
                bookRepository.DeleteBook(book);
                bookRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}





