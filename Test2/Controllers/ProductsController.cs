using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdersApp;
using Test2.Models;
using System.Net;
using Test2.Interfaces;

namespace Test2.Controllers
{
    public class ProductsController : Controller
    {
        private IOrderServices orderServices;
        private ICartServices cartServices;
        public ProductsController(IOrderServices orderServices, ICartServices cartServices)
        {
            this.cartServices = cartServices;
            this.orderServices = orderServices;
        }
        public ViewResult Index()
        {
            return View("Index", cartServices.GetListCartItemViewModel());
        }
        public ViewResult Cart()
        {
            return View("Cart", cartServices.GetModelForCartView());
        }
        [HttpPost]
        public ViewResult Cart(List<CartItem> cartItems)
        {
            cartServices.SetCart(cartItems);
            return Cart();
        }
        [HttpPost]
        public ViewResult CreateOrder(List<CartItem> cartItems)
        {
            var order = orderServices.CreateOrder(cartItems);
            return View("CreateOrder",order);
        }
        public RedirectToRouteResult Remove(int itemID)
        {
            cartServices.RemoveItemFromCurrentCart(itemID);
            return RedirectToAction("Cart");
        }
        //private CartItem GetCartItem(int itemID)
        //{
        //    return (from cartitem in cartServices.GetCurrentCart()
        //            where itemID == cartitem.ItemId
        //            select cartitem).Single();
        //}
        //public ViewResult Create()
        //{
        //    return View();
        //}
    }
}
