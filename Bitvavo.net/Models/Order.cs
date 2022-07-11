using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Bitvavo.net.Models
{
    public class Order
    {
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
