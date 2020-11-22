using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class NullPricingStrategy : ISalePricingStrategy
    {
        public decimal GetTotal(Sale sale)
        {
            return sale.Amount;
        }
    }
}
