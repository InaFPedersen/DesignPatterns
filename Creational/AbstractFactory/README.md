# Abstract Factory Pattern


## Description
The abstract factory is a creational pattern from the well-known Gang of Four design patterns. </br>
It is closely related to the factory method pattern which we already covered. It is often implemented by using factory methods.</br>
The abstract factory pattern is sometimes also referred to as the factory pattern, and so is the factory method better. </br>
</br>
The intent of the abstract factory pattern is to provide an interface for creating families of related or dependent objects without specifying their concrete classes.</br>
When we looked into the factory method pattern, we used a discount service example to clarify it. </br>
We can extend that example to get a good use case for the abstract factory pattern. </br>
</br>
In the example for factory method, we stated that everyone from Belgium got a 20% discount and everyone else got a 10% discount.</br>
This is something typically used in a shopping cart scenario, but if you want to make that scenario a bit closer to life, you need more than just a discount service that is dependent on the country.</br>
Shipping costs will also differ per country, and they belong together. </br>
We could implement this by simply create new instances of all this, but then we would run into likewise issues as we had before, implementing the factory method pattern. Tight coupling. 

## Pattern Structure 
              Client                                                                  ConcreteProductA1
                 |                                                                           |
             AbstractFactory                                                 -------> AbstractProductA
             IShippingCostsService CreateShippingCostsService()  ------------|
             IDiscountService CreateDiscountService()                        --------> AbstractProductB
                 |                                                                           |
         ConcreteFactory1                                                             ConcreteProductB1

## Use case
You can use the abstract factory pattern when a system should be independent of how its products are created, composed and represented. </br>
Our real-life example in the codes, nicely illustrated this. The client doesn't know about these concerns. </br>
</br>
Closely related to this, use it when you want to provide a class library of products and you only want to reveal their interfaces and not their implementations. </br>
The decoupling between client and factory and product is a win in this regard. </br>
</br>
Also, use it when a system should be configured with one of multiple families of products. </br>
As we learned, the abstract factory deals with product families, products that belong together. In that way, it is different from the factory method pattern.</br>
</br>
Also, use it when a family of related product objects is designed to be used together and you want to enforce this constraint. 

## Consequences
This pattern, as most, has a few benefits and liabilities. </br>
First, it isolates concrete classes because it encapsulates the responsibility and the process of creating product objects.</br>
In other words, clients are isolated from implementation classes, and that is mostly an advantage because it means that we are avoiding tight coupling.</br> 
</br>
You can thus, easily introduce new products without breaking client code. That means we are adhering to the open/closed principle from the SOLID coding principles. </br>
</br>
Also, seeing the code to create product is contained in one place, we are adhering to the single responsibility principle as well. </br>
It also makes exchanging product families easy. </br>
Seeing the class of a concrete factory only appears once in an application where you instantiate it, it is easy to change that concrete factory.</br>
You can switch it out for another one by changing that one line of instantiating code as the rest of the system works on the interface and not on the implementation.</br>
</br>
It also promotes consistency among products. This is because products in the same family are created by the same factory. </br>
Seeing an application only uses one abstract factory at a time, the products that are used are related and compatible with each other. </br>
</br>
A potential disadvantage is that supporting new kinds of products is rather difficult. </br>
If you want to extend the abstract factory, you have to change the factory interface, which also means changing the implementation of all of its subclasses. 

## Comparing the Abstract Factory to the Factory Method
Abstract factory is closely related to factory method. In fact, both are sometimes referred to as the factory pattern.</br>
As they are creational patterns they are both about creating objects. But there is more ways of doing that. </br>
In fact, two more creational patterns are coming up next. So, why are these two so closely related?</br>
Abstract factory and factory method can be combined.</br>
</br>

Factory Method | Abstract Factory
-------------- | ----------------
Exposes an interface with a method on it, the factory method, to create an object of a certain type. | Exposes an interface to create related objects: families of objects. Multiple methods are exposed on the abstract factory
The return type is never an object, it is in fact a interface or an abstract base class. | The return types of these methods are interfaces of abstract classes.
The factory method only produces one product. | Abstract factory produces families of products.
Creates objects through inheritance by implementing the interface or abstract base class with the factory method on it. | Creates families of objects through composition instead of inheritance. It contains fields that hold the concrete factories that are used for creating concrete products




## Related patterns
Abstract factory classes are often implemented with factory methods, as we just covered. </br>
</br>
But they can also be implemented using the prototype pattern. </br>
</br>
Also a concrete factory, so an abstract factory implementation, is often implemented as a singleton.</br>
</br>
* Factory method - Abstract factory can be implemented using factory methods.
* Prototype - Abstract factory can be implemented using prototypes.
* Singleton- A concrete factory is often implemented as a singleton
