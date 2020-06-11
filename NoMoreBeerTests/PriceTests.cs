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
    public class PriceTests
    {
        [TestMethod()]
        public void 문자열을_Price_객체로_파싱하면_null이_아니어야_함()
        {
            string line = "2000-01-05,5800.000000,6060.000000,5520.000000,5580.000000,0.082740,74680000";

            Price price = Price.Parse(line);

            Assert.AreEqual(new DateTime(2000, 1, 5), price.Date);
            Assert.AreEqual(5580, price.Value);
        }

        [TestMethod()]
        public void null이_포함된_문자열은_null로_반환되어야_함()
        {
            string line = "2000-01-05,5800.000000,6060.000000,5520.000000,null,0.082740,74680000";

            Price price = Price.Parse(line);

            Assert.AreEqual(null, price);
        }
    }
}