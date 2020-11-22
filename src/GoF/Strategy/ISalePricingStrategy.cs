using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public interface ISalePricingStrategy
    {
        decimal GetTotal(Sale sale);
    }
}
