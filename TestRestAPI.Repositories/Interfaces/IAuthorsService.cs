using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Models;

namespace TestRestAPI.Repositories.Interfaces
{
    public interface IAuthorsService
    {
        Author[] GetAll();
        Author GetAuthor(long id);
        void AddAuthor(Author author);
        void EditAuthor(Author author);
        void DeleteAuthor(long authorId);
    }
}
