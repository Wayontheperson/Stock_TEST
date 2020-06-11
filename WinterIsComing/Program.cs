using System;
using System.Collections.Generic;
using System.Linq;

namespace WinterIsComing
{
    class Program
    {
        public const decimal Interest = 0.01M; // 월 수익률
        public const decimal Beer = 500_000M; // 월 투자액
        public const int Period = 360; // 투가기간 (월)
        
        static void Main(string[] args)
        {
            List<Invest> invests = new List<Invest>(Period);
            for (int i = 0; i < invests.Capacity; i++)
            {
                Invest invest = new Invest(DateTime.Today.AddMonths(i));
                invests.Add(invest);
            }

            foreach (var invest in invests)
            {
                invest.Run(DateTime.Today.AddMonths(Period));
                Console.WriteLine(invest);
            }

            decimal sumOfBeer = Beer * Period;
            decimal sumOfStock = invests.Sum(x => x.Final);
            decimal rateOfSum = (sumOfStock - sumOfBeer) / sumOfBeer; 
            Console.WriteLine($"{sumOfStock:N0} - {sumOfBeer:N0} = {sumOfStock - sumOfBeer:N0} ({rateOfSum:P2})");
        }
    }
}