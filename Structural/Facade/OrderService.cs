using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    /// <summary>
    /// Subsystem 
    /// </summary>
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            //Does the customer have enough orders?
            //Fake calculation for demo purposes
            return (customerId > 5);
        }
    }
}
