using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Utility
{
    public class Stock
    {
        public Stock(string name, string code, MarketType market)
        {
            Name = name;
            Code = code;
            Market = market;
        }

        public string Name { get; private set; }
        
        public string Code { get; private set; }

        public MarketType Market { get; private set; }

        public string YahooName
        {
            get
            {
                if (Market == MarketType.Kospi)
                    return Code + ".KS";
                else
                    return Code + ".KQ";
            }
        }
    }
}
