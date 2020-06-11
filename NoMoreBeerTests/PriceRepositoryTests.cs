using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoMoreBeer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer.Tests
{
    [TestClass()]
    public class PriceRepositoryTests
    {
        [TestMethod()]
        public void 종목과_시작일을_넘기면_해당하는_가격이_반환되어야_함()
        {
            var prices = PriceRepository.Instance.Load("삼성전자", new DateTime(2020, 6, 3));

            Assert.AreEqual(54500, prices[0].Value);
        }

        [TestMethod()]
        public void LoadFromWeb()
        {
            var prices = PriceRepository.Instance.LoadFromWeb(Stock.삼성전자, new DateTime(2020, 6, 3));

            Assert.AreEqual(54500, prices[0].Value);
        }
    }
}