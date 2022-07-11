using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitvavo.net.Models
{
    public class OrderBook
    {
        public string market { get; set; }
        public int nonce { get; set; }
        public List<List<decimal>> bids { get; set; }
        public List<List<decimal>> asks { get; set; }

    }
}
