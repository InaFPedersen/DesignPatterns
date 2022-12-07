using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// Concrete Creator
    /// </summary>
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;

        public CountryDiscountService(string countryIdentifier) => _countryIdentifier = countryIdentifier;

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    // if you are from Norway, you get a better discount :)
                    case "NO":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }
}
