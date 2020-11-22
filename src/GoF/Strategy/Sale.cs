using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class Sale
    {
        private readonly ISalePricingStrategy _salePricingStrategy;

        public Sale(decimal amount, ISalePricingStrategy salePricingStrategy)
        {
            Amount = amount;
            _salePricingStrategy = salePricingStrategy;
        }

        public decimal Amount { get; }

        public decimal GetTotal()
        {
            return _salePricingStrategy.GetTotal(this);
        }
    }
}
