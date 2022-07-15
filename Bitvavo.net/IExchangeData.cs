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
        /// <summary>
        /// Returns OHLCV candlesticks for the specified market and interval. If no trades occured in an interval, nothing is returned for that interval. 
        /// Rate limiting weight: 1.
        /// </summary>
        /// <param name="market"> Example: BTC-EUR Market for which the candles should be returned. </param>
        /// <param name="interval">
        ///  Enum: "1m" "5m" "15m" "30m" "1h" "2h" "4h" "6h" "8h" "12h" "1d" 
        /// Interval specifying the interval of the returned candles.</param>
        /// <param name="limit">	
        ///integer[1..1440]
        ///Default: 1440
        ///Filter used to limit the returned results.Most recent[limit] candles will be returned.</param>
        /// <param name="start">Integer specifying from (i.e. showing those later in time) which time all candles should be returned. Should be a timestamp in milliseconds since 1 Jan 1970.</param>
        /// <param name="end">Integer specifying up to (i.e. showing those earlier in time) which time all candles should be returned. Should be a timestamp in milliseconds since 1 Jan 1970.</param>
        /// <returns></returns>
        Task<RestResponse<List<List<object>>>> Candles(string market, string interval, int? limit = null, long? start = null, long? end = null);
        /// <summary>
        /// Returns the latest trade price for a market.
        /// </summary>
        /// <param name="market"> Example: market=BTC-EUR. Filter used to specify for which market data should be returned</param>
        /// <returns></returns>
        Task<RestResponse<TickerPrice>> TickerPrice(string market);
        /// <summary>
        /// Returns the latest trade price for each market.
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<List<TickerPrice>>> TickerPrice();
        /// <summary>
        /// Returns the latest trade price, best bid and best ask for each market.
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<List<TickerBook>>> TickerBook();
        /// <summary>
        /// Returns the latest trade price, best bid and best ask for a market.
        /// <param name="market"> Example: market=BTC-EUR. Filter used to specify for which market data should be returned</param>
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<TickerBook>> TickerBook(string market);
        /// <summary>
        /// Returns open, high, low, close, volume and volumeQuote for the last 24 hours for each market. Returns null if no data is available.
        /// </summary>
        /// <returns></returns>
        Task<RestResponse<List<Ticker24H>>> Ticker24H();
        /// <summary>
        /// Returns open, high, low, close, volume and volumeQuote for the last 24 hours for each market. Returns null if no data is available.
        /// </summary>
        /// <param name="market"> Example: market=BTC-EUR. Filter used to specify for which market data should be returned</param>
        /// <returns></returns>
        Task<RestResponse<Ticker24H>> Ticker24H(string market);
    }
}
