using System;
using System.Collections.Generic;
using System.IO;

namespace StockMarket
{
    internal class StockBroker
    {
        private string _stockBrokerName { get; set; }
        static List<Stock> _listOfStock = new List<Stock>();


        /// <summary>
        /// Constructor for stockbroker
        /// </summary>
        /// <param name="StockBrokerName"></param>
        public StockBroker(string StockBrokerName)
        {
            this._stockBrokerName = StockBrokerName;
        }

        /// <summary>
        /// Adds a stock to the list of stocks handled by a broker
        /// and registers function to stock event delegate.
        /// </summary>
        /// <param name="stock"></param>
        public void AddStock(Stock stock)
        {
            _listOfStock.Add(stock);
            stock.stockEvent += EventHandler;

        }

        /// <summary>
        /// Handles events in the Stock Program
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void EventHandler(object s, EventData e)
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\StockMarket.txt", true))
            {
                Console.WriteLine(_stockBrokerName.PadRight(15) + " " + e.stockName.PadRight(15) + e.currentValue.ToString().PadRight(10) + e.numberChanges.ToString().PadRight(10));
                outputFile.WriteLine(_stockBrokerName.PadRight(15) + " " + e.stockName.PadRight(15) + e.currentValue.ToString().PadRight(10) + e.numberChanges.ToString().PadRight(10));

            }
        }
    }
}