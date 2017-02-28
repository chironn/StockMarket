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
        private int _currentValue;
        private int _numberChanges;
        private Thread _thread;

        /// <summary>
        /// Delegate for stockEvent
        /// </summary>
        public event EventHandler<EventData> stockEvent;

        /// <summary>
        /// Constructor that intializes fields with constructor arguments
        /// </summary>
        /// <param name="StockName"></param>
        /// <param name="InitialValue"></param>
        /// <param name="MaximumChange"></param>
        /// <param name="notificationThreshold"></param>
        public Stock(string StockName, int InitialValue, int MaximumChange, int notificationThreshold)
        {
            this._stockName = StockName;
            this._initialValue = InitialValue;
            this._currentValue = this._initialValue;
            this._maximumChange = MaximumChange;
            this._numberChanges = 0;
            this._notificationThreshold = notificationThreshold;
            this._thread = new Thread(new ThreadStart(Activate));
            this._thread.Start();
        }

        /// <summary>
        /// loop the function performed by the thread.
        /// </summary>
        private void Activate()
        {
            for (;;)
            {
                Thread.Sleep(500);
                ChangeStockValue();
            }
        }

        /// <summary>
        /// Function performed by the thread
        /// </summary>
        private void ChangeStockValue()
        {
            Random randy = new Random();
            _currentValue += new Random().Next(1,_maximumChange);
            _numberChanges++;
            if ((_currentValue-_initialValue) > _notificationThreshold)
            {
                EventData evData = new EventData();
                evData.stockName = this._stockName;
                evData.currentValue = this._currentValue;
                evData.numberChanges = this._numberChanges;
                OnThresholdReached(evData);
            }
        }

        /// <summary>
        /// When event is flagged do this to handle the event. 
        /// </summary>
        /// <param name="evData"></param>
        private void OnThresholdReached(EventData evData)
        {
            EventHandler<EventData> handler = stockEvent;

            if (handler != null)
            {
                lock (Program.Lock1)
                {
                    handler(this, evData);
                }

            }
        }
    }

   
}