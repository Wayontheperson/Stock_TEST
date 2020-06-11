using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Strategies
{
    /// <summary>
    /// 하루에 한 주씩 사는 전략
    /// </summary>
    public class OnePerDayStrategy : Strategy
    {
        protected override void Buy(List<Price> prices)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                BuyOne(prices[i]);
            }
        }
    }
}
