# Memento Pattern


## Description
The memento pattern is a behavioral pattern from the Gang of Four library of design patterns. </br>
</br>
The intent of the memento is to capture and externalize an object's internal state so the object can be restored to that state later without violating encapsulation. </br>
In other words this pattern will allow us to store and restore private field and property values. </br>
</br>
Let's clarify that with a real-life example. We are going to use undo functionality of commands.</br>
This pattern is not used that much these days. </br>
You can look at command as a class that has some internal state, so private state, that needs to be stored to be able to undo the command. </br>
It is easy enough to store public state, but private state is different. </br>
</br>
An example we previously used was a command that added an employee to a manager's list of employees. </br>
That command needed to know about the employee to add, about the manager, and it also needed a repository through which interaction with the underlying data store could happen.  </br>
</br>
The manager ID and the employee, that is internal state. </br>
We used the CommandManager that was responsible for executing the command and storing necessary information about the command to undo it.</br>
We did that by storing the command object itself in memory. And while that works, this could mean we would be storing too much information. We don't necessarily need to store the full command object. </br>
</br>
We simply need to store its state or part of its state. Let's switch back to that command implementation.</br>
If that is what we want, we could make the state public and access it as such to store it somewhere. </br>
Yet, this breaks the command's encapsulation, and that is what the memento solves. It allows saving and restoring internal state without breaking encapsulation. </br>
</br>
Let's look at our command again. The internal state we want to store consists of the employee and the manager ID.</br>
We don't need to store a reference to the repository or anything. That remains the same for all AddEmployeeToManagerList commands. </br>
The first thing that we will need is a memento class that can contain this state.</br>
A good name would be AddEmployeeToManagerListMemento, containing the state we want to store via properties. </br>
</br>
On the command itself, AddEmployeeToManagerList, we would then add two methods, one to create a memento and return it, and one to restore a memento.</br>
That is a method that accepts the memento and is responsible for restoring the command's state. </br>
</br>
And now we need something that manages this. That is our CommandManager. </br>

In an implementation we ended up with in the previous module, we stored commands on a stack.We no longer have to do that. </br>
This time, we can store the mementos on the stack, and doing a command then means that we take one existing AddEmployeeToManagerList command, restore the memento on it, and call the undo action. </br>
</br>
Important here is that we want to provide two different interfaces to this memento, one wider interface that is used by the command to create a memento.</br>
This passes through state and has access to set the state. The other interface to the memento is used by the CommandManager. </br>
That one stores these mementos and passes them through to the command. But it cannot change the memento itself anymore after it has been created.</br>
It has access to the getters but not to the setters, so that is a narrow interface. We can achieve that with private setters, as we will see in the implementation. 


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368586-3cb4d9fd-e7e4-4fd9-95cc-4bbde1ca6f82.png)



## Use case
There is just one main use case for this pattern consisting of two parts. </br>
Use it when an object's state or part of it must be saved so that it can be restored to that state later, and a direct interface to obtaining the state would expose implementation details and break the object encapsulation. </br>
We had such a use case. We avoid exposing implementation details of our command through a memento, or at least we avoid changing the internal values. 


## Consequences
A major consequence of this pattern is that it preserves encapsulation boundaries. </br>
Information that only an originator should manage, but must be stored outside of the originator, is no longer exposed. </br>
</br>
It also simplifies the originator. It no longer needs to concern itself with storage management. </br>
</br>
But using mementos might be expensive if the originator must copy over large amounts of information to store in the memento or if clients create and return mementos to the originator often.</br>
So make sure that encapsulating and restoring originator state is cheap because otherwise the pattern might not be appropriate. </br>
</br>
And last, but not least, it also tends to complicate things. </br>
We noticed that with the command manager in our example.</br>
We are now just using one command on which we change state for undo functionality, but code tends to become cluttery and/or complex when you need to work with many different types of state that you need to store and restore. </br>
</br>
* It preserves encapsulation boundaries
* It simplifies the originator
* Using mementos might be expensive
* It can introduce complexity to your code base


## Related patterns
The first related pattern is the command pattern as it can use a memento to store and restore its state.</br>
</br>
Next to that mementos can also be used for iteration. In that case, a memento can be used to capture current iteration state and potentially roll it back.</br>
</br>

* Command - Can use a memento to store and restore its state
* Iterator - Memento can be used to capture the current iteration state and potentially roll it back.
