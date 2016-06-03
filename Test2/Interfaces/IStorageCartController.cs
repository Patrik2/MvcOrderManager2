using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Interfaces
{
    public interface IStorageCart
    {
        List<CartItem> CurrentCart { get; set; }
    }
}