using System;
using System.Threading;

namespace StockMarket
{
    internal class Stock
    {
        private string _stockName;
        private int _initialValue;
        private int _maximumChange;
        private int _notificationThreshold;
        private Thread _thread;

        public Stock(string StockName, int InitialValue, int MaximumChange, int notificationThreshold)
        {
            this._stockName = StockName;
            this._initialValue = InitialValue;
            this._maximumChange = MaximumChange;
            this._notificationThreshold = notificationThreshold;
            this._thread = new Thread(new ThreadStart(Activate));
        }

        private void Activate()
        {
            while (true)
            {
                Thread.Sleep(500);
                ChangeStockValue();
            }
        }

        private void ChangeStockValue()
        {
            throw new NotImplementedException();
        }
    }
}