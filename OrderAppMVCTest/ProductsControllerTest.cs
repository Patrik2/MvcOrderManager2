using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Test2.Controllers;

namespace OrderAppMVCTest
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void TestIndexView()
        {
            var mockOrderServices = new Mock<IOrderServices>();
            var controller = new ProductsController(mockOrderServices.Object);

            var result = controller.Index() as ViewResult;

            mockOrderServices.Verify(x => x.GetListCartItemViewModel(), Times.Once());
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void TestCartView()
        {
            var mockOrderServices = new Mock<IOrderServices>();
            var controller = new ProductsController(mockOrderServices.Object);

            var result = controller.Cart() as ViewResult;

            mockOrderServices.Verify(x => x.GetModelForCartView(), Times.Once());
            Assert.AreEqual("Cart", result.ViewName);
        }
        [TestMethod]
        public void TestCartPostMethod()
        {
            var cartItems = new List<CartItem> { new CartItem { ItemId = 1, Quantity = 2 }, new CartItem { ItemId = 2, Quantity = 5 } };
            var mockOrderServices = new Mock<IOrderServices>();
            var controller = new ProductsController(mockOrderServices.Object);

            var result = controller.Cart(cartItems) as ViewResult;

            mockOrderServices.Verify(x => x.GetModelForCartView(), Times.Once());
            mockOrderServices.Verify(x => x.SetCart(cartItems) , Times.Once());
            Assert.AreEqual("Cart", result.ViewName);
        }
    }
}
