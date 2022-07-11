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

        public ExchangeData(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<OrderBook> OrderBookAsync(string symbol, int? dept = null)
        {
            var request = new RestRequest(ORDERBOOK)
                .AddUrlSegment("market", symbol);

            if (dept.HasValue)
                request.AddParameter(nameof(dept), dept.Value);

            return await _restClient.GetAsync<OrderBook>(request);
        }

    }
}
