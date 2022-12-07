using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    /// <summary>
    /// Concrete Visitor
    /// </summary>
    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if (element is Employee)
            {
                VisitEmployee((Employee)element);
            }
        }

        public void VisitCustomer(Customer customer)
        {
            //Perscentage of total amount
            var discount = customer.AmountOrdered / 10;
            //Set it on the customer
            customer.Discount = discount;
            //Add it to the total amount
            TotalDiscountGiven += discount;
        }

        public void VisitEmployee(Employee employee)
        {
            //Fixed value depending on the amount of years employed
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            //set it on the employee
            employee.Discount = discount;
            //Add it to the total amount
            TotalDiscountGiven += discount;
        }
    }
}
