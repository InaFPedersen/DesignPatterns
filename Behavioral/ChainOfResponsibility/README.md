# Chain of Responsibility Pattern


## Description
The chain of responsibility pattern is a  behavioral pattern from the Gang of Four library of design patterns.</br>
</br>
Its intent is to avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. </br>
It does that by chaining the receiving objects and passing the request along the chain until an object handles it. </br>
</br>
To show this we will show an example, an application, which validates a document.</br>
The first thing that needs to happen is ensure that the document's title is filled out.</br>
Up next, we have got a requirement that the document's last modified date must be less than 30 days old. </br>
If those check out, the document must be read and approved by the litigation department, after which it can be sent to the manager and approved there.</br>
Only after the manager has approved the document, it is considered valid and can be sent to the customer. </br>
As you gather from our code example, that is a lot of conditional statements that need to evaluate to true before the document is considered approved and ready to send to a customer. </br>
The method that checks the document becomes bloated and hard to manage, and there is no easy way to reuse these checks in other parts of our code. Enter the chain of responsibility pattern.</br>
</br>
The idea is that we are going to put all these validations and approvals in objects of their own, handlers. </br>
So we end up with an interface, say IHandler, which states that there should be a method to handle the incoming request.</br>
We could scope this to a document class, as that is what we are using in the example, but using generics make this more reusable, so that is what he suggest.</br>
As each handler can pass the request onto the next one, we also need to provide a way to set the next handler. That is the potential successor. </br>
</br>
For each of our validations, we have an implementation of this interface, a handler.</br>
So, we got a DocumentTitleHandler, a DocumentLastModifiedHandler, a documentApprovedByLitigationHandler, and the documentApprovedByManager.</br>
For readability purposes, it is only used two in the illustration.</br>
What these handlers do is get the document passed into their Handle method and can then execute their part of the document validation.</br>
If the validation don't check out, we don't continue, but if it does, we can continue to the successor. Like that the document flows through the chain. </br>
</br>
And of course, we have a client that initiates the request. The client chains the handlers and provides it with a document to validate. </br>
</br>
Before we continue with mapping this to the pattern structure, there is something to point out. </br>
The example used in this , is a real-life example that is in line with today's interpretation of the chain of responsibility pattern.</br>
However, if you look up the original implementation from the Gang of Four book, you would notice it is a bit more strict.</br>
In that interpretation, a request moves up the chain of handlers, and each handler simply checks whether it can handle that request or not. </br>
If it can't, nothing happens to the request except passing it on.</br>
And if it can handle it, it is handled and not passed on anymore. Both are valid implementations. </br>
</br>
As a side note, if you have worked with ASP.NET Core, this should feel quite familiar.</br>
In how ASP.NET Core request pipeline works. </br>
Essentially, you are chaining pieces of middleware that can handle and/or alter a request and potentially pass it on to another piece of middleware.</br>
That is a prime example of chain of responsibility pattern at work.


## Pattern Structure 

                                              -------
                                              |     |
 Client  ------------------------------->     Handler
                                              |     |
                               ConcreteHandler1    ConcreteHandler2


## Use case
There is three common use cases for this pattern. </br>
Use it when more than one object may handle the request and the handler isn't known beforehand. </br>
In other words, it should be ascertained automatically. </br>
This is made possible because, with the chain of responsibility pattern you create a chain of linked handlers, and each handler gets a chance to process the request, but it doesn't have to.</br>
It can also simply pass it on. 
</br>
Another use case is when you want to issue a request to one of several objects, which are the handlers, without specifying the receiver explicitly.</br>
You don't know beforehand whether a handler is effectively going to receive the request. </br>
</br>
And lastly, when the set of objects that can handle a request should be specified dynamically. </br>
Translated to our handler example, all handlers and their order in the chain are specified at runtime.</br>


## Consequences
There is three main consequences to this pattern.</br>
One is reduced coupling. Our client does not know which handler will handle the request.</br>
The object that invokes the operation is decoupled from the one that handles the operation. </br>
Like that, we can work towards a single responsibility per class.</br>
</br>
The second consequence is added flexibility in regards to assigning responsibilities to objects.</br>
We can control the order in which handlers are executed at runtime, and we can control which handlers are in the chain. </br>
</br>
The third is a disadvantage. Receipt isn't guaranteed. </br>
A request doesn't have an explicit receiver, so there is no guarantee that each handler will receive it or not or that it will be handled at all. 


## Related patterns
The chain of responsibility pattern is often applied in conjunction with the composite pattern. </br>
Here, the parent of a leaf component can act as the successor.</br>
In other words, when a leaf component gets a request, it can pass it on to the parent, which can pass it on to its parent, and so on. </br>
That is a chain of responsibility. </br>
</br>
There is also a relation between the responsibility and the command pattern. The handlers we implemented can be implemented as commands. </br>
</br>
* Composite - The parent of a leaf can act as the successor.
* Command - Chain of responsibility handlers can be implemented as commands.
</br>
</br>
When we look at some of the other patterns in this course, we find others that connect senders and receivers of requests.</br>
In that regard, chain of responsibility, command, mediator, and observer are all related. 
</br>
Chain of responsibility passes the request along a chain of receivers that can be defined at runtime, until at least one handles it, or none at all. 
</br>
Command connects senders which receivers unidirectionally, for example from a button that is pushed in a UI, to the action that finally gets executed. 
</br>
The mediator pattern, as we have just learned, eliminates direct connections altogether. Communication runs through that mediator. 
</br>
And lastly, the observer allows receivers of requests to subscribe and unsubscribe them at run time. 
