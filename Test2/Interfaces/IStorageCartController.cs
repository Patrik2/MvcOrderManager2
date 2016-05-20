using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test2.Interfaces
{
    public interface IStorageCartController2
    {
        List<CartItem> CurrentCart { get; set; }
    }
}