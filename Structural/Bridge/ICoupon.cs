using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
         int CouponValue { get; }
    }
}
