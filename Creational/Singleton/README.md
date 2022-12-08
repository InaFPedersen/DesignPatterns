# Singleton Pattern


## Description
The singleton pattern is a ***Creational Pattern*** from the well-known Gang of Four design patterns. Creational patterns deal with object creation. </br>
</br>
The intent of the singleton pattern is to ensure that a class only has one instance, and to provide a global point of access to it. </br>
</br>
If you have worked with an inversion of control container before, you have undoubtedly encountered it as registering a type with a singleton lifetime is functionality offered by almost all of these containers.</br>
</br>
A very common example is a logger. You typically only want one logger instance for your whole application to avoid multiple instances interfering with each other, which could result in messages being logged multiple times or not at all.


## Use case
You can use this pattern: </br>

* When there must be exactly one instance of a class, and it must be accessible to clients from a well-known access point. Our logger is a prime example of that.

* It is also useful when the sole instance should be extensible by subclassing, and all clients should be able to use an extended instance without modifying their code. That is what we enabled by using a protected constructor.

## Consequences
There is quite a few consequences to this pattern. </br>
* Because the Singleton class encapsulates its sole instance, it has strict control over how and when clients access it. (This is an advantage)
* It is also better than global variables because it avoids polluting the namespace with global variables used for storing sole instances. 
* As the class can be subclassed, which enabled by the protected constructor, you can configure the application with an instance of the class you need at runtime. 
* Also, in case you change your mind and you want to allow multiple instances, you can achieve that without having to alter the client because instance management is now contained within the singleton itself.
* But there is also a disadvantage. The singleton pattern violates the single responsibility principle because objects not only control how they are created. They also manage their of lifecycle. 

In modern languages you don't often write code like this anymore as all of this is mostly dealt with via an IOC container.
In that case, it is no longer the responsibility of the singleton class itself to manage its own lifetime, but the IOC container takes on that responsibility.


## Related patterns
Many patterns are related to the singleton pattern, if only for the reason that they can be implemented as singletons.
* The Abstract Factory pattern, that can be implemented as a singleton.
* The Builder pattern, that can be implemented as a singleton.
* The Prototype pattern, that can be implemented as a singleton.
* The State pattern, also relates as state objects are often implemented as singletons.
