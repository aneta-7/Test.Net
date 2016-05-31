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
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private IAuthorRepository authorRepository;

        public AuthorsController() : this(new AuthorRepository())
        {

        }
        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        
        // GET: Authors
        public ActionResult Index(int? page)
        {
            IQueryable<Author> authors = authorRepository.Authors.OrderBy(x => x.ID);
            if (authors == null)
            {
                return HttpNotFound();
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(authors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {

            Author author = authorRepository.GetAuthorById(id);
            if (author == null)
                return HttpNotFound();
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
                authorRepository.AddAuthor(author);
                authorRepository.Save();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {

            Author author = authorRepository.GetAuthorById(id);
            if (author == null)
                return HttpNotFound();
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
                authorRepository.UpdateAuthor(author);
                authorRepository.Save();
                return RedirectToAction("Index");
            }

            return View("Index");

        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            Author author = authorRepository.GetAuthorById(id);
            if (author == null)
                return new HttpStatusCodeResult(404);
            authorRepository.DeleteAuthor(author);
            return View(author);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Author author = authorRepository.GetAuthorById(id);
                if (author == null)
                    return HttpNotFound();
                authorRepository.DeleteAuthor(author);
                authorRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}
