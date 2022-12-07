# Prototype Pattern


## Description
The prototype pattern belongs to the creational patterns group, which means it is a pattern that deals with object creation. </br>
This is the last creational pattern that will be covered.</br>
</br>
The intent of the pattern is to specify the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.</br>
In other words, it lets us copy existing objects without making the client code dependent on their concrete classes.  </br>
</br>
It is a pretty easy pattern, but as with most of these pattern definitions, they are easier to understand with an example.</br>
Imagine we have a system which we work with people. We can simply create new people by renewing instances of a Person class or, </br>
more realistically, assuming that Person is an abstract class, an Employee or Manager class, that derives from Person. </br>
Now imagine the use case where most property or field values of an existing object are required in a new object. </br>
Or maybe you even need all property values of the new object to match the existing object. In that case, we can simply copy them over. </br>
But that requires the client to have intrinsic knowledge of the concrete classes we are working with, Employee and Manager. </br>
It also needs to know how to create them. 


## Pattern Structure 
Client --------------> Prototype
		            |             |
ConcretePrototype1            ConcretePrototype2![image](https://user-images.githubusercontent.com/42718910/206132149-90815eaa-ceb0-4d74-8eba-1054fe8e52cb.png)



## What about the ICloneable interface?
.NET includes an interface named the IClonable interface. We could use that. </br>
It enable us to provide a customized implementation that creates a copy of an existing object.</br>
The ICloneable interface contains one member, the clone method, which we could implement. </br>
</br>
So why not use that. We could, but there are a few disadvantages. </br>
* One, the ICloneable interface simply requires that your implementation of the Clone method returns a copy of the current object instance. It does not specify whether the cloning operation performs a deep copy, a shallow copy, or something in between.
* Two, it also doesn't require all property values of the original instance to be copied to the new instance.
* Three, it returns an object, which means the client could need an additional cast. 
</br>
So, you can indeed use it, but I would advise not to.


## Use case
This pattern is useful when a system should be independent of how its objects are created and to avoid building a set of factories that mimics the class hierarchy.</br>
For example, class A deriving from class B, deriving from class C, potentially with all of them having properties of type class D, E, or F. </br>
Creating such a hierarchy with factories would lead to a lot of boilerplate code, which is to be avoided. </br>
</br>
Another good use case is when a system should be independent of how its objects are created, and when instances of a class can have one of only a few different combinations of states.</br>
In those cases, starting from a clone will often be more convenient than starting from an instance with default values.


## Consequences
Much of the consequences are related to the abstract factory and builder consequences. </br>
Prototype hides the ConcreteProduct classes from the client, which reduces what the client needs to know.</br>
It doesn't need to know about the concrete classes of the objects of which you want a copy. </br>
</br>
A positive prototype-specific consequences is reduced subclassing. </br>
Instead of having to create a factory method to make a new object, you can simply clone an existing one. </br>
</br>
A potential liability is that each implementation of the prototype base class must implements its own clone method, which might not always be convenient. 


## Related patterns
Prototype and abstract factory can be used together. </br>
A factory might store a set of prototypes from which it clones when a new instance is requested.</br>
There is also an relation to another creational pattern, the factory method pattern. </br>
</br>
Prototypes don't require subclassing creators. </br>
They are not based on inheritance, which is a plus when you favor composition over inheritance, like the Gang of Four.</br>
However, they often require an initialize operation on the Product class, which the factory method doesn't. </br>
Factory method is based on inheritance, but doesn't require that initialization step. </br>
Prototype can also be implemented as a singleton, which means it is related to that pattern. </br>
</br>
Lastly, when using the composite and decorator patterns, both structural, the prototype can be beneficial for convenient object creation.</br>
</br>
</br>
* Abstract factory - A factory might store a set of prototypes from which it clones when a new instance is requested.
* Factory method - Factory method is based on inheritance, but doesn't require an initialization step.
* Singleton - Prototype can be implemented as a singleton.
* Composite - Can use prototype for convenient object creation.
* Decorator - Can use prototype for convenient object creation.
