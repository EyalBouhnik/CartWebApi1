using System;
using BussinessObject;
using CartWebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartWebApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetCart()
        {
            Cart c = new Cart();
            var controller = new CartController();
            c = controller.Get(2);
        }

        [TestMethod]
        public void TestInsert()
        {
            Cart c = new Cart();
            c.UserId = 2;
            c.ProductId = 2;
            c.Price = 2;
            c.DateCreated = DateTime.Now;

            var controller = new CartController();
            controller.Post(c);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Cart c = new Cart();
            c.Id = 2;
            c.UserId = 2;
            c.ProductId = 2;
            c.Price = 2;
            
            var controller = new CartController();
            controller.Put(c.Id,c);
        }

        [TestMethod]
        public void TestDelete()
        {
            int id = 2;
            var controller = new CartController();
            controller.Delete(id);
        }
    }
}
