using System;
using System.Collections.Generic;

namespace StockMarket
{
    internal class StockBroker
    {
        private string _stockBrokerName { get; set; }
        static List<Stock> _listOfStock = new List<Stock>();


        public StockBroker(string StockBrokerName)
        {
            this._stockBrokerName = StockBrokerName;
        }

        internal void AddStock(Stock stock1)
        {

        }
    }
}