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
    public class CommentsController : ApiController
    {
        private ICommentsService _commentsService;

        /// <summary>
        /// Comments controller
        /// </summary>
        /// <param name="service">Service for operations</param>
        public CommentsController(ICommentsService service)
        {
            this._commentsService = service;
        }

        /// <summary>
        /// Get all comments to same post
        /// </summary>
        /// <param name="postId">Id of post</param>
        /// <returns>All post comments</returns>
        public IEnumerable<string> Get(long postId)
        {
            yield return JsonConvert.SerializeObject(this._commentsService.GetAll(postId));
        }

        /// <summary>
        /// Get comment
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns comment</returns>
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(this._commentsService.GetComment(id));
        }

        /// <summary>
        /// Add new comment
        /// </summary>
        /// <param name="value">Comment information</param>
        public void Post([FromBody]string value)
        {
            this._commentsService.AddComment(JsonConvert.DeserializeObject<Comment>(value));
        }

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Comment information</param>
        public void Put([FromBody]string value)
        {
            this._commentsService.EditComment(JsonConvert.DeserializeObject<Comment>(value));
        }

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(int id)
        {
            this._commentsService.DeleteComment(id);
        }
    }
}