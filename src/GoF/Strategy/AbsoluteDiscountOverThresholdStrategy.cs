using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class AbsoluteDiscountOverThresholdStrategy : ISalePricingStrategy
    {
        private readonly decimal _threshold;
        private readonly decimal _absoluteDiscount;

        public AbsoluteDiscountOverThresholdStrategy(decimal threshold, decimal absoluteDiscount)
        {
            _threshold = threshold;
            _absoluteDiscount = absoluteDiscount;
        }

        public decimal GetTotal(Sale sale)
        {
            if (sale.Amount >= _threshold)
            {
                return sale.Amount - _absoluteDiscount;
            }

            return sale.Amount;
        }
    }
}