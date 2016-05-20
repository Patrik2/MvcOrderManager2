using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class CartItemViewModel
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public double ItemPrice { get; set; }
    }
}