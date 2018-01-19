using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRestAPI.Repositories;
using TestRestAPI.Controllers;
using System.Collections;
using System.Collections.Generic;
using TestRestAPI.Models;

namespace TestRestAPI.Tests.Controllers
{
    [TestClass]
    public class AuthorsControllerTest
    {
        [TestMethod]
        public void TestGetAuthors()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            IEnumerable<string> result = authorsController.Get();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetAuthorPositive()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            string result = authorsController.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TestGetAuthorNegative()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            string result = authorsController.Get(-1);

            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod]
        public void TestAddAuthorPositive()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            authorsController.Post("{'username': 'testUser'}");
        }

        [TestMethod]
        public void TestAddAuthorNegative()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            authorsController.Post("");
        }

        [TestMethod]
        public void TestEditAuthorPositive()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            authorsController.Put("newUsr");
        }

        [TestMethod]
        public void TestEditAuthorNegative()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            authorsController.Put( "");
        }

        [TestMethod]
        public void TestDeleteAuthorPositive()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            //id of existing author
            authorsController.Delete(1);
        }

        [TestMethod]
        public void TestDeleteAuthorNegative()
        {
            AuthorsService service = new AuthorsService();
            AuthorsController authorsController = new AuthorsController(service);

            authorsController.Delete(-1);
        }
    }
}
