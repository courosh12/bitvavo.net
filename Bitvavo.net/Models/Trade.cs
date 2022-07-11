using System;
using System.Collections.Generic;
using System.Text;

namespace Bitvavo.net.Models
{
    public class Trade
    {
        public string id { get; set; }
        public long timestamp { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string side { get; set; }
    }
}
