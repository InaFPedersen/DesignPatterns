# Command Pattern


## Description
The Command pattern is a ***Behavioral Pattern*** from the Gang of Four library of design patterns.
Behavioral patterns define ways to communicate between classes or objects, letting you concentrate on the way objects are interconnected. 
The command pattern is a very nice illustration of that. </br>
</br>
Its intent is to encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations. 
It just turns the request into a standalone object, and once we got an object, we have got something to work with and/or pass around.  </br>
</br>
To clarify this. A very typical example of a command is clicking a button in the user interface, for example, to open a file, add a product to a shopping cart, add a new employee to a list, and so on.
In an naive implementation we could just write the code for that in the button click event handler, but that comes with some potential issues.
You might want to separate concerns by not having the code for handling the request, the button click, in our example, at the same location as the button itself.
You might want to be able to reuse the actual code that needs to be executed, and maybe your application architecture doesn't even technically allow you to implement the code for the button click in the same place as where the button resides. 
For example, when you have separated out the button or menu in a separate project that doesn't know about the receiver of the actual request. </br>
</br>
This is where the command pattern comes in. It allows you to decouple the requester of an action from the receiver. 
This pattern is very common in mobile or rich UI development, where you would typically use the Model-View-ViewModel pattern combined with the command pattern for transferring UI interactions to your view model. 
At that level, the actual command would be implemented. </br>
</br>
A command would be bound to some UI XAML code or, if that is not possible, could manually be executed via the button click.


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368207-8d52bc33-9e27-4d17-aa21-d383cdeba557.png)


## Use case
A very obvious use case for this pattern is when you want to parameterize objects with an action to perform.
That is exactly what we did in our example. We turned an action, a button click, into a standalone object, which we can pass around. </br>
</br>
But there is more potential use cases. Supporting undo is one of them, as we have covered in our second demo. </br>
</br>
Also, consider this pattern when you want to specify, queue, and execute requests at different times.
The lifetime of the command object can be independent of that of the original request. You can transfer the command object to another process and fulfill it there. </br>
</br>
And lastly, you can also easily augment this pattern to store a list of executed changes so they can be reapplied in case of, for example, a system crash.
To implement something like that, store or log the command object and re-execute it in case an issue happens. </br>


## Consequences
The main consequence for this pattern is that it decouples the class that invokes the operation from the one that knows how to perform it.</br>
This is the single responsibility principle from the SOLID coding principle at work.</br>
</br>
Interesting to know is that commands can be manipulated and extended like any other object.
Commands can also be assembled into a composite command.
For example, a button which restarts creating a list of employees from the context of an employee might first execute a clear employee list command followed by an add employee to list command.
In general these types of commands are an instance of the composite pattern.</br>
</br>
Lastly, as far as the positive consequences go, it is easy to add new commands because you don't have to change existing classes. </br>
You simply add a new class that implements the required ICommand interface. That is the open/closed principle at work. </br>
</br>
A potential negative consequence is complexity. By transferring requests into objects, we are adding an additional layer. 

## Related patterns
The first related pattern is a structural one, the composite pattern.</br>
This can be used to implement commands composed of other commands. </br>
</br>
Memento, a behavioral pattern, can be used to store the state a command requires to undo its effect.</br>
</br>
This pattern is also related to a creational pattern, the prototype pattern.
That is because a command that must be copied before being placed on the history list, which is what you need in case you want to support undo, acts as a prototype. </br>
</br>
There is also a relation between the chain of Responsibility and the command pattern. Handlers in the chain of responsibility can be implemented as commands. </br>

* Composite - Can be used to implement commands composed of other commands.
* Memento - Can be used to store the state a command requires to undo its effect.
* Prototype - In case of supporting undo, a command that must be copied acts as a prototype.
* Chain of Responsibility - Handlers can be implemented as commands.

When we look at some of the other patterns in this course, we find others that connects senders and receivers of requests.</br>
In that regard, chain of responsibility, command, mediator, and observer are all related. </br>
</br>
Chain of responsibility passes a request along a chain of receivers that can be defined at runtime until at least one handles it. </br>
</br>
Command connects senders with receivers unidirectionally, for example, from a button that is pushed in the UI to the action that finally gets executed. </br>
</br>
The mediator pattern eliminates direct connections altogether. Communication runs through the mediator. </br>
</br>
And lastly, the observer allows receivers of requests to subscribe and unsubscribe to them at runtime. So all of these patterns connects senders and receivers, but they all do it in different ways solving different problems.
