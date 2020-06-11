using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace NoMoreBeer
{
    public class PriceRepository
    {
        #region singleton

        private PriceRepository()
        {
        }

        private static PriceRepository _instance = null;

        public static PriceRepository Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PriceRepository();

                return _instance;
            }
        }

        #endregion


        /// <summary>
        /// 특정 종목의 특정일 이후의 주가를 가져온다.
        /// </summary>
        /// <returns></returns>
        private List<Price> LoadFromFile(string filePath, DateTime fromDate)
        {
            string[] lines = File.ReadAllLines(filePath);

            List<Price> prices = new List<Price>(lines.Length);

            for (int i = 1; i < lines.Length; i++)
            {
                //Price price = new Price(lines[i]);
                Price price = Price.Parse(lines[i]);

                if (price == null)
                    continue;

                if (price.Date >= fromDate)
                    prices.Add(price);
            }

            for (int i = 1; i < prices.Count; i++)
            {
                prices[i].Rate = prices[i-1].Value.GetRate(prices[i].Value);
            }

            return prices;
        }/// <summary>
        /// 특정 종목의 특정일 이후의 주가를 가져온다.
        /// </summary>
        /// <param name="stockName">종목</param>
        /// <param name="fromDate">특정일</param>
        /// <returns></returns>
        public List<Price> Load(string stockName, DateTime fromDate)
        {
            return LoadFromFile($@"data\{stockName}.csv", fromDate);
        }

        public List<Price> LoadFromWeb(string stockCode, DateTime fromDate)
        {
            string localPath = $"{stockCode}.csv";

            string url = $"https://query1.finance.yahoo.com/v7/finance/download/{stockCode}?period1=946944000&period2=1591747200&interval=1d&events=history";

            WebClient web = new WebClient();
            web.DownloadFile(url, localPath);

            try
            {
                return LoadFromFile(localPath, fromDate);
            }
            finally
            {
                File.Delete(localPath);
            }
        }
    }
}