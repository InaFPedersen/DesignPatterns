# Composite Pattern


## Description
The composite pattern is a structural pattern from the well-known Gang of Four design patterns.</br>
</br>
Its intent is to compose objects into tree structures to represent part-whole hierarchies. </br>
The composite pattern lets clients treat individual objects and compositions of objects uniformly, as if they all were individual objects. </br>
</br>
What would this translate to in real life? Well, composing objects into tree-like structures is something we are all very much used to.</br>
Imagine the structure of an XML document, where each element, in turn, consist of other elements, which can again consist of elements.</br>
Another example might be an application in which a user can draw. </br>
You can represent that as something that consists of one or more lines and potentially one or more pictures, which in turn consists of lines and pictures too, and so on. </br>
</br>
The example we are going to work with is another one you can undoubtedly immediately picture, the file system. </br>
</br>
We have essentially got items in there, lets name them FileSystemItems, that are either a file or a directory. </br>
Such a directory can consist of one or more files and/or other directories, and so on. So there is our tree structure already. </br>
We have got two classes in our tree structure, a file and a directory. </br>
Now imagine we want to get the size of all the items in our tree structure. We would have to run through all these objects. </br>
We need to know the exact classes, File and Directory. We need to know the method to call on them to get their size.</br>
We need to know how deep nesting goes to be able to access those levels of files and directories and so on.  </br>
This can become very cumbersome, very fast, and that is what the composite pattern helps with.

## Pattern Structure 
Client ------------>  Component <---------
                               |                  |             |
                             Leaf              Composite

## Use case
This pattern can be useful when you want to represent part-whole hierarchies of objects, in other words, when you want to represent a tree-like object structure. </br>
</br>
It is also something worth considering when you want clients to be able to ignore the difference between composition of  objects and individual objects. </br>
As we have notices in the example, as far as the client is concerned, it doesn't matter if the operation, GetSize in our example, is called on a leaf or a composite.

## Consequences
This pattern has a few consequences. First of all, it makes the clients simple, as clients don't know whether they are dealing with a leaf or a composite component.</br>
 </br>
It is also easy to add new kinds of components. </br>
That is because newly defined subclasses automatically work with existing structures and client code, so clients don't have to be changed for new component classes.</br>
Imagine you'd have another type of FileSystemItem. You could simply implement it and work with it. The client doesn't care.</br>
It simply calls GetSize on the FileSystemItem base type, not on the subclass type. This is the open/closed principle from the SOLID coding principles at work. </br>
</br>
A disadvantage is that it can make the overall system to generic.</br>
By making it easy to add and remove items to the composite, we also make it a bit harder to restrict the components of a composite.</br>
It is no longer the compiler that checks for this, as add and remove accept the abstract base type and not the subclass. Take our FileSystemItem example.</br>
If we want to restrict the directory component to only contain files and not subdirectories, we cannot rely on the compiler for that as add and remove accept the base FileSystemItem. </br>
We have to write additional code to check for the actual type at runtime. 


## Related patterns
There is quite a few related patterns to this one. From the behavioral pattern family, there is the chain of responsibility. </br>
The component parent link is often used for that. When the leaf component gets a request, it can potentially pass it through the chain of all parent components down to the root of the object tree.</br>
</br>
It is also related to the iterator because an iterator can be used to traverse composites. </br>
</br>
Lastly the visitor pattern can localize operations and behavior that would otherwise be distributed across composite and leaf classes. You can, thus use it to execute an operation over the full composite tree. </br>
</br>
* Chain of responsibility - Leaf component can pass a request through a chain of all parent components. 
* Iterator - Can be used to traverse composites.
* Visitor - Can be used to execute an operation over the full composite tree.
