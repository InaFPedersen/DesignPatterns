# Bridge Pattern


## Description
The bridge pattern is a commonly used structural pattern from the well-known Gang of Four design patterns. </br> 
They describe the intent of this pattern as to decouple an abstraction from its implementation so the two can vary independently,</br> 
in other words, be developed, be changed, independently. As with all these intent definitions, this requires a bit more explanation. </br> 
</br> 
You could rephrase this as this pattern aims to separate an abstraction of the class from the implementation. </br> 
As a result, this provides the means to replace an implementation with another implementation without modifying the abstraction.</br> 
</br> 
Abstraction in this context can be seen as a way to simplify something complex. Take for example, a console app that wants to write something.</br> 
Console.WriteLine() is an abstraction to whatever is contained within the WriteLine method. </br> 
So every action and function, for example, are abstractions. We are constantly using and creating them.</br> 
</br> 
Abstractions handle complexity by hiding the parts that we don't need to know about. </br> 
And this abstraction is what we are trying to decouple from its implementation. </br> 
When I hear things like separate abstraction from implementation, </br> 
"I'm" immediately thinking about interfaces and abstract classes, yet it is a bit more complicated than that. </br> 
</br> 
Let's clarify this with a real-world example.</br> 
Say we are creating a software for managing a restaurant register. There is two menus available, a meat-based menu and a vegetarian menu. </br> 
Both menu implementation expose a method, CalculatePrice. Depending on the menu, other fields are available, but those are not of interest right now.</br> 
The class that needs to add up the total amount owed can simply call into CalculatePrice on each menu. 

## Pattern Structure 
                              Abstraction  ----------------------------------------------->   Implementor
                              |         |                                                    |            |
              RefinedAbstraction        RefinedAbstraction                 ConcreteImplementorA          ConcreteImplementorB

## Use case
It is quite a few use cases for the bridge pattern. There is a reason for this pattern is very common. </br> 
A few of the more common ones are, first of all, when you want to avoid a permanent binding between an abstraction and its implementation,</br> 
for example when the implementation must be selected at runtime. Our coupon example showed that.</br> 
In other words, the bridge pattern enables switching implementations at runtime.</br> 
</br> 
Then, use it when abstraction and implementations should be extensible by subclassing.</br> 
The bridge pattern allows combining the different abstractions and implementations and extends them independently.</br> 
</br> 
Another good use case is for when you don't want changes in the implementation of an abstraction have an impact on the client.</br> 
As far as the client is concerned, this should be completely transparent thanks to loose coupling


## Consequences
Let's start with the first consequence, decoupling. The implementation isn't permanently bound to the abstraction.</br> 
It can be configured and potentially even changed at runtime. </br> 
Because of this decoupling, layering is encouraged, which typically results in a system that is better structured.</br>  
Another one is extensibility being improved. As the abstraction and implementation hierarchies are separate, they can evolve and be extended independently.</br> 
You can then introduce new abstractions and implementations independently of each other, which is the open/closed principle at work.</br> 
</br> 
Three, you can hide implementation details away from clients, which is a consequence of abstraction. </br> 
The pattern also allows focusing on high-level logic in the abstraction and on the details in the implementation. </br> 
By doing so, we can adhere to the single responsibility principle.


## Related patterns
The bridge pattern is related to the abstract factory pattern from the family of creational patterns.</br> 
Such a factory can create and configure a bridge, which hides complexity away from client code from the family of structural patters their relation to the adapter. </br> 
That pattern is used for making unrelated classes work together. </br> 
</br> 
The adapter adapts the adaptee for that. The bridge pattern, as we learned, is used to let abstractions and implementations vary independently. </br> 
</br> 
Strategy, Bridge, and State are all related and look similar because they are based on composition, even though they solve different problems. </br> 
</br> 
* Abstract factory - Factory can create and configure a bridge
* Adapter - Adapter lets unrelated classes work together, bridge lets abstractions and implementation vary independently
* Strategy - Based on composition, like bridge
* State  - Based on composition, like bridge
