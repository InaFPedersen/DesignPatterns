using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// Abstract Expression
    /// </summary>
    public abstract class RomanExpression
    {
        public abstract void Interpret(RomanContext value);
    }
}
