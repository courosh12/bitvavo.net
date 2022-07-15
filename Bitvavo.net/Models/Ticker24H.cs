using System;
using System.Collections.Generic;
using System.Text;

namespace Bitvavo.net.Models
{
    public class Ticker24H
    {
        public string Market { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Last { get; set; }
        public string Volume { get; set; }
        public string VolumeQuote { get; set; }
        public string Bid { get; set; }
        public string BidSize { get; set; }
        public string Ask { get; set; }
        public string AskSize { get; set; }
        public long Timestamp { get; set; }
    }
}
