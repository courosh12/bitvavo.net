
# Bitvavo.net

.net/C# client for Bitvavo

## Rest client
First create a Bitvavo client: 
````csharp
            var bitvavoClient = new BitvavoClient();
````
Accessing the Exchange data for which u dont need api keys: 
````csharp
            var bitvavoClient = new BitvavoClient();
			//exchange data
            var orderBook = await bitvavoClient.ExchangeData.OrderBookAsync("BTC-EUR", 20);
            var trades = await bitvavoClient.ExchangeData.Trades("BTC-EUR", start: 100000);
            var candles = await bitvavoClient.ExchangeData.Candles("BTC-EUR", "5m");
            var market = await bitvavoClient.ExchangeData.TickerPrice("BTC-EUR");
            var markets = await bitvavoClient.ExchangeData.TickerPrice();
            var tickerbooks = await bitvavoClient.ExchangeData.TickerBook();
            var tickerbook = await bitvavoClient.ExchangeData.TickerBook("BTC-EUR");
            var ticker24hS = await bitvavoClient.ExchangeData.Ticker24H();
            var ticker24h = await bitvavoClient.ExchangeData.Ticker24H("BTC-EUR");
````