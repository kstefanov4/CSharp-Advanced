using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private ICollection<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public ICollection<Stock> Portfolio { get => portfolio; set => portfolio = value; }

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {

            if (stock.MarketCapitalization >= 10000 && MoneyToInvest >= stock.PricePerShare && !portfolio.Contains(stock))
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }

        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }
            else
            {
                if (sellPrice < stock.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }

                Portfolio.Remove(stock);
                MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";


            }
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0)
            {
                return null;
            }
            else
            {
                return Portfolio.OrderByDescending(x => x.MarketCapitalization).First();
            }

        }

        public string InvestorInformation()
        {
            return
                $"The investor {FullName} with a broker {BrokerName} has stocks:" + Environment.NewLine +
                string.Join(Environment.NewLine, Portfolio);
            
            /*StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks: ");

            foreach (Stock stock in Portfolio)
            {
                sb.Append(stock);
                sb.AppendLine();
            }

            return sb.ToString().Trim();*/
        }
    }
}
