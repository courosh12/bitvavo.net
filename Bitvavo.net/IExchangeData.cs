using Bitvavo.net.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bitvavo.net
{
    public interface IExchangeData
    {
        Task<OrderBook> OrderBookAsync(string symbol, int? dept = null);
    }
}
