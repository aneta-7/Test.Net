using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMoq.Models
{
    public class DummyAuthorRepository : IAuthorRepository
    {
        List<Author> m_authors = null;

        public IQueryable<Author> Authors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DummyAuthorRepository(List<Author> authors)
        {
            m_authors = authors;
        }

        public List<Author> GetAllAuthors()
        {
            return m_authors;
        }

        public Author GetAuthorById(int id)
        {
            return m_authors.SingleOrDefault(author => author.ID == id);
        }

        public void AddAuthor(Author author)
        {
            m_authors.Add(author);
        }

        public void UpdateAuthor(Author author)
        {
            int id = author.ID;
            Author authorToUpdate = m_authors.SingleOrDefault(b => b.ID == id);
            DeleteAuthor(authorToUpdate);
            m_authors.Add(author);
        }

        public void Save()
        {

        }

        public void DeleteAuthor(Author author)
        {
            m_authors.Remove(author);
        }
    }

}