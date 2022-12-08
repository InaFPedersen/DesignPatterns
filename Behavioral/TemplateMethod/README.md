# Template Method Pattern


## Description
The template method pattern is a ***Behavioral Pattern*** from the well-known Gang of Four library of design patterns.</br> 
</br>
Its intent is to define the skeleton of an algorithm in an operation, deferring some steps to subclasses. </br>
It lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure. </br>
</br>
Let's clarify this with an example.</br>
Imagine that we are writing part of an application that wants to make working with emails easier by accumulating mail across different mail servers and analyzing them.
The idea is that the company's proprietary artificial intelligence will ensure that your inbox services the email that are important to you.
To be able to do that, the software must connect to different mail servers and parsed mails. </br>
</br>
So we got a few classes, ExhangeMailParser, ApacheMailParser, EudoraMailParser, and so on. </br>
For the sake of the demo, we will assume that the parser parses one HTML mail at a time, by accepting an identifier. </br>
</br>
The thing is, a lot of what has to happen in the algorithm to parse, one mail is the same for these three classes.</br>
First, the server needs to authenticate to the server. That is probably a bit different for each implementation.</br>
Then the mail body must be parsed, and that is exactly the same for each of these parsers. We don't want that kind of code duplication.</br> 
</br>
What we can do is create an abstract base class with a template method on it. 
That template method, ParseMailBody, accepting an identifier calls the other three methods in a certain order.
The other three methods are this also defined on this abstract class. </br>
</br>
Subclasses like ExangeMailParser or EudoraMailParser call this template method on the base class to parse some mail.
We allow these subclasses to vary the algorithm by overriding abstracted methods.
We could make the AuthenticateToServer method abstract as it differs for each class.
That means that each subclass must implement this method.
We can also allow subclasses to optionally override the other methods as well, in case they would require changes by making them virtual. </br>
</br>
In Gang of Four lingo, these methods or operations are called hooks, and FindServer is one of them in our example. 
The only thing that absolutely must not be overridden is the template method itself.</br>
</br>
That is what the template method pattern is, a straightforward, often used pattern in OO design.


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206369015-b527a2b8-a5dd-4195-8e85-5e4d368d5440.png)


## Use case
Use this pattern when you want to implement invariant parts of an algorithm only once and want to leave it to subclasses to implement the rest of the behavior, the parts that can vary like our authenticate to server method.</br>
</br>
Also, use it when you want to control which part of an algorithm subclasses can vary. Those are the methods that you make virtual or abstract.</br>
</br>
Lastly, use it when you find yourself in a situation where you have a set of algorithms that don't vary much, maybe only in one or two methods. Those are the methods that you make virtual or abstract. 


## Consequences
Using this pattern comes with a few consequences. </br>
First of all, these template methods are a fundamental technique for code reuse, especially when creating class libraries.
That is because template methods are how you factor out common behavior by pulling it out into a parent class, thus removing code duplication.</br> 
</br>
A potential negative consequence is that template methods cannot be changed. The order of the methods they call, the skeleton, is fixed, and that may be too strict for some clients. </br>


## Related patterns
Factory method and template method are related patterns. 
You can even look at the factory method as a specialization of template method, aimed at object creation.
Often template methods use factory methods as part of their skeleton structure. </br>
</br>
It is also related to the strategy pattern. Both are used to vary an algorithm.
Template methods allows varying part of an algorithm through inheritance. 
The subclass implements the abstract base methods. It works at class level, so this is static.
Strategy is based on composition. By providing different strategies, the object's behavior can be altered.
It works at object level, making it dynamic. Behaviors can be switched at run time.</br>
</br>
* Factory method - Factory method can be viewed as a specialization of template method. Template methods often use factory methods as part of their skeleton structure.
* Strategy - Template method allows varying part of an algorithm through inheritance: a static approach. Strategy allows behavior to be switched at run time, via composition: a dynamic approach.
