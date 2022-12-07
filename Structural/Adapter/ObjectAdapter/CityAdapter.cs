using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectAdapter
{
    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; private set; } = new();

        public City GetCity()
        {
            // call into the external system
            var cityFromExternalSystem = ExternalSystem.GetCity();

            // adapt the CityFromExternalCity to a City
            return new City(
                $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
                cityFromExternalSystem.Inhabitants);
        }
    }
}
