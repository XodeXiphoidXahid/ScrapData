using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.BusinessObjects
{
    public class StockPrice
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public double LastTradingPrice { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double ClosePrice { get; set; }
        public double YesterdayClosePrice { get; set; }
        public double Change { get; set; }
        public int Trade { get; set; }
        public double Value { get; set; }
        public int Volume { get; set; }
        public Company Company { get; set; }
    }
}
