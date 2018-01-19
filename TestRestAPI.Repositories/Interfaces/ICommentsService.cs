using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Models;

namespace TestRestAPI.Repositories.Interfaces
{
    public interface ICommentsService
    {
        Comment[] GetAll(long postId);
        Comment GetComment(int id);
        void AddComment(Comment comment);
        void EditComment(Comment comment);
        void DeleteComment(int commentId);
    }
}
