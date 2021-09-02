using StockData.Stock.BusinessObjects;
using StockData.Stock.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IStockDataUnitOfWork _stockDataUnitOfWork;

        public CompanyService(IStockDataUnitOfWork stockDataUnitOfWork)
        {
            _stockDataUnitOfWork = stockDataUnitOfWork;
        }

        public void CreateCompany(string companyName)
        {
            _stockDataUnitOfWork.Companies.Add(
                new Entities.Company
                {
                    TradeCode=companyName
                });

            _stockDataUnitOfWork.Save();
        }
    }
}
