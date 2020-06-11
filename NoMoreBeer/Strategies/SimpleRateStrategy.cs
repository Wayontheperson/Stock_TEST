using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Strategies
{
    /// <summary>
    /// 전날보다 오른 날에만 매수하는 전략
    /// </summary>
    public class SimpleRateStrategy : Strategy
    {
        protected override void Buy(List<Price> prices)
        {
            for (int i = 1; i < prices.Count; i++)
            {
                if (prices[i].Rate > prices[i-1].Rate)
                {
                    BuyOne(prices[i]);
                }
            }
        }
    }
}
