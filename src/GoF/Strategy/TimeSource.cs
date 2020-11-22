using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Strategy
{
    public class TimeSource : ITimeSource
    {
        public DateTime Now => DateTime.Now;
    }
}
