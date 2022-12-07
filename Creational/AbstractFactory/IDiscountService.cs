using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// <summary>
    /// Abstract Product
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }
}
