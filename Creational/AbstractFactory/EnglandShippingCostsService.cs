using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Concrete Product
    /// </summary>
    public class EnglandShippingCostsService : IShippingCostsService
    {
        public decimal ShippingCosts => 25;
    }
}
