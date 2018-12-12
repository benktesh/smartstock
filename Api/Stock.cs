using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Stock
    {
        public Guid? Id { get; set; }
        public String Ticker { get; set; }
        public String Company { get; set;  }
        public Decimal? Price { get; set; }
    }
}
