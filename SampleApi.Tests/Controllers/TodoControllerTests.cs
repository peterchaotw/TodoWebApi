using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleApi.Controllers;
using SampleApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApi.Tests.Controllers
{
    [TestClass]
    public class TodoControllerTests
    {
        private TodoController controller { get; set; }
        [TestInitialize()]
        public void init()
        {
            controller = new TodoController();
        }

        [TestMethod()]
        public void GetTests()
        {
            var resp = controller.Get();
            Assert.IsTrue(resp.Data.Count() > 0);
        }

        [TestMethod()]
        public void GetAndSaveTests()
        {
            var todoItem = new TodoItem()
            {
                Title = "test",
                Description = "test"
            };
            var postResp = controller.Post((new List<TodoItem>() { todoItem }).ToArray());
            var getResp = controller.Get(postResp.Data.Select(p => p.Id).FirstOrDefault());
            var postId = postResp.Data.Select(p => p.Id).FirstOrDefault();
            var getId = getResp.Data.Select(p => p.Id).FirstOrDefault();
            Assert.IsTrue(getResp.Data.Count() > 0 && postId == getId);
        }

        [TestMethod()]
        public void DeleteTests()
        {
            var todoItem = new TodoItem()
            {
                Title = "test",
                Description = "test"
            };
            var postResp = controller.Post((new List<TodoItem>() { todoItem }).ToArray());
            var deleteResp = controller.Delete(postResp.Data.Select(p => p.Id).FirstOrDefault());
            var getResp = controller.Get(postResp.Data.Select(p => p.Id).FirstOrDefault());
            var postId = postResp.Data.Select(p => p.Id).FirstOrDefault();
            var deleteId = deleteResp.Data.Select(p => p.Id).FirstOrDefault();
            Assert.IsTrue(getResp.Data.Count() == 0 && postId == deleteId);
        }
    }
}
