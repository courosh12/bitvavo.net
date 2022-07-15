using Bitvavo.net.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bitvavo.net
{
    public class ExchangeData : IExchangeData
    {
        private readonly RestClient _restClient;
        private const string ORDERBOOK = "{market}/book";
        private const string TRADES = "{market}/trades";
        private const string CANDLES = "{market}/candles";
        private const string TICKERPRICE = "ticker/price";
        private const string TICKERBOOK = "ticker/book";
        private const string TICKER24H = "ticker/24h";

        public ExchangeData(RestClient restClient)
        {
            _restClient = restClient;
        }

        /// <inheritdoc />
        public async Task<RestResponse<OrderBook>> OrderBookAsync(string symbol, int? depth = null)
        {
            var request = new RestRequest(ORDERBOOK)
                .AddUrlSegment("market", symbol);

            if (depth.HasValue)
                request.AddParameter(nameof(depth), depth.Value);

            return await _restClient.ExecuteAsync<OrderBook>(request);
        }

        /// <inheritdoc />
        public async Task<RestResponse<List<Trade>>> Trades(string market, int? limit = null, long? start = null, long? end = null, string tradeIdFrom = null, string tradeIdTo = null)
        {
            var request = new RestRequest(TRADES)
                .AddUrlSegment("market", market);

            if (limit.HasValue)
                request.AddParameter(nameof(limit), limit.Value);

            if (start.HasValue)
                request.AddParameter(nameof(start), start.Value);

            if (end.HasValue)
                request.AddParameter(nameof(end), end.Value);

            if (tradeIdFrom != null)
                request.AddParameter(nameof(tradeIdFrom), tradeIdFrom);

            if (tradeIdTo != null)
                request.AddParameter(nameof(tradeIdTo), tradeIdTo);

            return await _restClient.ExecuteAsync<List<Trade>>(request);
        }

        /// <inheritdoc />
        public async Task<RestResponse<List<List<object>>>> Candles(string market, string interval, int? limit = null, long? start = null, long? end = null)
        {
            var request = new RestRequest(CANDLES)
                .AddUrlSegment("market", market);

            request.AddParameter(nameof(interval), interval);

            if (limit.HasValue)
                request.AddParameter(nameof(limit), limit.Value);

            if (end.HasValue)
                request.AddParameter(nameof(end), end.Value);

            if (start.HasValue)
                request.AddParameter(nameof(start), start.Value);

            if (end.HasValue)
                request.AddParameter(nameof(end), end.Value);

            return await _restClient.ExecuteAsync<List<List<object>>>(request);
        }

        /// <inheritdoc />
        public async Task<RestResponse<TickerPrice>> TickerPrice(string market)
        {
            var request = new RestRequest(TICKERPRICE);

            if (!string.IsNullOrEmpty(market))
                request.AddParameter(nameof(market), market);
            else
                throw new ArgumentException($"Argument {nameof(market)} is not set");

            return await _restClient.ExecuteAsync<TickerPrice>(request);
        }

        /// <inheritdoc />
        public async Task<RestResponse<List<TickerPrice>>> TickerPrice()
        {
            var request = new RestRequest(TICKERPRICE);
            return await _restClient.ExecuteAsync<List<TickerPrice>>(request);
        }

        public async Task<RestResponse<List<TickerBook>>> TickerBook()
        {
            var request = new RestRequest(TICKERBOOK);
            return await _restClient.ExecuteAsync<List<TickerBook>>(request);
        }

        public async Task<RestResponse<TickerBook>> TickerBook(string market)
        {
            var request = new RestRequest(TICKERBOOK);

            if (!string.IsNullOrEmpty(market))
                request.AddParameter(nameof(market), market);
            else
                throw new ArgumentException($"Argument {nameof(market)} is not set");

            return await _restClient.ExecuteAsync<TickerBook>(request);
        }

        public async Task<RestResponse<List<Ticker24H>>> Ticker24H()
        {
            var request = new RestRequest(TICKER24H);
            return await _restClient.ExecuteAsync<List<Ticker24H>>(request);
        }

        public async Task<RestResponse<Ticker24H>> Ticker24H(string market)
        {
            var request = new RestRequest(TICKER24H);

            if (!string.IsNullOrEmpty(market))
                request.AddParameter(nameof(market), market);
            else
                throw new ArgumentException($"Argument {nameof(market)} is not set");

            return await _restClient.ExecuteAsync<Ticker24H>(request);
        }
    }
}
