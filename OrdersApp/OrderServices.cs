using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2.Models;
using Test2;
using Test2.Interfaces;

namespace OrdersApp
{
    public class OrderServices : IOrderServices
    {
        private IOrderManager orderManager;
        //private IOrderContext orderContext;
        //private ICartController currentCart;
        public OrderServices(IOrderManager orderManager)
        {
            this.orderManager = orderManager;
            //this.orderContext = orderContext;
            //this.currentCart = currentCart;
        }
        //public void SetCart(List<CartItem> cartItems)
        //{
        //    List<CartItem> cartItemsWithoutZeroQuantity = cartItems.Where(cartItem => cartItem.Quantity != 0).ToList();
        //    SetCurrentCart(cartItemsWithoutZeroQuantity);
        //}
        //public ProductsAndCartItemViewModel GetModelForCartView()
        //{
        //    return new ProductsAndCartItemViewModel
        //    {
        //        CartItems = GetCurrentCart(),
        //        CartItemViewModels = GetListCartItemViewModel()
        //    };
        //}
        //public List<CartItem> GetCurrentCart()
        //{
        //    return currentCart.CurrentCart;
        //}
        //public void SetCurrentCart(List<CartItem> cartItems)
        //{
        //    currentCart.CurrentCart = cartItems;
        //}
        //public void RemoveItemFromCurrentCart(CartItem cartItem)
        //{
        //    currentCart.CurrentCart.Remove(cartItem);
        //}
        //public Product FindProduct(int id)
        //{
        //    return orderContext.Products.SingleOrDefault(p => p.ItemId == id);
        //}
        public Order CreateOrder(List<CartItem> cartItems)
        {
            var order = orderManager.CreateOrder(cartItems);
            return order;
        }
        //public List<CartItemViewModel> GetListCartItemViewModel()
        //{
        //    return orderContext.Products.Select(product => new CartItemViewModel { ItemId = product.ItemId, ItemPrice = product.ItemPrice }).ToList();
        //}
    }
}
