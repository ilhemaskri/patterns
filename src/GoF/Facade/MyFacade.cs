using GoF.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Facade
{
    public class MyFacade
    {
        private Sale sale;
        private ITimeSource source;

        public MyFacade(decimal amount, ISalePricingStrategy salePricingStrategy) {
            sale = new Sale(amount, salePricingStrategy);
            source = new TimeSource();
        }
        public decimal getAmount() {
            return sale.Amount;
        }

        public decimal getTotal() {
            return sale.GetTotal();
        }

        public DateTime getNow() {
            return source.Now;
        }
    }
}
