using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRestAPI.Controllers;
using TestRestAPI.Repositories;
using System.Collections.Generic;

namespace TestRestAPI.Tests.Controllers
{
    [TestClass]
    public class CommentsControllerTest
    {
        [TestMethod]
        public void TestGetComments()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            IEnumerable<string> result = controller.Get((long)1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetCommentPositive()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            string result = controller.Get(1);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void TestGetCommentNegative()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            string result = controller.Get(-1);

            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestAddCommentPositive()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Post("{'text': 'same comment', 'postId': '3', 'authorId': '1'}");
        }

        [TestMethod]
        public void TestAddCommentNegative()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Post("");
        }

        [TestMethod]
        public void TestEditCommentPositive()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Put("{'text': 'new comment', 'id': '1'}");
        }

        [TestMethod]
        public void TestEditCommentNegative()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Put("");
        }

        [TestMethod]
        public void TestDeleteCommentPositive()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Delete(1);
        }

        [TestMethod]
        public void TestDeleteCommentNegative()
        {
            CommentService service = new CommentService();
            CommentsController controller = new CommentsController(service);

            controller.Delete(-1);
        }
    }
}
