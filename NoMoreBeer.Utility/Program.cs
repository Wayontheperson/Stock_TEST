using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Utility
{
    class Program
    {
        const string TrashChars = "& -.3?()+";

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\sync\603R\sources\NoMoreBeer\NoMoreBeer\data\stock.csv");

            List<Stock> stocks = new List<Stock>(lines.Length);

            foreach (var line in lines)
            {
                var tokens = line.Split(',');

                var stockName = tokens[1];
                var trashStrings = TrashChars.ToCharArray().Select(x => x.ToString());
                foreach (var trash in trashStrings)
                    stockName = stockName.Replace(trash, "");

                MarketType market = tokens[2] == "p" ? MarketType.Kospi : MarketType.Kosdaq;

                Stock stock = new Stock(stockName, tokens[0], market);
                stocks.Add(stock);
            }

            stocks = stocks.Distinct(new StockComparer()).ToList();

            StringWriter writer = new StringWriter();
            foreach (var stock in stocks)
            {
                writer.WriteLine($@"public const string {stock.Name} = ""{stock.YahooName}"";");
            }

            string code = string.Format(_template, writer.ToString());

            File.WriteAllText(@"C:\sync\603R\sources\NoMoreBeer\NoMoreBeer\generated\Stock.cs", code);
        }

        const string _template = @"namespace NoMoreBeer
{{
    public class Stock
    {{
        {0}
    }}
}}
";
    }
}
