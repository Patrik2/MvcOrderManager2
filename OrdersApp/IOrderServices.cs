using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2.Models;

namespace OrdersApp
{
    public interface IOrderServices
    {
        Order CreateOrder(List<CartItem> cartItems);
        //List<CartItemViewModel> GetListCartItemViewModel();
        //Product FindProduct(int id);
        //List<CartItem> GetCurrentCart();
        //void SetCurrentCart(List<CartItem> cartItems);
        //void RemoveItemFromCurrentCart(CartItem cartItem);
        //ProductsAndCartItemViewModel GetModelForCartView();
        //void SetCart(List<CartItem> cartItems);
    }
}
