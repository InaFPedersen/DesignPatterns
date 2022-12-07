using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAdapter
{
    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : ExternalSystem, ICityAdapter
    {
        public City GetCity()
        {
            // call into the external system
            var cityFromExternalSystem = base.GetCity();

            // adapt the CityFromExternalCity to a City
            return new City(
                $"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
                cityFromExternalSystem.Inhabitants);
        }
    }
}
