using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    /// <summary>
    /// Flyweight
    /// </summary>
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }
}
