# Iterator Pattern


## Description
The iterator pattern is a behavioral pattern from the Gang of Four library of design patterns.</br>
Iterators are everywhere. They are one of the most common patterns used by frameworks to traverse their collection. </br>
</br>
Yet, even though it is very common, It is not often seen used that much in custom code anymore. </br>
By which, it mean that the frameworks we use tend to already have the iterators in place we commonly need. </br>
</br>
Its intent is to provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation. </br>
</br>
Sounds a little complicated maybe, but simply change aggregate object to innumerable or array or collection, and the intent all of a sudden becomes a lot more tangible. </br>
Whenever we use a for each statement over an innumerable, say a list of strings, it is an iterator that is used to provide the correct previous or next item.</br>
 </br>
And let's continue with that list example. A list is an aggregate object, which aggregate a set of variables, potentially other objects. </br>
Lists, but also other aggregate objects like collections, Dictionary, Stack, Queue, and so on keep their items in an internal structure. </br>
You don't want to expose this internal structure to avoid it being tampered with in unintended ways. </br>
</br>
Also you might not always want to traverse the aggregate object in the same way.</br>
You might want to allow traversing it alphabetically or in reverse order, and you don't want to bloat the aggregate object interface with all these different ways of traversing it. </br>
And that is what the iterator solves. It takes the responsibility for traversing out of the aggregate list object and puts it in an iterator object. </br>
</br>
Now as mentioned, most common iterators on the collections we use already exist.</br>
So an example, we are going to create a custom collection, a collection of people.</br>
On it, we are going to create an iterator a collection of people. </br>
On it, we are going to create an iterator that iterates over these people, but it is going to do that in alphabetical order by the person's name. </br>
</br>
We will name our custom collection, PeopleCollection.</br>
On it common methods like you'd expect in a collection exists like Add, Remove, maybe Count, and so on.</br>
Next to that, it should also have a CreateIterator method. </br>
That will return our iterator and will define the need for such a method on an interface, IPeopleCollection.</br>
</br>
The IPeopleCollection interface will define an interface for creating an iterator object. </br>
</br>
We will name that IPeopleIterator. That too is an interface. </br>
Like this, we avoid having to use concrete implementations on our PeopleCollection, which means we can easily provide multiple different iterators without having to change the class.</br>
The PeopleIterator interface contains four methods, First, Next, IsDone, and CurrentItem. These are the methods required for iterating over a collection. </br>
</br>
The last part of the story is the concrete implementation of the iterator. </br>
The PeopleIterator, it implements the IPeopleIterator interface, and it will contain the actual logic for iterating over our PeopleCollection, sorted alphabetically by name. 


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368394-bcfaeba9-c00e-47c6-88c3-97177721cd46.png)



## Use case
Use this pattern to access an aggregate object's contents without exposing its internal representation.</br>
As mentioned before, this avoids unintended access to and manipulation of that internal representation. </br>
Next to that, it can also be used to hide away complexity when you are working with a complicated data structure. </br>
Think about complicated tree structures, for example. </br>
</br>
Another good use case is when you want to support multiple ways of traversal for the same aggregate object.</br>
</br>
 And yet another one is avoiding code duplication. </br>
 If the way you want to traverse a structure is complicated, chances are it is not trivial to write.</br>
 If in such a case you want to traverse your structure in multiple places in your app, it is a good idea to put that code in an iterator to avoid code duplication. 


## Consequences
An important consequence is that iterators simplify the interface of your aggregate structure. </br>
The traversal code is separated out in separate classes. This follows the single responsibility principle. </br>
</br>
You can implement new types of aggregate objects an iterators without them interfering with each other. </br>
Seeing we are working on interfaces and not implementations, the open/closed principle applies as well. </br>
</br>
Iterators can exist next to each other at the same time on the same collection. </br>
In other words, you can be traversing a collection with an alphabetical iterator at the same time as you are traversing it in the order items were added.</br>
As the iterators store their own position, they won't interfere with each other. </br>
</br>
A disadvantage is that using this pattern can be a bit of overkill when you only use simple traversals and collections. It is mostly useful for more complex situations.</br>


## Related patterns
The iterator is related to the composite pattern. This is a recursive structure, and iterators are often used to traverse those. </br>
</br>
It can also be used in conjunction with a memento. In that case, the memento can be used to store the state of the iterator and potentially roll it back.  </br>
</br>
Lastly, the visitor pattern can be used in combination with the iterator. </br>
You could use an iterator to traverse a potentially complex data structure and use the visitor to apply some logic to the items in that structure.</br>
</br>

* Composite - Iterators are often used to traverse its recursive structure.
* Memento - The memento can be used to store the state of the iterator and, potentially, roll it back.
* Visitor - You can use an iterator to traverse a potentially complex data structure, and apply logic to the items in that structure with a visitor. 
