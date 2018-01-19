using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRestAPI.Controllers;
using TestRestAPI.Repositories;

namespace TestRestAPI.Tests.Controllers
{
    [TestClass]
    public class PostsControllerTest
    {
        [TestMethod]
        public void TestGetPosts()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Get();
        }

        [TestMethod]
        public void TestGetPostNegative()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            string result = controller.Get(-1);
        }

        [TestMethod]
        public void TestGetPostPositive()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            string result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TestAddPostNegative()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Post("");
        }

        [TestMethod]
        public void TestAddPostPositive()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Post("{'text': 'same text', 'authorId': '1'}");
        }

        [TestMethod]
        public void TestEditPostPositive()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Put("{'text': 'new same text', 'id': '2'}");
        }

        [TestMethod]
        public void TestEditPostNegative()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Put("");
        }

        [TestMethod]
        public void TestDeletePostPositive()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            //id of existing post
            controller.Delete(2);
        }

        [TestMethod]
        public void TestDeletePostNegative()
        {
            PostsService service = new PostsService();
            PostsController controller = new PostsController(service);

            controller.Delete(-1);
        }
    }
}
