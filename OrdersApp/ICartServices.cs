using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2.Models;

namespace Test2.Interfaces
{
    public interface ICartServices
    {
        //List<CartItem> CurrentCart { get; set; }
        List<CartItem> GetCurrentCart();
        void SetCurrentCart(List<CartItem> cartItems);
        void RemoveItemFromCurrentCart(int ItemId);
        void SetCart(List<CartItem> cartItems);
        ProductsAndCartItemViewModel GetModelForCartView();
        List<CartItemViewModel> GetListCartItemViewModel();
        CartItem GetCartItem(int itemID);
    }
}