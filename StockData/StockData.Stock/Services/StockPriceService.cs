using HtmlAgilityPack;
using StockData.Stock.BusinessObjects;
using StockData.Stock.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Stock.Services
{
    public class StockPriceService: IStockPriceService
    {
        private readonly IStockDataUnitOfWork _stockDataUnitOfWork;
        private readonly ICompanyService _companyService;

        public StockPriceService(IStockDataUnitOfWork stockDataUnitOfWork, ICompanyService companyService)
        {
            _stockDataUnitOfWork = stockDataUnitOfWork;
            _companyService = companyService;
        }
        public void ScrapData()
        {
            var allRecords = LoadData();

            foreach (var record in allRecords)
            {
                _stockDataUnitOfWork.StockPrices.Add(
                new Entities.StockPrice
                {
                    CompanyId = record.CompanyId,
                    LastTradingPrice = record.LastTradingPrice,
                    High = record.High,
                    Low = record.Low,
                    ClosePrice = record.ClosePrice,
                    YesterdayClosePrice = record.YesterdayClosePrice,
                    Change = record.Change,
                    Trade = record.Trade,
                    Value = record.Value,
                    Volume = record.Volume
                }
                );

                _stockDataUnitOfWork.Save();
            }
        }
        public IList<StockPrice> LoadData()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");

            var wholeTable = doc.DocumentNode.SelectNodes
                ("//table[contains(@class, 'table table-bordered background-white shares-table fixedHeader')]");

            List<StockPrice> busObj = new List<StockPrice>();

            foreach (var table in wholeTable)
            {
                List<string> s = new List<string>();
                var htmlTableList = from row in table.SelectNodes("tr").Cast<HtmlNode>()
                                    from cell in row.SelectNodes("td").Cast<HtmlNode>()
                                    select new {Cell_Text = cell.InnerText };

                foreach (var cell in htmlTableList)
                {
                    
                    s.Add(cell.Cell_Text.ToString());
                }

                int cnt = 0;
                List<string> temp = new List<string>();
                 
                foreach (var i in s)
                {
                    cnt++;
                    temp.Add(i);

                    if (cnt == 11)
                    {
                        var obj = new StockPrice();

                        var companyName = temp.ElementAt(1);

                        var charsToRemove = new string[] { "\t", "\n", "\r" };
                        foreach (var c in charsToRemove)
                        {
                            companyName = companyName.Replace(c, string.Empty);
                        }
                        var existCompanyName = IsCompanyAlreadyExist(companyName);

                        if(!existCompanyName)
                        {
                            _companyService.CreateCompany(companyName);
                        }

                        var companyId = _stockDataUnitOfWork.Companies.GetAll().Where(x=>x.TradeCode==companyName).FirstOrDefault().Id;

                        obj.CompanyId = companyId;


                     

                        obj.LastTradingPrice = string.Equals("--", temp.ElementAt(2)) ? 0.0 : double.Parse(temp.ElementAt(2), CultureInfo.InvariantCulture);
                        obj.High = string.Equals("--", temp.ElementAt(3)) ? 0.0 : double.Parse(temp.ElementAt(3), CultureInfo.InvariantCulture);
                        obj.Low = string.Equals("--", temp.ElementAt(4)) ? 0.0 : double.Parse(temp.ElementAt(4), CultureInfo.InvariantCulture);
                        obj.ClosePrice = string.Equals("--", temp.ElementAt(5)) ? 0.0 : double.Parse(temp.ElementAt(5), CultureInfo.InvariantCulture);
                        obj.YesterdayClosePrice = string.Equals("--", temp.ElementAt(6)) ? 0.0 : double.Parse(temp.ElementAt(6), CultureInfo.InvariantCulture);
                        obj.Change = string.Equals("--", temp.ElementAt(7)) ? 0.0 : double.Parse(temp.ElementAt(7), CultureInfo.InvariantCulture);
                        obj.Trade = string.Equals("--", temp.ElementAt(8)) ? 0 : int.Parse(temp.ElementAt(8), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                        obj.Volume = string.Equals("--", temp.ElementAt(10)) ? 0 : int.Parse(temp.ElementAt(10), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                        obj.Value = string.Equals("--", temp.ElementAt(9)) ? 0.0 : double.Parse(temp.ElementAt(9), CultureInfo.InvariantCulture);

                        busObj.Add(obj);

                        temp.Clear();
                        cnt = 0;
                    } 
                }
            }
            return busObj;
        }
        private bool IsCompanyAlreadyExist(string companyName) =>
                _stockDataUnitOfWork.Companies.GetCount(x => x.TradeCode == companyName) > 0;
    }
}
