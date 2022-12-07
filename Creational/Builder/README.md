# Builder Pattern


## Description
The builder pattern is a common creational pattern from the Gang of Four. </br>
It deals with object creation, complex objects in this case, because the intent of the builder design pattern is to separate the construction of a complex object from its representation.</br>
In other words, it lets us construct complex objects step by step. By doing so, the same construction process can create different representations.</br>
</br>
Let's explain that definition with a real-life example:</br>
A very typical example of the builder pattern in real life is a piece of software for a garage that, at a certain point, requires you to construct cars.</br>
We can consider such a car as a complex object consisting of different parts, say a frame, and an engine in this example. </br>
But not all cars are constructed in the same manner. A three-door Mini has a different frame and engine than a five-door BMW for example, so the builder for these is different. </br>
This is a prime example of where the builder pattern shines.</br> 
</br>
We will have a builder for a car, and on it methods to build the engine, build a frame, and so on. And also a way to return a car, for example via a car property.

## Pattern Structure 
 
  Director ---------------->  Builder 
		             |       | 
            ConcreteBuilderA         ConcreteBuilderB   
                          |                       |
                          --------> Product <------

## Use case
You can use this pattern when you want to make the algorithm for creating a complex object independent of the parts that makes up the object and how they are assembled.</br> 
</br> 
You can also use it when you want the construct process to allow different representations for the object that is constructed. </br> 
In our case, we want to build a car.  Different builder implementations allow for different representations of that car.

## Consequences
One of the basic consequences of the builder pattern is that it lets us vary a product's internal representation. </br> 
As you know the builder provides the director with an interface for constructing the product. </br> 
Like that, the interface lets the builder hide the representation and internal structure of the product. </br> 
This also makes it easy to change a product's representation. All you need to do is add a new kind of builder.</br> 
</br> 
Next to that, it isolates code for construction and representation. </br> 
This is the single responsibility principle from the SOLID coding principles. </br> 
It then improves modularity by encapsulating the way a complex object is constructed and represented. </br> 
Clients don't need to know anything about the internal structure of the product.</br> 
</br> 
It also gives us finer control over the construction process. </br> 
The product is created in different steps instead of in one go, and each of these steps is under the director's control.</br> 
</br> 
A negative consequence is that the complexity of our code increases because we are often creating multiple new classes.

## Related patterns
The builder pattern is related to the abstract factory pattern as both can be construct complex objects. </br> 
The main difference is that the builder constructs the complex objects step by step.</br> 
</br> 
It also relate to the singleton pattern as the builder can be implemented as a singleton.</br> 
</br> 
And lastly, it is related to a structural pattern, the composite pattern, as composites are often built by builders.</br> 
</br> 
* Abstract factory - Both can be used to construct complex objects, but the builder  constructs the complex objects step by step.
* Singleton - A builder can be implemented as a singleton.
* Composite - Composite are often built by builders.
