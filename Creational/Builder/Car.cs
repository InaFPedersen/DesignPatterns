using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    /// <summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
	    {
		    var sb = new StringBuilder(); //Quick action to add using statement (system.text)
		    foreach (string part in _parts)
		    {
			    sb.Append($"Car of type {_carType} has part {part}. ");
		    }
		    return sb.ToString();
        }
    }
}
