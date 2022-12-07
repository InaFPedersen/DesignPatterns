# Proxy Pattern


## Description
The proxy pattern is a structural pattern from the well-known Gang of Four design patterns. </br>
</br>
Its intent is to provide a surrogate or placeholder for another object to control access to it. </br>
That is important to know because this means that the reason for this pattern, the problem it solves, is one of access control.</br>
If you need to control access to another object for security reasons, performance reasons or other reasons, then the proxy pattern is a good one to look into.</br>
</br>
The archetypical example of a proxy, which some of you have undoubtedly encountered, is accessing a remote API from an application.</br>
Those of you who remember the Add service reference option in Visual Studio will know about this.</br>
The idea here is that your application, let's say it is an MVC app, uses a proxy to interact with the actual remote API. </br>
That proxy can be completely written from scratch. </br>
But as mentioned, there is something like the Add service reference dialog which would generate a proxy for you. </br>
</br>
The proxy is responsible for controlling the actual access to the remote API. </br>
It can contain code that deals with the underlying protocol, for example the actual HttpClient calls.</br>
It can also contain code that ensures that the most performant, reliable way to access that remote API is used and so on. </br>
In principle these proxies have the same interface as the object they are controlling access to. So for the client, it feels transparent. </br>
The client shouldn't care whether it is directly interacting with remote API or it is going via the proxy. </br>
But truth be told, sometimes you see code generators generating what they call proxies that don't adhere to this principle, </br>
which makes them more of a combination between a facade or adapter and a proxy maybe. </br>
</br>
The question is, why do we want to that? Why not directly call the API with an HttpClient instance? You can see an example of that below.</br>
HttpClient client = new();</br>
var response = await client.SendAsync("api/remotecall", ...);</br>
</br>
Well imagine that you need to execute something right before or after calling the API with HttpClient, which isn't uncommon. </br>
When you have a proxy in between, the proxy can take responsibility. That means that you don't have to change the client class anymore.</br>
Note that a proxy does not change the interface. If that is a requirement, you might want to consider the adapter pattern. </br>
Proxy can take on the responsibility of executing code before or after calling the API.


## Pattern Structure 

Client -----> Subject
                     |          |
  RealSubject <---- Proxy</br></br>
  ![image](https://user-images.githubusercontent.com/42718910/206164344-ad6aff86-e6e8-4ebc-bb6e-99b1038f4f05.png)



## Variations of the Proxy Pattern
The first variation is the remote proxy. As the one we used in the example. </br>
The idea here is that the client can communicate with the proxy, thus treating it as a local resource. </br>
The pattern hides the fact that the actual object exists in a different network space. </br>
The client does not need to know that a remote service is called. </br>
The proxy hides away these network and protocol details. More often than not, these proxies are generated from a service definition.</br>
That can be a WSDL or, more common, an OpenAPI specification.  </br>
</br>
The second variation is the virtual proxy. This one allows creating expensive objects on demand. </br>
You can look at it as a stand-in for an object that is expensive to create. </br>
Performance optimization is a big advantage of this type of proxy. </br>
</br>
The third variation is the smart proxy. The purpose is to allow adding additional logic around the subject. Typical examples are managing caching or locking access to share resources. </br>
</br>
The fourth and last variation, is the protection proxy. This is used to control access to an object. </br>
It can be useful when objects should have different access rights.</br>
Like that, checking for that no longer has to be done by the client code or in the object itself, it is the protection proxy that is responsible for this. </br>
</br>

* Remote Proxy - Client can communicate with the proxy, feels like local resource.
* Virtual Proxy - Allows creating expensive objects on demand.
* Smart Proxy - Allows adding additional logic around the subject.
* Protection Proxy - Used to control access to an object.
</br>
Sometimes the separation between these different types of proxy is not clear.</br>
It is not uncommon for code generators to, for example, generate a proxy that both hides away the fact that a remote service is accessed and takes care of permissions and access restrictions. </br>
This of course, is in violation of the single responsibility principle. A better approach would be to chain proxies, in other words, proxy-to-proxy, sticking with a single responsibility per proxy. </br>
These variations all have their own responsibilities and consequences, but as far as implementation is concerned, they all follow the same structure. </br>
</br>
What we are going to do in an example is implement two of these. We are going to implement a virtual proxy and we are going to implement a protection proxy. </br>
That one is very closely related to the smart proxy, because both allow additional housekeeping tasks when an object is accessed. </br>
As an example we will use a document object, which represents a PDF or a text file. </br>
</br>
Imagine that this is an object that is expensive to create, which is common. </br>
You might, for example, want to read out the underlying file from disk as part of the creation process, and that is quite expensive. </br>
The virtual proxy pattern can be used to ensure that creation only happens when needed.</br>
And then we will add a business rule stating that the document can only be viewed by people in the viewer role. </br>
We will use a protection proxy for this, and we will chain that with the virtual proxy. 



## Use case
The basic use case for this pattern is when you need to add some form of access control to an actual object, something that is more sophisticated than a simple object reference.</br>
The use cases come from the pattern variations, so let's have a look.</br>
For the remote proxy, the use cases providing a local representative for an object in a different network address space. </br>
Any time you need to call into a remote API or service, this can be helpful. For virtual proxies, the main use case is creating expensive objects on demand.</br>
Smart proxies are useful for caching and locking scenarios, and protection proxies are useful when objects should have different access rules. </br>
A good real-life use case was the one we just implemented. 

* Remote proxy - When you want to provide a local representative.
* Virtual proxy - When you only want to create expensive objects on demand.
* Smart proxy - When you are in need of a caching or locking scenario.
* Protection proxy - When objects should have different access rules.


## Consequences
What this pattern does is introduce a small layer or wrapper between the client and the actual object. </br>
The consequences from that, again, vary depending on the proxy type. </br>
</br>
For a remote proxy, a consequence is that the proxy hides the fact that an  object resides in a different network space. </br>
</br>
For a virtual proxy a consequence is that an object can be created on demand. </br>
</br>
And for the protection and smart proxies, a consequence is that additional housekeeping tasks can be executed whenever an object is accessed. </br>
</br>

* Remote proxy - Hides the fact that an object resides in a different network space
* Virtual proxy - The object can be created on demand.
* Smart proxy - Additional housekeeping tasks can be executed when an object is accessed.
* Protection proxy - Additional housekeeping tasks can be executed when an object is accessed.
</br>
As a general consequence, the pattern allows introducing new proxies without changing the client code, that is the open/closed principle from the solid principles at work.</br>
</br>
It also has some potential disadvantages.</br>
One is added complexity because a new set of classes are introduced.</br>
Another one is a potential performance impact because you are passing through one or more additional layers.



## Related patterns
Two structural patterns are related to the proxy, the adapter and the decorator. </br>
The adapter provides a different interface to an objective that adapts, while proxy provides the same interface. </br>
</br>
And decorators have similar implementations as proxies, but serve a different purpose.</br>
As we remember, the decorator adds responsibilities to an object. </br>
The proxy, on the other hand, controls access to an object. </br>
</br>
* Adapter - Adapter provides a different interface, proxy provides the same interface.
* Decorator - Decorator adds responsibilities to an object, while proxy controls access to an object.

