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
    public class RomanHundredExpression : RomanExpression
    {
        //100 = C, 200 = CC, 300 = CCC, 400 = CD, 500 = D, 600 = DC, 700 = DCC, 800 = DCCC, 
        //900 = CM.

        public override void Interpret(RomanContext value)
        {
            while ((value.Input - 900) >= 0)
            {
                value.Output += "CM";
                value.Input -= 900;
            }

            while ((value.Input - 500) >= 0)
            {
                value.Output += "D";
                value.Input -= 500;
            }

            while ((value.Input - 400) >= 0)
            {
                value.Output += "CD";
                value.Input -= 400;
            }

            while ((value.Input - 100) >= 0)
            {
                value.Output += "C";
                value.Input -= 100;
            }
        }
    }
}
