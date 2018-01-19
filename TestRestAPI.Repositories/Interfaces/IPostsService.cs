using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Models;

namespace TestRestAPI.Repositories.Interfaces
{
    public interface IPostsService
    {
        Post[] GetAll();
        Post GetPost(long id);
        void AddPost(Post post);
        void EditPost(Post post);
        void DeletePost(long postId);
    }
}
