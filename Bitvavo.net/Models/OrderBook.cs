using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bitvavo.net.Models
{
    public class OrderBook
    {
        public string Market { get; set; }
        public int Nonce { get; set; }
        public List<List<decimal>> Bids { get; set; }
        public List<List<decimal>> Asks { get; set; }

    }
}
