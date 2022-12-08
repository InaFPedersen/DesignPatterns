# Adapter Pattern


## Description
The adapter pattern is a commonly used ***Structural Pattern*** from the well-known Gang of Four design patterns. </br>
</br>
Its intent is to convert the interface of a class into another interface clients expect.
So, the adapter pattern lets classes work together that couldn't otherwise because of incompatible interfaces. </br>
</br>
There are two variations of this pattern, the first one being the object adapter pattern.
Imagine that you need to integrate with an external system that exposes a city. 
You could for example, be creating an application that needs to talk to an API that exposes these cities. 
Or you could just be talking to another application layer that works on a different model than the one you eventually need. 
For our use case, let's say we got a city from ExternalSystem class with the name, a nickname, and the amount of inhabitants as an integer.</br> 
</br>
The second is class adapter pattern. The object adapter pattern we looked into works via object composition. 
The class adapter pattern is a variation which relies on multiple inheritance to adapt one interface to another.
There is only one little problem with this. C# is a language that prefers composition over inheritance, and it does not support multiple in inheritance. 
We could have done this in Java, but not in C#. However, we can implement it with a slight variation.


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206155847-e0c4b916-a9fc-45f8-a2f2-3c7ce1c77504.png)


## Use case
This pattern is useful when you want to use an existing class, but the interface does not match the one you need, adapting a city class from one system to another one for example.
You can also use it when you want to create a reusable class, the adapter, that works with classes that don't have compatible interfaces.</br>
 </br>
Lastly, we use it when you need to use several existing subclasses, but you don't want to create additional subclasses for each of them, but still need to adapt their interface.
In that case, you can use the object adapter pattern to adapt the interface of its parent class.


## Consequences
As every pattern, this one has a few consequences. It will be focused on the object adapter pattern here, as a true class adapter with multiple inheritance isn't possible in C#.</br>
</br>
One of the consequences is that it lets a single adapter work with many adaptees, the adaptee itself and all of its subclasses as you can cast to those. 
The adapter can also add functionality to all adaptees at once as calls to the external system, the adaptee, pass through the adapter. 
The single reponsibility principle from the SOLID coding principles is adhered to in the way that you are separating the interface, the adapter code, out from the rest of the code.
The adapter thus has a single responsibility. </br>
</br>
As we are working on interfaces, new types of adapters can easily be introduced without breaking client code. That is the open/closed principle at work. </br>
</br>
The object adapter makes it harder to override adaptee behavior. If you want to do that, you will have to subclass the adaptee and make the adapter refer to the subclass rather than the adaptee itself. </br>
</br>
Another potential disadvantage, as is often the case, is that additional complexity is introduces because you introduced  additional interfaces and classes. 


## Related patterns
As usual, a few patterns are related to the adapter pattern. </br>
From the family of structural patterns, there is a relation to the bridge. 
Both have a similar structure, but a different intent. 
A bridge is meant to separate an interface from its implementation so they can be varied easily and independently.
An adapter, on the other hand, is meant to change the interface of an existing object. </br>
</br>
It is also related to the decorator pattern. The decorator changes an object without changing its interface. 
It is just more transparent than the adapter, which changes the interface of an existing object. </br>
</br>
It is also related to the facade pattern. 
With the facade pattern, you are defining a new interface for an entire subsystem of objects. 
With adapter, you are making an existing interface usable by wrapping one object. </br>
</br>
Lastly, there is a relation to the proxy pattern.
This defines a surrogate for another object. It does not change its interface, while the adapter does provide a different interface.</br>

* Bridge - Bridge separates interface from implementation, adapter changes the interface of an existing object.
* Decorator - Decorator changes an object without changing its interface, adapter changes the interface of an existing object.
* Facade - With facade you define a new interface for an entire subsystem, with adapter you are making an existing interface useable via wrapping
* Proxy - Defines a surrogate for another object, but does not change its interface.
