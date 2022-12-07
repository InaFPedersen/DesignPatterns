using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    /// <summary>
    /// Concrete Prototype
    /// </summary>
    public class Employee : Person
    {
        public Manager Manager { get; set; }

        public override string Name { get; set; }

        public Employee(string name, Manager manager)
        {
            Name = name;
            Manager = manager;
        }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
