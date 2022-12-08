# Observer Pattern


## Description
The observer pattern is a behavioral pattern from the Gang of Four library of design patterns. </br>
</br>
The intent of the observer pattern is to define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. </br>
</br>
It is a pretty common pattern. For example, in Angular, you have got an Observable class that implements it. </br>
Also when you are working with microservices, you will often have services that subscribe to change events on other services to allow them to keep their data store in sync and so on. </br>
</br>
What we will use as an example is part of a ticketing management system. </br>
It exposes a bunch of services, all with their own data store that needs to be kept in sync, not unlike what you'd expect in a microservices architecture. </br>
For example, there is an OrderService that has a notion of a set of tickets for a certain artist. </br>
When the order is fulfilled, the tickets are no longer available, and it updates its data store. But our system knows of other services as well. </br>
</br>
There is a TicketStockService, which needs to be notified of the fact that the tickets are no longer there so it can update that in its data store. </br>
And then there is a TicketResellerService, which also needs to be notified of the fact that the tickets are no longer available.</br>
Other services that need to know about this can exist as well, but for this example we will use these three classes. </br>
</br>
In any case, we are deling with a system in which a set of related objects, which are our services, need to maintain consistency.We can easily achieve that. </br>
We could simply store a reference to the TicketStockService and TicketResellerService on our OrderService and let the OrderService call methods on them to notify them that the tickets have been solved. </br>
The problem is that this would introduce tight coupling. It would also become quite complex to manage once the amount of services that need to be notified started growing.</br>
And moreover, if we don't know in advance how many or which services need to be notified, this won't work at all. </br>
</br>
Enter the observer or pub/sub pattern. We will start with a base class, the TicketChangeNotifier. Our OrderService wll be a subclass of this.</br>
On the TicketChangeNotifier we implement methods to add and remove observers and also want to notify them. We won't add, remove, or notify concrete observers though. </br>
</br>
We will also work on an interface, say ITicketChangeListener. The interface defines one method, ReceiveTicketChangeNotification with the change in tickets as a parameter.  </br>
</br>
It is this interface that is implemented by our observers, the TicketStockService and TicketResellerService.</br>
</br>
What happens now is that our two observers are added as observers on our OrderService. </br>
The OrderService is a concrete implementation of the TicketChangeNotifier.</br>
It calls into the methods defined on that, but next to that, it also holds its state, for example the data store containing the information it has on tickets. </br>
Once a sale happens, the OrderService adjusts its state by updating its data store. It then notifies all observers of this change through the Notify method on its base class.</br>
And that method runs through all observers and calls ReceiveTicketChangeNotification on them. Like that each ConcreteObserver can update its own state accordingly. 


## Pattern Structure 

Subject ---------------------------> Observer
    |                                 |     |
    |        I--------- ConcreteObserverA   |
ConcreteSubject <------------------- ConcreteObserverB


## Use case
There are three main situations in which this pattern should be considered.</br>
One, when a change to one object requires changing others and you don't know in advance how many objects need to be changed. </br>
That is a pretty common scenario in pub/sub use cases. It is common in microservice architectures where services that need to be notified can change dynamically. </br>
</br>
Two, we use it when objects that observe others are not necessarily doing that for the total amount of time the application runs. The pattern allows you to remove and subscribe observers dynamically.</br>
</br>
Three, consider it when an object should be able to notify other objects without making assumptions about who those objects are. In other words, use it when you want to avoid tight coupling between these objects. 

## Consequences
The most important consequence of this pattern is that subjects and observers can vary independently. </br>
In other words, you can change one or add a new subclass of one, without having to change the other. This is inline with the open/closed principle of the SOLID coding principles. </br>
</br>
Very much related to that, subject and observer are loosely coupled. All the subject knows is that it has a list of observers that conform to an interface.</br>
It doesn't know about concrete implementations. This too is inline with the open/closed principle of the SOLID coding principles.</br>
</br>
Something to look out for our unexpected updates. In some implementations of this pattern, observers hold a reference to the subject and can change its state. </br>
Observers don't know about the potential consequences of this.  It can lead to a cascade of change notification. In our implementation, cannot do that. </br>


## Related patterns
When we look at some of the other patterns in this course, we find others that connect senders and receivers of requests. </br>
</br>
Chain of responsibility, command, mediator, and observer are all related. </br>
Chain of responsibility passes the request along a chain of receivers that can be defined at runtime, until at least one handles it, or none at all. </br>
</br>
Command connects senders which receivers unidirectionally, for example from a button that is pushed in a UI, to the action that finally gets executed.</br>
 </br>
The mediator pattern, as we have just learned, eliminates direct connections altogether. Communication runs through that mediator. </br>
</br>
And lastly, the observer allows receivers of requests to subscribe and unsubscribe them at run time. 