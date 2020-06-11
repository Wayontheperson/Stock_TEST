using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;

namespace WinterIsComing
{
    public class Invest
    {
        public Invest(DateTime date)
        {
            _date = date;
            _values.Add(Program.Beer);
        }

        private DateTime _date;

        private List<decimal> _values = new List<decimal>();

        public void Run(DateTime winter)
        {
            DateTime date = _date;
            
            while (date < winter)
            {
                decimal value = _values[^1] + _values[^1] * Program.Interest;
                _values.Add(value);

                date = date.AddMonths(1);
            }
        }

        public override string ToString()
        {
            StringWriter writer = new StringWriter();
            writer.WriteLine($"[{_date:Y}]");
            var values = _values.ConvertAll(x => x.ToString("N0"));
            writer.WriteLine(string.Join(" -> ", values));

            return writer.ToString();
        }

        public decimal Final
        {
            get
            {
                return _values[^1];
            }
        }
    }
}