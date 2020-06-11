using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer
{
    /// <summary>
    /// 매수와 매도가 1차례씩 포함되어 있는 거래
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// 매수일
        /// </summary>
        public DateTime BuyOn { get; set; }
        
        /// <summary>
        /// 매수금액
        /// </summary>
        public decimal BuyValue { get; set; }
        
        /// <summary>
        /// 매도일
        /// </summary>
        public DateTime SellOn { get; set; }
        
        /// <summary>
        /// 매도금액
        /// </summary>
        public decimal SellValue { get; set; }
        
        /// <summary>
        /// 수익률
        /// </summary>
        public decimal Rate { get; set; }

        public override string ToString()
        {
            return $"{BuyOn:d} : {BuyValue:N0} -> {SellValue:N0} ({Rate:P2})";
        }
    }
}
