using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTcc2.Models;

namespace TestTcc2.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}