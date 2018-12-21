using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data
{
    /// <summary>
    /// DbContext - to be replaced later with actual db calls.
    /// </summary>
    public static class DbContext
    {
        /// <summary>
        /// This is a temp data storage for now
        /// </summary>
        private static IList<Stock> result = GenerateMoreStocks();  

        public static IEnumerable<Stock> GetStocks()
        {
            if (result.Count == 0)
            {
                result = GenerateMoreStocks(); 
            }
           
            return result; 
        }

        private static IList<Stock>  GenerateMoreStocks()
        {
            return new List<Stock>
            {
                new Stock {Id = Guid.NewGuid(), Ticker = "AONE", Company = "Company1", Price = 100},
                new Stock {Id = Guid.NewGuid(), Ticker = "BONE", Company = "Company2", Price = 100},
                new Stock {Id = Guid.NewGuid(), Ticker = "CONE", Company = "Company3", Price = 100}
            };
        }


        public static IEnumerable<Stock> GetStock(String symbol)
        {
            if (result.Count == 0)
            {
                result = GenerateMoreStocks();
            }
            return result.Where(k => k.Ticker.Equals(symbol));
        }

        public static Stock SaveStock(Stock stock)
        {
            if (stock.Id == null)
            {
                result.Add(stock);
            }
            else
            {
                var index = result.IndexOf(result.First(i => i.Id == stock.Id));

                if (index != -1)
                    result[index] = stock;  
            }
            
            return result.Last();
        }

        public static bool DeleteStock(Guid id)
        {
            var temp = result.FirstOrDefault(k => k.Id == id);
            if (temp == null)
            {
                return false;
            }

            return result.Remove(temp);
        }
    }
}
