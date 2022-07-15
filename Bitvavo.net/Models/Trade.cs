using System;
using System.Collections.Generic;
using System.Text;

namespace Bitvavo.net.Models
{
    public class Trade
    {
        public string Id { get; set; }
        public long Timestamp { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string Side { get; set; }
    }
}
