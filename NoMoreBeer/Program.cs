using NoMoreBeer.Strategies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer
{
    class Program
    {
        const string StockName = "삼성전자";
        static readonly DateTime FromDate = DateTime.Today.AddYears(-10);

        static void Main(string[] args)
        {
            var files = Directory.GetFiles("data", "*.csv");
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                Run(StockName, FromDate);
                Console.WriteLine(StockName);
                Console.ReadLine();
            }
        }

        private static void Run(string stockName, DateTime fromDate)
        {
            List<Price> prices = PriceRepository.Instance.Load(stockName, fromDate);

            //Strategy strategy = new OnePerDayStrategy();
            Strategy strategy = new SimpleRateStrategy();

            strategy.Trade(prices);

            Console.WriteLine(strategy);
            
            decimal marketRate = prices[0].Value.GetRate(prices[prices.Count - 1].Value);
            
            Console.WriteLine($"시장 : {marketRate:P2}");
        }
    }
}
