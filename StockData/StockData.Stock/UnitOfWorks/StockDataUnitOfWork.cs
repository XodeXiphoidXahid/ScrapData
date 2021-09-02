using StockData.Stock.Contexts;
using StockData.Stock.Repositories;
using StockData.Data;

namespace StockData.Stock.UnitOfWorks
{
    public class StockDataUnitOfWork : UnitOfWork, IStockDataUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public StockDataUnitOfWork(StockDbContext context,
            ICompanyRepository companies, IStockPriceRepository stockPrices)
            : base(context)
        {
            Companies = companies;
            StockPrices = stockPrices;
        }
    }
}
