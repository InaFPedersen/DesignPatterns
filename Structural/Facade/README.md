# Facade Pattern


## Description
The facade pattern is a commonly used structural pattern from the well-known Gang of Four design patterns. </br>
</br>
The intent of the facade pattern is to provide a unified interface to a set of interfaces in a subsystem. </br>
It defines a higher-level interface that makes the subsystem easier to use. Let's think about that by studying a real-life example. </br>
</br>
You are building a system in which you want to know the discount a customer will receive. </br>
However, calculating this can be quite complicated. First of all, we need to call into a service that checks whether the customer has enough orders. </br>
Then, we need to calculate the discount base percentage, which depends on the customer. </br>
For example, the percentage can be different depending on the country the customer is from. </br>
</br>
Lastly, a factor must be taken into account depending on the day of the week. </br>
This is something you sometimes see at airfare sites.</br>
This calculation thus isn't to reveal, and it has to be done in different parts of your application. </br>
Putting a facade in front of it hides away the complexity. So, it is an abstraction and encourages reuse.</br>
A facade hides away the complexity of this calculation and encourage reuse.


## Use case
The first use case for this pattern is obviously when you want to provide a simple interface into a complex subsystem consisting of a bunch of subsystem classes.</br>
In that case, when the subsystem becomes more complex, this has no effect on clients using the facade.  </br>
</br>
It is also useful to consider this pattern when there are many dependencies between a client and the implementation classes of the abstraction.</br>
By putting a facade in between, you decouple the subsystem from the clients.</br>

## Consequences
There is three main consequences to this pattern. First of all, it shields clients from subsystems. </br>
That means that the number of objects that clients have to deal with are reduced. </br>
</br>
It also promotes weak coupling between the subsystem and its clients. </br>
The client is coupled to the facade, not to the subsystems per se. </br>
Thanks to that weak coupling, the subsystem components can vary without affecting the client. </br>
That is the open/closed principle from the SOLID coding principles at work. </br>
</br>
And lastly, even though it shields clients from subsystems, clients are not forbidden to use the subsystem classes if they want to. 

## Related patterns
From the creational family, there is the abstract factory pattern that this one relate to.</br>
It can be used together with the facade to provide an interface for creating subsystem objects while remaining independent of the subsystem. </br>
Abstract factory can also be used as an alternative to facade to hide platform-specific classes. </br>
</br>
Up next, from the behavioral family, the mediator pattern. </br>
Like facade, it abstracts functionality of existing classes, those subsystems in our example, but it is not the same.</br>
The purpose of the mediator is abstracting communication between objects, often centralizing functionality that doesn't belong in those objects. </br>
Facade on the other hand, simply abstracts the interface to the subsystem objects to promote ease of use. </br>
</br>
It is also related to the adapter pattern. </br>
With adapter, you are making an existing interface usable by wrapping one object. </br>
With the facade, you are defining a new interface for an entire subsystem of objects. </br>
</br>
* Abstract Factory - Can provide an interface for creating subsystem objects.
* Mediator - Also abstracts functionality of existing classes, but its purpose is abstracting communication between objects, while facade is about promoting ease of use. 
* Adapter - Adapter makes existing interfaces useable by wrapping one object, while with facade you are defining a new interface for an entire subsystem. 
