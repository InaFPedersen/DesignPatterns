# Factory Method Pattern


## Description
The factory method pattern is a creational pattern from the well-known Gang of Four design patterns. Creational patterns deal with object creation, and using a factory method is a very common way of doing that. </br>
It is also known as a virtual constructor. These days, we don't really talk about the factory method pattern a lot anymore. We simply talk about the factory pattern. </br>
But if we want to be correct, the factory pattern can refer to either the factory method, or the abstract factory pattern. </br>

The factory method, its intent is to define an interface for creating an object, but to let subclasses decide which class to instantiate. Factory method let's a class defer instantiation to subclasses. </br>
</br>
With the example we will clarify this:</br>
Imagine that you are creating part of a shopping cart system. At a certain moment, a discount can be applied. </br>
One of the services that can provide the discount is a service that provides a discount depending on the country the user is in. </br>
Another one provides a discount depending on a discount code. So both services are not constructed in the same way, nor is the logic to calculate the actual discount the same.</br>
Yet, they do have something in common, the discount percentage that needs to be exposed. </br> 
We could write some code that makes new instances of these classes up and gets the discount percentage.  

## Pattern Structure
                                               Product 
                                            |           |
                         ---> ConcreteProductA         ConcreteProductB <---
                         |                                                 |
                         ConcreteCreatorA                   ConcreteCreatorB
                                        |                   |
                                               Creator

## Use case
Good use cases for this pattern are when a class can't anticipate the class of objects it must create, in other words when you don't know in advance which types of object your code should work with.</br> 
When that is the case, the concrete creators can take on this responsibility. 
</br> 
</br> 
Another good use case is when a class wants its subclasses to specify the objects it creates. </br> 
This enables the scenario in which standard components or classes can be extended via subclasses. </br> 
Here too, this means the concrete creator takes on the responsibility for creating the objects.
</br> 
</br> 
Up next, when classes delegate responsibility for creation to one of several helper subclasses and you want to localize the knowledge of which helper subclass is the delegate.</br> 
Localization of that knowledge is now at level of whichever part of your application is responsible for providing the concrete implementation of the creator that is needed.
</br> 
</br> 
And you can also use it as a way to enable reusing of existing objects. </br> 
The logic inside of the factory method can take care of either creating an object or reusing an existing one as it sees fit.</br> 
If you are renewing the instances yourself, you will either have to write code like that wherever you renew it or put it in a reusable method.</br> 
And that reusable method, that is the factory method.

## Consequences
The main consequence of this pattern is that factory methods eliminate the need to bind application-specific classes to your code, to the client for example. </br>
And that is because the code only deals with the interface, the product, and not with the concrete implementation. 
</br>
</br>
That means it can work with any concrete product implementation. In other words, you are avoiding tight coupling. </br>
It is this that enables adding new types of products without breaking client code. And that is the open/closed principle at work.</br>
The single responsibility principle is also adhered to.
</br>
</br>
Creating the products is moved to one specific place in your code, the creator, that is only responsible for that. 
</br>
</br>
A potential disadvantage is that clients might need to create subclasses of the creator class just to create a particular ConcreteProduct object.</br>
If only one subclass, so one concrete creator, is expected to be needed, you would have just added unnecessary complexity.

## Related patterns
Closely related to this pattern is the Abstract Factory pattern. It is often implemented with factory methods as we will see very soon in the module about Abstract Factory.
</br>
</br>
There is also a relation to another creational pattern, the prototype pattern. Prototypes don't require subclassing creators. </br>
They are not based on inheritance, which is a plus when you favor composition over inheritance, which the Gang of Four does. </br>
However, prototype pattern often require an initialize operation on the Product class, which the factory method doesn't. </br>
So, factory method is based on inheritance, but it doesn't require the initialization step. 
</br>
</br>
Lastly, there is also a relation to a behavioral pattern. Factory methods are usually called within template methods.
</br>
</br>
* Abstract Factory - Often implemented with factory methods.
* Prototype - No subclassing is needed (not based on inheritance), but an initialize action on Product is often required.
* Template - Factory methods are often called from within template methods.
