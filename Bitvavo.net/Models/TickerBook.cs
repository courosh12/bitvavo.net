using System;
using System.Collections.Generic;
using System.Text;

namespace Bitvavo.net.Models
{
    public class TickerBook
    {
        public string Market { get; set; }
        public decimal Bid { get; set; }
        public decimal BidSize { get; set; }
        public decimal Ask { get; set; }
        public decimal askSize { get; set; }
    }
}
