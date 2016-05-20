using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrdersApp;
using Test2.Models;
using System.Net;

namespace Test2.Controllers
{
    public class ProductsController : Controller
    {
        private IOrderServices orderServices;
        public ProductsController(IOrderServices orderServices)
        {
            this.orderServices = orderServices;
        }
        public ActionResult Index()
        {
            return View("Index", orderServices.GetListCartItemViewModel());
        }
        public ActionResult Cart()
        {
            return View("Cart", orderServices.GetModelForCartView());
        }

        [HttpPost]
        public ActionResult Cart(List<CartItem> cartItems)
        {
            orderServices.SetCart(cartItems);
            return Cart();
        }
        [HttpPost]
        public ActionResult CreateOrder(List<CartItem> cartItems)
        {
            var order = orderServices.CreateOrder(cartItems);
            return View(order);
        }
        public ActionResult Remove(int itemID)
        {
            orderServices.RemoveItemFromCurrentCart(GetCartItem(itemID));
            return RedirectToAction("Cart");
        }
        private CartItem GetCartItem(int itemID)
        {
            return (from cartitem in orderServices.GetCurrentCart()
                    where itemID == cartitem.ItemId
                    select cartitem).Single();
        }
        public ActionResult Details(int id)
        {
            var product = orderServices.FindProduct(id);
            if (product == null)
            {
                return NullElementView();
            }
            return View(product);
        }
        public ActionResult NullElementView()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        orderContext.Products.Add(product);
        //        orderContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(product);
        //}
        // GET: Products/Edit/5
        public ActionResult Edit(int itemID)
        {
            CartItem cartItem = GetCartItem(itemID);
            if (cartItem == null)
            {
                return NullElementView();
            }
            return View(cartItem);
        }
        [HttpPost]
        public ActionResult Edit(List<CartItem> cartItems)
        {
            return RedirectToAction("Cart");
        }
        //public ActionResult Edit(CartItem cartItem)
        //{
        //    var oldCartItem = (from cartitem in StoredCartItems
        //                       where cartItem.ItemId == cartitem.ItemId
        //                       select cartitem).Single();

        //    StoredCartItems.Remove(oldCartItem);
        //    StoredCartItems.Add(cartItem);
        //    return RedirectToAction("Cart");
        //}



        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ItemId,Quantity")] CartItem cartItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //orderContext.Entry(cartItem).State = EntityState.Modified;
        //        //orderContext.SaveChanges();
        //        //var listCart = StoredCartItems;
        //        //var car = from p in listCart
        //        //          where cartItem.ItemId == 
        //        //listCart.Remove()

        //        //return RedirectToAction("Cart");
        //    }
        //    return View(cartItem);
        //}

        // GET: Products/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Product product = orderContext.Products.Find(id);
        //    if (product == null)
        //    {
        //        //return HttpNotFound();
        //        return NullElementView();
        //    }
        //    return View(product);
        //}
        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product product = orderContext.Products.Find(id);
        //    orderContext.Products.Remove(product);
        //    orderContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        orderContext.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
