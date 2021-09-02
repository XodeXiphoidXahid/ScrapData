using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.Stock.Contexts;
using StockData.Stock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(StockDbContext context)
            : base((DbContext)context)
        {

        }
    }
}
