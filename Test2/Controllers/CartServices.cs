using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test2.Interfaces;
using Test2.Models;

namespace Test2.Controllers
{
    public class CartServices : Controller, ICartServices
    {
        private IOrderContext orderContext;
        private IStorageCart storageCart;
        public CartServices(IOrderContext orderContext, IStorageCart storageCart)
        {
            this.orderContext = orderContext;
            this.storageCart = storageCart;
        }
        //public List<CartItem> CurrentCart
        //{
        //    get
        //    {
        //        return (List<CartItem>)System.Web.HttpContext.Current.Session["cart"];
        //    }
        //    set
        //    {
        //        System.Web.HttpContext.Current.Session["cart"] = value;
        //    }
        //}
        public List<CartItem> GetCurrentCart()
        {
            return storageCart.CurrentCart;
        }
        public CartItem GetCartItem(int itemID)
        {
            return (from cartitem in GetCurrentCart()
                    where itemID == cartitem.ProductItemId
                    select cartitem).Single();
        }
        public void SetCurrentCart(List<CartItem> cartItems)
        {
            storageCart.CurrentCart = cartItems;
        }
        public void RemoveItemFromCurrentCart(int ItemId)
        {
            (storageCart.CurrentCart).Remove(GetCartItem(ItemId));
        }
        //public void RemoveItemFromCurrentCart(CartItem cartItem)
        //{
        //    (storageCart.CurrentCart).Remove(cartItem);
        //}
        public void SetCart(List<CartItem> cartItems)
        {
            List<CartItem> cartItemsWithoutZeroQuantity = cartItems.Where(cartItem => cartItem.Quantity != 0).ToList();
            SetCurrentCart(cartItemsWithoutZeroQuantity);
        }
        public ProductsAndCartItemViewModel GetModelForCartView()
        {
            return new ProductsAndCartItemViewModel
            {
                CartItems = GetCurrentCart(),
                CartItemViewModels = GetListCartItemViewModel()
            };
        }
        public List<CartItemViewModel> GetListCartItemViewModel()
        {
            return orderContext.Products.Select(product => new CartItemViewModel { ProductItemId = product.ItemId, ItemPrice = product.ItemPrice }).ToList();
        }
    }
}