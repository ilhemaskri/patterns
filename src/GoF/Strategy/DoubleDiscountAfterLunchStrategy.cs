using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class DoubleDiscountAfterLunchStrategy : ISalePricingStrategy
    {
        private readonly ITimeSource _timeSource;
        private readonly decimal _percentageDiscount;

        public DoubleDiscountAfterLunchStrategy(ITimeSource timeSource, decimal percentageDiscount)
        {
            _timeSource = timeSource;
            _percentageDiscount = percentageDiscount;
        }

        public decimal GetTotal(Sale sale)
        {
            if (_timeSource.Now.Hour < 12)
            {
                return sale.Amount - ((sale.Amount / 100m) * _percentageDiscount);
            }

            return sale.Amount - ((sale.Amount / 100m) * (_percentageDiscount * 2));
        }
    }
}
