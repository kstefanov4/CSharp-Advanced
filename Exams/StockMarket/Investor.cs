using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        private ICollection<Stock> portfolio;

        public Investor (string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
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
        public Icollection<Stock> Portfolio { get => portfolio; set => portfolio = value; }

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.MarketCapitalization && !portfolio.Contains(stock))
	        {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerSharer;
	        }
	        
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = Portfolio.FirsOrDefault(x => x.Name == companyName).FirstOrDefault();
            if (stock != null)
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
                return $"{companyName} was sold."

	        }
        }
        public Stock FindStock(string companyName)
        {
            Stock stock =
        }
    }
}
