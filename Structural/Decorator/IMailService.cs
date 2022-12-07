using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }
}
