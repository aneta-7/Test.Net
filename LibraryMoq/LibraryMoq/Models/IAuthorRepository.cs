using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMoq.Models
{
    public interface IAuthorRepository
    {
        IQueryable<Author> Authors { get; }
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();
    }
}