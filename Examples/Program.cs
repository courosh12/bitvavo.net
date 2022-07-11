using Bitvavo.net;

namespace Examples
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var bitvavoClient = new BitvavoClient();
            var orderBook = await bitvavoClient.ExchangeData.OrderBookAsync("BTC-EUR");
        }
    }
}