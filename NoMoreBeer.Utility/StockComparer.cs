using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Utility
{
    public class StockComparer : IEqualityComparer<Stock>
    {
        public bool Equals(Stock x, Stock y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Stock obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
