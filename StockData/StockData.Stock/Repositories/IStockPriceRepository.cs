using StockData.Data;
using StockData.Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Repositories
{
    public interface IStockPriceRepository:
        IRepository<StockPrice, int>
    {
    }
}
