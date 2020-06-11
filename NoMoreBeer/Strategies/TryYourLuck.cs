using System.Collections.Generic;
using System.Linq;

namespace NoMoreBeer.Strategies
{
    public class TryYourLuck : Strategy
    {
        public static int n;
        protected override void Buy(List<Price> prices)
        {
            int i = 0;
            while (i <= prices.Count-32)
            {
                decimal avg = prices.Skip(i).Take(i+30).Average(x => x.Value);
                if (prices[i+31].Value <= avg)
                {
                    BuyOne(prices[i+31]);
                    n = i + 31;
                }

                i++;
            }
                
        }
        
        protected override void Sell(List<Price> prices)
        {
            int i = 1;
            while (i<=prices.Count)
            {
                if (prices[i].Value>58000)
                { 
                    break;
                }
                i++;
            }
            foreach (var trade in Trades)
            {
                SellOne(trade, prices[i]);
            }

        }
    }
}
