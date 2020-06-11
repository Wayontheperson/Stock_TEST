using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer
{
    /// <summary>
    /// 주가
    /// </summary>
    public class Price
    {
        private Price(DateTime date, decimal value)
        {
            Date = date;
            Value = value;
        }

        /// <summary>
        /// 일자
        /// </summary>
        public DateTime Date { get; }
        
        /// <summary>
        /// 주가(수정 종가)
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// 전일 대비 등락률
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 문자열을 해석하여 Price 객체를 만든다.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Price Parse(string line)
        {
            try
            {
                string[] tokens = line.Split(',');
                DateTime date = DateTime.Parse(tokens[0]);
                decimal value = decimal.Parse(tokens[4]); // Adj. Close 아님

                return new Price(date, value);
            }
            catch
            {
                return null;
            }
        }
    }
}
