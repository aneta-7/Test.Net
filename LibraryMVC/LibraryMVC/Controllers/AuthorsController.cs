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
    public class AuthorsController : Controller
    {
        private UnitOfWork2 unitOfWork = null;
        private BookContext db = new BookContext();

        public AuthorsController()
            : this(new UnitOfWork2())
        {

        }

        public AuthorsController(UnitOfWork2 uow)
        {
            this.unitOfWork = uow;
        }


        // GET: Authors
        public ActionResult Index(int ?page)
        {
            List<Author> authors = unitOfWork.authorRepository.GetAllAuthors();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            Author author = unitOfWork.authorRepository.GetAuthorById(id);

            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.authorRepository.AddAuthor(author);
                unitOfWork.authorRepository.Save();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            Author author = unitOfWork.authorRepository.GetAuthorById(id);

            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.authorRepository.UpdateAuthor(author);
                unitOfWork.authorRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Index");
            
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        { 
            Author author = unitOfWork.authorRepository.GetAuthorById(id);
            unitOfWork.authorRepository.DeleteAuthor(author);
            return View(author);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Author author = unitOfWork.authorRepository.GetAuthorById(id);
                unitOfWork.authorRepository.DeleteAuthor(author);
                unitOfWork.authorRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
