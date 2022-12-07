using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// Terminal Expression
    /// </summary>
    public class RomanOneExpression : RomanExpression
    {
        //1 = I, 2 = II, 3 = III, 4 = IV, 5 = V, 6 = VI, 7 = VII, 8 = VIII, 9 = IX.

        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 9) >= 0)
            {
                value.Output += "IX";
                value.Input -= 9;
            }

            while ((value.Input - 5) >= 0)
            {
                value.Output += "V";
                value.Input -= 5;
            }

            while ((value.Input - 4) >= 0)
            {
                value.Output += "IV";
                value.Input -= 4;
            }

            while ((value.Input - 1) >= 0)
            {
                value.Output += "I";
                value.Input -= 1;
            }

        }

    }
}
