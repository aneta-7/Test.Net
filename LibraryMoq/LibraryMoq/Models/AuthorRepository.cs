using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMoq.Models
{
    public class AuthorRepository : IAuthorRepository
    {

        ApplicationDbContext db = null;

        public AuthorRepository()
        {
            db = new ApplicationDbContext();
        }

        public AuthorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Author> Authors
        {
            get
            {
               return db.Authors.AsQueryable();
            }
        }

        public void AddAuthor(Author author)
        {
             db.Authors.Add(author);
        }

        public void DeleteAuthor(Author author)
        {
            db.Authors.Remove(author);
        }

        public List<Author> GetAllAuthors()
        {
            return db.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return db.Authors.SingleOrDefault(author => author.ID == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}