// var test = new Logger(); // Add using statement

//call the property getter twize
using Singleton;

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if (instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same");
}

instance1.Log($"Message from {nameof(instance1)}");
instance1.Log($"Message from {nameof(instance2)}");

Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");


Console.WriteLine();
Console.WriteLine("Making it ThreadSafe");

var instance3 = ThreadSafeLogger.Instance;
var instance4 = ThreadSafeLogger.Instance;

if (instance3 == instance4 && instance4 == ThreadSafeLogger.Instance)
{
    Console.WriteLine("Instances are the same");
}

instance1.Log($"Message from {nameof(instance1)}");
instance1.Log($"Message from {nameof(instance2)}");

Logger.Instance.Log($"Message from {nameof(ThreadSafeLogger.Instance)}");


Console.ReadLine();
