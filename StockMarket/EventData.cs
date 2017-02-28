using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket
{
    class EventData : EventArgs
    {
        public string stockName { get; set; }
        public int currentValue { get; set; }
        public int numberChanges { get; set; }
    }
}
