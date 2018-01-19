using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestRestAPI.Models;
using TestRestAPI.Repositories.Interfaces;

namespace TestRestAPI.Controllers
{
    public class PostsController : ApiController
    {
        private IPostsService _postsService;

        /// <summary>
        /// Posts controller
        /// </summary>
        /// <param name="service">Service for operations</param>
        public PostsController(IPostsService service)
        {
            this._postsService = service;
        }
       
        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>Returns posts</returns>
        public IEnumerable<string> Get()
        {
            yield return JsonConvert.SerializeObject(this._postsService.GetAll());
        }

        /// <summary>
        /// Get post
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns post</returns>
        public string Get(long id)
        {
            return JsonConvert.SerializeObject(this._postsService.GetPost(id));
        }

        /// <summary>
        /// Add new post
        /// </summary>
        /// <param name="value">Post information</param>
        public void Post([FromBody]string value)
        {
            this._postsService.AddPost(JsonConvert.DeserializeObject<Post>(value));
        }

        /// <summary>
        /// Edit post
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Post information</param>
        public void Put([FromBody]string value)
        {
            this._postsService.EditPost(JsonConvert.DeserializeObject<Post>(value));
        }

        /// <summary>
        /// Delete post
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(long id)
        {
            this._postsService.DeletePost(id);
        }
    }
}