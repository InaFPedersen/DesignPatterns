using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class ThreadSafeLogger
    {
            protected ThreadSafeLogger() { }

            private static readonly Lazy<ThreadSafeLogger> _lazyLogger = new Lazy<ThreadSafeLogger>(() => new ThreadSafeLogger());

            private static ThreadSafeLogger? _instance;

            public static ThreadSafeLogger Instance
            {
                get
                {

                    return _lazyLogger.Value;
                }
            }

            public void Log(string message)
            {
                Console.WriteLine($"Message to log: {message}");
            }
        
    }
}
