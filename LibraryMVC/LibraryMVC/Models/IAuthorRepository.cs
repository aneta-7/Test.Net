using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMVC.Models
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();
    }
}