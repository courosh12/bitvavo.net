using Bitvavo.net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bitvavo.net
{
    public interface IExchangeData
    {
        /// <summary>
        /// Returns the entire orderbook for a market, where individual orders are grouped by price.
        ///Rate limiting weight: 1.
        /// </summary>
        /// <param name="symbol"> Example: BTC-EUR. Market for which the order book should be returned.</param>
        /// <param name="dept">Parameter used to limit the returned orderbook. This means that the best [limit] buy/sell orders will be returned.</param>
        /// <returns></returns>
        Task<RestResponse<OrderBook>> OrderBookAsync(string symbol, int? dept = null);
        /// <summary>
        /// Returns trades for the given market. Rate limiting weight: 5.
        /// </summary>
        /// <param name="market">	Example: BTC-EUR Market for which the trades should be returned.</param>
        /// <param name="limit"> Default: 500 Filter used to limit the returned results.Most recent trades will be returned.</param>
        /// <param name="start">Integer specifying from (i.e. showing those later in time) which time all trades should be returned. Should be a timestamp in milliseconds since 1 Jan 1970.</param>
        /// <param name="end">Integer specifying up to (i.e. showing those earlier in time) which time all trades should be returned. Should be a timestamp in milliseconds since 1 Jan 1970.</param>
        /// <param name="tradeIdFrom">Filter used to limit the returned results. All trades after this trade are returned (i.e. showing those later in time).</param>
        /// <param name="tradeIdTo">Filter used to limit the returned results. All trades up to this trade are returned (i.e. showing those earlier in time).</param>
        /// <returns></returns>
        Task<RestResponse<List<Trade>>> Trades(string market, int? limit = null, long? start = null, long? end = null, string tradeIdFrom = null, string tradeIdTo = null);
    }
}
