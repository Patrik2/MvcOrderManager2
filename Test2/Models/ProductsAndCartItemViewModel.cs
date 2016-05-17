using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class ProductsAndCartItemViewModel
    {
         public IList<CartItemViewModel> CartItemViewModels { get; set; }
         public IList<CartItem> CartItems { get; set; }
    }
}