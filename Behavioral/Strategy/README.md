# Strategy Pattern


## Description
The strategy pattern is a behavioral pattern from the Gang of Four library of design patterns, and probably one of the most often used behavioral pattern that exist. </br>
</br>
Its intent is to define a family of algorithms, encapsulate each one, and make them interchangeable. </br>
Strategy lets the algorithm vary independently from clients that use it. </br>
In other words, you define a family of algorithms, put each one in a separate class, and make them interchangeable. </br>
</br>
Imagine the following use case. You are working on a part of a system that manages orders. </br>
At a certain moment, a business requirement comes in. The order needs to be exportable as a CSV file.</br>
You can solve that by adding an Export method on the order that creates this CSV file. </br>
</br>
A bit later, another requirement comes along. You need to support exporting to JSON as well. This is still manageable.</br>
You can accept a parameter in the export method, exportFormat, and depending on the parameter value, execute another piece of code.</br> 
</br>
It appears that two formats are still not good enough. Next you have to add support to XML as well.</br>
And now it is starting to be more difficult to manage.</br>
You could continue on the same route, adding additional format type and extending the conditional statement in the Export method, but this approach has some disadvantages. </br>
The order class is becoming more complex with all this export logic contained in it. </br>
When you want to change export logic or add new ways to export, you always have to change the order class.</br>
This definitely means that the order class is starting to have too much responsibilities, and you can partially solve that by adhering to the single responsibility principle. </br>
</br>
You can put the different types of export functionalities in classes of their own, CSVExportService, JSONExportService, XMLExportService, and so on.</br>
And store instances of those on the Order class. In the export method, the correct instance is then used, depending on the inputted exportFormat parameter. </br>
That also means that the Order class is now responsible for the lifetime management of the different export services.</br>
And you have tightly coupled the Order class to these implementations. That still makes it hard to add export functionality for new formats. </br>
</br>
Enter the strategy pattern, which solves these issues. </br>
The first thing we will do is declare an interface, IExportService. </br>
This declares one method, Export, which accepts the thing to export, the Order, in our case.</br>
</br>
Our three or potential more export service now become implementations of this interface, CSVExportService, JSONExportService, and XMLExportService. </br>
In the Export method implementation, the concrete export is handled. </br>
</br>
The order class then has a property of IExportService, which is set to one of the concrete implementations. </br>
Whenever Export is called on Order, the currently set IExportService implementation is used to handle the export. </br>
</br>
This means that the order object isn't responsible for selecting an appropriate algorithm, in other words, an interface implementation, for the job.</br>
It is the client that passes this implementation to the Order class. </br>
The Order class itself doesn't need to know about this. </br>
All it knows about is the interface and not the implementation. </br>
We have thus achieved loose coupling, making the order independent of the implementation, and that makes it easier to add new implementations or modify existing ones.</br>
There is no need to change the Order class to do so.


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368902-dc4e0629-f474-40aa-afaa-9f000ae5a8a7.png)



## Use case
You can use this pattern when many related classes differ only in their behavior, not in their interface.</br>
Strategies provide a way to configure a class with one of many behaviors, as we have seen with our three different export service implementations.</br>
</br>
You can also use it when you need different variants of an algorithm, which you want to be able to switch at runtime, an export algorithm to three different forms, for example.</br>
</br>
Another good use case is when your algorithm uses data, code or dependencies that the clients shouldn't know about. </br>
Imagine that exporting to a proprietary format needs some additional configuration or properties.</br>
The clients don't need to know about this or be allowed to change it. </br>
When they are working on an interface, they don't know about these, they only know about the export method existing.</br>
</br>
Lastly, use it when a class defines many different behaviors which appear as a bunch of conditional statements in its methods. </br>
In other words, when you are dealing with large if or switch statements. </br>


## Consequences
The strategy pattern offers an alternative to subclassing your context. Continuing with our example, we could have created an XML order subclass, a CSV order subclass, and so on.</br>
But that would have hardwired the behavior into the context, the order. That makes it harder to understand and maintain the context. The strategy pattern avoids that. </br>
In other words, you are replacing inheritance with composition, and that is one of the things the Gang of Four favors in OO design. </br>
</br>
Important as well is that new strategies can be introduced without having to change the context.</br>
That is the open/closed principle from the SOLID coding principles at work. </br>
</br>
Strategies also eliminate conditional statements. You don't need that anymore to select the required behavior because it's the client that injects it. </br>
</br>
Strategies can provide a choice of implementations with the same behavior if needed, and the client can choose which one fits best at runtime. </br>
</br>
This brings us to a drawback. If it is the client that injects the strategy to use, the client must be aware of how strategies differ, which means that they can be exposed to implementation issues.</br>
Therefore, only use this pattern when the variation in behavior is relevant to clients. </br>
</br>
There is also a bit of overhead in communication between the strategy and the context. </br>
For example, when creating export services, some of them might not export the full order, even though we do pass it through. </br>
</br>
And lastly, this pattern does introduce an additional number of objects. If you only have a few algorithms, it might not be worth the additional complexity. 


## Related patterns
The Gang of Four only defies one related pattern, the flyweight. That is because strategy objects often make good flyweights. But there is more than just this related pattern. </br>
</br>
Strategy, Bridge, and State are all related, and they look similar because they are all based on composition, but they solve different problems. </br>
The strategy pattern is also related to the template method pattern. Both are used to vary an algorithm. </br>
</br>
Template method allows varying part of an algorithm through inheritance, the subclass that implements the abstract base methods. </br>
It works at class level so this is static. Strategy, is based on composition. By providing different strategies, the objects behavior can be altered.</br>
It works at object level, so it is dynamic. Behaviors can be switched at runtime. </br>
</br>
* Flyweight - Strategy objects make good flyweights.
* Bridge - Also based on composition, but solves a different problem.
* State - Also based on composition, but solves a different problem.
* Template - Template method allows varying part of an algorithm through inheritance: a static approach. Strategy allows behavior to be switched at runtime, via composition: a dynamic approach. 
