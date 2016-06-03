using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class ProductsAndCartItemViewModel2
    {
         public List<CartItemViewModel> CartItemViewModels { get; set; }
         public List<CartItem> CartItems { get; set; }
    }
}