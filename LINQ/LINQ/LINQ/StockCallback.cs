using System;
using System.Linq;

namespace LINQ
{
    public interface IStockAlert
    {
        void Alert(string name, int oldQuantity, int newQuantity);
    }

    public class StockCallback : IStockAlert
    {
        private readonly Action<string, int> callback;
        private readonly int[] callbackThresholds;

        public StockCallback(Action<string, int> callback, int[] callbackThresholds)
        {
            this.callback = callback;
            this.callbackThresholds = callbackThresholds;
        }

        public void Alert(string name, int oldQuantity, int newQuantity)
        {
            if (callbackThresholds != null && callback != null)
            {
                int value;

                try
                {
                    value = callbackThresholds.Last(threshold => newQuantity < threshold && oldQuantity >= threshold);
                }
                catch (InvalidOperationException)
                {
                    return;
                }

                callback(name, value);
            }
        }
    }
}
