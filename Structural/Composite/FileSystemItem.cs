using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    /// <summary>
    /// Component
    /// </summary>
    public abstract class FileSystemItem
    {
        public string Name { get; set; }
        public abstract long GetSize();

        public FileSystemItem(string name)
        {
            Name = name;
        }
    }
}
