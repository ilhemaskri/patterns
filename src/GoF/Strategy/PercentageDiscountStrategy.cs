using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class PercentageDiscountStrategy : ISalePricingStrategy
    {
        private readonly decimal _percentageDiscount;

        public PercentageDiscountStrategy(decimal percentageDiscount)
        {
            _percentageDiscount = percentageDiscount;
        }

        public decimal GetTotal(Sale sale)
        {
            return sale.Amount - (sale.Amount / 100m * _percentageDiscount);
        }
    }
}
