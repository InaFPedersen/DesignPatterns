# Decorate Pattern


## Description
The decorator pattern is a commonly used structural pattern from the well-known Gang of Four design patterns.</br>
</br>
The intent of the pattern is to attach additional responsibilities to an object dynamically. </br>
A decorator then provides a flexible alternative to subclassing for extending functionality. </br>
Just like the adapter pattern, this pattern is sometimes called a wrapper. </br>
</br>
Attaching additional responsibility or behavior to a class can easily be done by simply adding an additional method to the class. </br>
In this case, however, we need a way to attach additional responsibilities to an object and not to a class. We want to allow this dynamically, so at runtime.</br>
That is a bit more complicated, but not that much really. 
</br>The fact that this pattern is sometimes called a wrapper should already give you a good idea of how something like this can be implemented.</br>
</br>
Let's clarify this with a real-life example.</br>
In one of the other part it is an example with CloudMailService and a regular OnPremiseMailService to send mail.</br>
Both of these implement a simple IMailService interface, which exposes one method, SendMail.</br>
</br>
Now imagine that we will want to add some functionality to this service, say the wish is to start collecting some statistics.</br>
For example, how long does it take sending a mail, or how often is the SendMail method accessed? </br>
It could be added functionality to the different mail service implementations, but that violates the single responsibility principle for that class.</br>
Moreover, imagine that I want to add even more responsibilities, like logging when a mail is being sent or storing all the sent mail messages in a database somewhere. </br>
Our classes would get littered with code that doesn't belong there, and that is where the decorator pattern comes in.

## Pattern Structure 

                                          Component
                                          |   |   |
                         ConcreteComponent1   |   ConcreteComponent2
	                                      |
                                          Decorator
                                          |      |
                          ConcreteDecorator1    ConcreteDecorator2

## Use case
The first good use case for this pattern is when you have a need to add responsibilities to individual objects dynamically without affecting other objects. </br>
The example we just covered was, thus, a good use case. </br>
</br>
Another good use case for this pattern is when you need to be able to withdraw responsibilities you attached to an object.</br>
Decorators can be applied dynamically, and thus, also removed dynamically.  </br>
That is an advantage when, for example, you want to switch out storing mail messages in the database to another user store. </br>
Simply remove the message database decorator and, if needed, replace it. </br>
</br>
Lastly we can use this pattern when extension by subclassing is impractical or impossible, for example, when the class is sealed.


## Consequences
The first consequence of this pattern is that it is more flexible than using static inheritance via subclassing. </br>
Responsibilities can be added and removed at runtime ad hoc when needed. </br>
If you compare that to subclassing, which leads to increased complexity of your system when many different behaviors must be added, the decorator pattern is definitely preferable. </br>
</br>
The second consequence is that it avoids feature-loaded classes that don't respect the single responsibility principle.</br>
With this pattern, you can split that class up until there is just one responsibility per class, thus adhering to the single responsibility principle from the SOLID coding principles.</br>
</br>
The third consequence is that, this pattern does tend to litter your system with lots of small, simple classes. </br>
That is a disadvantage that potentially increases the effort required to learn and debug the system. 


## Related patterns
A few patterns are related to the decorator pattern.</br>
From the family of structural patterns, there is relation to the adapter pattern, </br>
but the adapter pattern gives a completely new interface to an object while the decorator pattern only changes its responsibilities. </br>
</br>
Another related structural pattern is the composite pattern. A decorator can be viewed as a composite with only one component. </br>
That being said, the decorator isn't intended for object aggregation while the composite pattern is.</br>
</br>
Lastly, a behavioral pattern, the strategy pattern. While the decorator pattern lets you change the skin, which is the outer side of an object, the strategy pattern lets you change the inner workings. </br>
So, both allow you to change an object, but in a different way.</br>
</br>
* Adapter - Adapter gives a new interface to an object, decorator only changes its responsibilities.
* Composite - Decorator can be seen as a composite with only one component.
* Strategy - Decorator lets you change the skin of an object, strategy lets you change its inner workings.
