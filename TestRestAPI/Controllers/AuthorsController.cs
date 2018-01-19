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
    public class AuthorsController : ApiController
    {

        IAuthorsService _authorsService;
        /// <summary>
        /// Author controller
        /// </summary>
        /// <param name="service">Service for operations</param>
        public AuthorsController(IAuthorsService service)
        {
            this._authorsService = service;
        }

        /// <summary>
        /// Get all registered authors
        /// </summary>
        /// <returns>List of authors</returns>
        public IEnumerable<string> Get()
        {
            yield return JsonConvert.SerializeObject(this._authorsService.GetAll());
        }

        /// <summary>
        /// Get author by identification
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Returns author</returns>
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(this._authorsService.GetAuthor(id));
        }

        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="value">author information</param>
        public void Post([FromBody]string value)
        {
            this._authorsService.AddAuthor(JsonConvert.DeserializeObject<Author>(value));
        }

        /// <summary>
        /// Edit author
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="value">Author information</param>
        public void Put([FromBody]string value)
        {
            this._authorsService.EditAuthor(JsonConvert.DeserializeObject<Author>(value));
        }

        /// <summary>
        /// Delete author
        /// </summary>
        /// <param name="id">Id</param>
        public void Delete(int id)
        {
            this._authorsService.DeleteAuthor(id);
        }
    }
}