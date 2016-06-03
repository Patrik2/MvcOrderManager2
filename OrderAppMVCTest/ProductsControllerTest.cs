using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OrdersApp;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Test2.Controllers;
using Test2.Interfaces;
using Test2.Models;

namespace OrderAppMVCTest
{
    [TestClass()]
    public class ProductsControllerTest
    {
        private Mock<IOrderServices> mockOrderServices;
        private ProductsController controller;
        private Mock<ICartServices> mockCartServices;

        [TestInitialize]
        public void TestInitialize()
        {
            mockOrderServices = new Mock<IOrderServices>();
            mockCartServices = new Mock<ICartServices>();
            controller = new ProductsController(mockOrderServices.Object,mockCartServices.Object);
        }
        [TestMethod()]
        public void TestIndexAction()
        {
            var expectedCartItem = new CartItemViewModel { ProductItemId = 1, ItemPrice = 2, Quantity = 4 };
            var expectedViewModel = new List<CartItemViewModel> { expectedCartItem };
            mockCartServices.Setup(x => x.GetListCartItemViewModel()).Returns(expectedViewModel);

            var result = controller.Index();

            mockCartServices.Verify(x => x.GetListCartItemViewModel(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(expectedCartItem, ((List<CartItemViewModel>)result.Model).SingleOrDefault());
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod()]
        public void TestCartAction()
        {
            var expectedCartItem = new CartItem {ProductItemId=1, Quantity =2 };
            var expectedCartItems = new List<CartItem> {expectedCartItem };
            var expectedCartItemViewModel = new CartItemViewModel { ProductItemId = 1, ItemPrice = 2, Quantity = 4 };
            var expectedListCartItemsViewModel = new List<CartItemViewModel> { expectedCartItemViewModel };
            var expectedProductsAndCartItemViewModel = new ProductsAndCartItemViewModel { CartItems = expectedCartItems, CartItemViewModels= expectedListCartItemsViewModel };
            //var expectedViewModel = new List<ProductsAndCartItemViewModel> {};
            mockCartServices.Setup(x => x.GetModelForCartView()).Returns(expectedProductsAndCartItemViewModel);

            var result = controller.Cart();

            mockCartServices.Verify(x => x.GetModelForCartView(), Times.Once());
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(expectedProductsAndCartItemViewModel, (ProductsAndCartItemViewModel)result.Model);
            Assert.AreEqual("Cart", result.ViewName);
        }
        [TestMethod()]
        public void TestCartPostAction()
        {
            var cartItems = new List<CartItem> { new CartItem { ProductItemId = 1, Quantity = 2 }, new CartItem { ProductItemId = 2, Quantity = 5 } };

            var result = controller.Cart(cartItems);

            mockCartServices.Verify(x => x.SetCart(cartItems) , Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual("Cart", result.ViewName);
        }
        [TestMethod()]
        public void TestCreateOrderAction()
        {
            var expectedCartItem = new CartItem { ProductItemId = 8, Quantity = 5 };
            var cartItems = new List<CartItem> { expectedCartItem};
            var order = new Order { OrderItems = new List<OrderItem> { new OrderItem { Quantity = expectedCartItem.Quantity, OrderItemID = expectedCartItem.ProductItemId } } };
            mockOrderServices.Setup(x => x.CreateOrder(cartItems)).Returns(order);

            var result = controller.CreateOrder(cartItems);

            var resultOrder = result.Model as Order;
            Assert.IsNotNull(result);
            Assert.IsNotNull(resultOrder);
            Assert.IsNotNull(resultOrder.OrderItems);
            Assert.AreEqual(expectedCartItem.Quantity, resultOrder.OrderItems.Single().Quantity);
            Assert.AreEqual(expectedCartItem.ProductItemId, resultOrder.OrderItems.Single().OrderItemID);
            Assert.AreEqual("CreateOrder", result.ViewName);
        }
        [TestMethod()]
        public void TestRemoveAction()
        {
            var result = controller.Remove(2);

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Permanent);
            mockCartServices.Verify(x => x.RemoveItemFromCurrentCart(It.IsAny<int>()), Times.Once);
            Assert.AreEqual("Cart", result.RouteValues["action"]);
        }
    }
}
