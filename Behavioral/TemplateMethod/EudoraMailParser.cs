using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class EudoraMailParser : MailParser
    {
        public override void FindServer()
        {
            Console.WriteLine("Finding Eudora server through a custom algorithm...");
        }

        public override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora");
        }

    }
}
