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
    }
}
