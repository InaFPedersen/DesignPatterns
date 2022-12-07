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
    public class RomanTenExpression : RomanExpression
    {
        //10 = X, 20 = XX, 30 = XXX, 40 = XL, 50 = 50 L, 60 = LX, 70 = LII, 80 = LIII, 90 = XC.

        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 90) >= 0)
            {
                value.Output += "XC";
                value.Input -= 90;
            }

            while ((value.Input - 50) >= 0)
            {
                value.Output += "L";
                value.Input -= 50;
            }

            while ((value.Input - 40) >= 0)
            {
                value.Output += "XL";
                value.Input -= 40;
            }

            while ((value.Input - 10) >= 0)
            {
                value.Output += "X";
                value.Input -= 10;
            }
        }
    }
}
