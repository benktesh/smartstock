using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        /// <summary>
        /// This method returns a list of stocks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Stock> GetStock()
        {
            return Data.DbContext.GetStocks();
        }

        /// <summary>
        /// This method searches for ticker and returns the list of matching the ticker.  
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        [HttpGet("{symbol}")]
        public IEnumerable<Stock> GetStock(String symbol)
        {
            return Data.DbContext.GetStock(symbol);
        }

        /// <summary>
        /// This method searches for ticker and returns the list of matching the ticker.  
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPost]
        public Stock PostStock(Stock stock)
        {
            return Data.DbContext.SaveStock(stock);
        }

        [HttpDelete("{id}")]
        public bool DeleteStock(Guid id)
        {
            return Data.DbContext.DeleteStock(id);
        }
    }
}