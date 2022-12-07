using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code) => _code = code;

        public override int DiscountPercentage
        {
            //Each code returns the same fixed percentage, but a code is only valid once
            //Include a check to so whether the code's been used before ....
            get => 15;
        }
    }
}
