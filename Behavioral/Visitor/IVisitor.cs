using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    /// <summary>
    /// Visitor
    /// </summary>
    public interface IVisitor
    {
        /*void VisitCustomer(Customer customer);
        void VisitEmployee(Employee employee);*/

        void Visit(IElement element);
    }
}
