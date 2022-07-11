using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitvavo.net
{
    public class BitvavoClient
    {
        public IExchangeData ExchangeData { get; }

        private readonly RestClient _restClient;
        private const string V2_API = "https://api.bitvavo.com/v2/";

        public BitvavoClient(IExchangeData exchangeData, RestClient restClient)
        {
            _restClient = restClient;
            ExchangeData = exchangeData;
        }

        public BitvavoClient()
        {
            _restClient = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri(V2_API)
            });

            ExchangeData = new ExchangeData(_restClient);
        }
    }
}
