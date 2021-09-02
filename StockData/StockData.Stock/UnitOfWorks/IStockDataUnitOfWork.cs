using StockData.Stock.Repositories;
using StockData.Data;

namespace StockData.Stock.UnitOfWorks
{
    public interface IStockDataUnitOfWork: IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IStockPriceRepository StockPrices { get; }
    }
}