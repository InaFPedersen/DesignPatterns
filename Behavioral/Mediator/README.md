# Mediator Pattern


## Description
The mediator pattern is a behavioral pattern from the Gang of Four library of design patterns. </br>
The intent of the mediator pattern is to define an object, which is the mediator, that encapsulates how a set of objects interact.</br>
It does that by forcing objects to communicate via that mediator. </br>
By doing so, it promotes loose coupling by keeping objects from referring to each other explicitly, and it also lets you vary their interaction independently. </br>
</br>
For example, a set of objects that need to interact with each other. </br>
To be able to do that, these objects need to hold references to each other. </br>
If we are talking about just a few objects, that is still okay. But imagine that these are not a few objects, but tens, hundreds, or thousands of objects.</br>
Holding on to all of these references and managing them and keeping communication in sync becomes a real issue, really fast. Then we enter the mediator pattern.</br>
What this pattern does is provide a central object, which is the mediator. </br>
It maintains references of objects that want to communicate with each other, and it handles communication between them. </br>
By using the mediator pattern all this becomes more manageable. </br>
</br>
Let's map this to a real-life example. </br>
Imagine we are writing software for a team of people working at a bank, amongst them, account managers that sell banking products and lawyers that check these products for compliance. </br>
A part of the software we need to write is a chat application which needs to be custom built due to high security and confidentiality requirements. </br>
We could now create TeamMember objects that hold references to all other TeamMember objects that need to communicate with each other, but that is exactly what we don't want to do. </br>
</br>
Instead we will use the mediator pattern. We start with one central object, the ChatRoom. </br>
This is abstract. It defines the interface for communicating with team members. </br>
Remember, as usual with these patterns and as detailed in the introduction module, these patterns want to encourage working on interfaces and not on implementations. </br>
Technically, that means either an abstract class or an interface. </br>
</br>
Our lawyers and account managers are then concrete implementations of the TeamMember abstract base class. </br>
These are the objects that effectively receive and send messages through the ChatRoom. </br>
This TeamChatRoom thus holds the actual references to the team members. 


## Pattern Structure 
Mediator ------------------------------------->     Colleague
      |                                           |         |
      |                    I----------> ConcreteColleague1  |
ConcreteMediator   ----------------------------------->  ConcreteColleague2


## Use case
There is three good use cases when applying this pattern is something to consider. </br>
First, when a set of objects communicate in well-defined but complex ways, which results in interdependencies that are unstructured and difficult to understand. </br>
</br>
Two, when, because an object refers to and communicates with many other objects, it is difficult to reuse, in other words, when you got tight coupling between a set of likewise classes. </br>
Both the first and second apply to our real-life chatroom example. </br>
</br>
And lastly, when behavior that is distributed between several classes should be customizable without a lot of subclassing.</br>
In that case the mediator pattern can avoid a lot of that subclassing.</br>
What this means is that the mediator localizes behavior that would otherwise have to be distributed amongst different classes, and it does that because all relations between components are contained within the mediator.</br>
From that follows that when using the mediator, the colleague classes can be reused as is when the behavior has to be customized. </br>
It is contained within the mediator without requiring changes to or subclassing of the colleague glasses. 


## Consequences
There are five important potential consequences to this pattern. </br>
First of all, as we just detailed as last use case in the previous clip, it limits subclassing. </br>
</br>
A second consequence is that it decouples colleagues. Thanks to the mediator, they are now loosely coupled, instead of requiring the colleagues to know about each other. </br>
</br>
It also simplifies object protocols.</br>
What is meant by that is that interactions between objects that would normally be many-to-many interactions are replaced with one-to-many interactions between the mediator and its colleagues.</br>
These are simpler to maintain, extend, or understand. The open/closed principle also applies. </br>
</br>
New mediators can be introduced without having to change the components.</br>
</br>
And lastly, a disadvantage, mediator centralizes control, which, as a consequence, can make the mediator complex. </br>
That is a disadvantage, because it could turn your mediator in a monolith that is hard to maintain. </br>
</br>
* Limits subclassing
* Decouples colleagues
* Simplifies object protocols
* New mediators can be introduced without having to change the components.

* It centralizes control, which can make the mediator turn into a monolith.



## Related patterns
The first related pattern is a structural one, the facade pattern. </br>
Both mediator and facade organize collaboration between a lot of normally tightly coupled classes. </br>
But there are differences. Mediator, like facade, abstracts functionality of existing classes, but it is not the same. </br>
The purpose of the mediator is abstracting communication between objects, often centralizing functionality that doesn't belong in those objects. </br>
Facade, on the other hand, simply abstracts the interface to the subsystem objects to promote ease of use. </br>
</br>
* Facade - Mediator abstracts communication between objects. Facade abstracts the interface to the subsystem objects to promote ease of use.
</br>
</br>
When we look at some of the other patterns in this course, we find others that connect senders and receivers of requests. </br>
</br>
In that regard, chain of responsibility, command, mediator, and observer are all related. </br>
If you watched the module in which we tackled the command pattern, this would be familiar. </br>
</br>
Chain of responsibility passes the request along a chain of receivers that can be defined at runtime, until at least one handles it. </br>
</br>
Command connects senders which receivers unidirectionally, for example from a button that is pushed in a UI, to the action that finally gets executed. </br>
</br>
The mediator pattern, as we have just learned, eliminates direct connections altogether. Communication runs through that mediator. </br>
</br>
And lastly, the observer allows receivers of requests to subscribe and unsubscribe them at run time. 

