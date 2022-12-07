using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Concrete Factory
    /// </summary>
    public class EnglandShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new EnglandDiscountService();
        }

        public IShippingCostsService CreateShippingCostsService()
        {
            return new EnglandShippingCostsService();
        }
    }
}
