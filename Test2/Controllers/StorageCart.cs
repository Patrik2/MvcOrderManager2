using OrdersApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test2.Interfaces;

namespace Test2.Controllers
{
    public class StorageCart : IStorageCart
    {
        public List<CartItem> CurrentCart
        {
            get
            {
                return (List<CartItem>)System.Web.HttpContext.Current.Session["cart"];
            }
            set
            {
                System.Web.HttpContext.Current.Session["cart"] = value;
            }
        }
    }
}