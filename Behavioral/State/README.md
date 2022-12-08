# State Pattern


## Description
The state pattern is a ***Behavioral Pattern*** from the Gang of Four library of design patterns. </br>
</br>
Its intent is to allow an object to alter its behavior when its internal state changes. The object will appear to change its class. </br>
</br>
Let's clarify this with an example, withdrawing or depositing money from or on a bank account. </br>
This can result in the bank account changing state from regular to overdrawn or vice versa. 
If your bank account is defined by a class, BankAccount, you could add a enumeration property, BankAccountState to it. </br>
</br>
When you withdraw money, the state can potentially go from regular to overdraw. 
And when you deposit money it can potentially go from overdrawn back to regular.
Depending on the state of the account, other rules might apply. 
You might not be able to withdraw money when your account is in overdrawn state. 
You can solve that with a conditional statement in the Withdraw method. </br>
</br>
Now imagine an additional state, gold, which you get when your account has a lot of money in it. 
It allows you to withdraw more money at once.
That means that the logic for transitioning becomes a bit more complex, and the conditional statement when withdrawing becomes a bit more complex as well, but it is still manageable. </br>
</br>
Yet it is not hard to imagine that this can become very complex, very fast. 
Adding a few additional states or business rules, like only allowing you to take out a credit card when your account is in a certain state.
Changing state of the linked account when you overdraw a credit card, or even an interest rate that changes depending on the bank account state. 
The way the account behaves depends on the state, and the state can change at runtime. </br>
</br>
Taking care of all these business rules and transitions and states in the way just shown will lead to large, difficult-to-manage conditional statements and state transitions.
That is what the state pattern can help with.</br>
</br>
We will start with just the two states from the initial example, regular and overdrawn. We still have a BankAccount class with methods on it to withdraw and deposit money. </br>
</br>
What we could do is introduce an abstract class that represents the state of our bank account.
It declares an interface common to all classes that represent different operational states of the bank account, which includes methods to handle requests that are coming from the bank account, like deposit and withdraw. 
We name that one BankAccountState. Thhe BankAccount class has a BankAccountState property of this type. </br>
</br>
For each state, we have concrete implementations, like regular state ad overdrawn state. In these implementations the logic resides to transition from one state to another. 
So, in the regular state object's Withdraw method, we have code that will change the state from regular state to overdrawn state when the balance goes below zero and vice versa. </br>
</br>
The more states you have, the more you will notice this logic will be less conditional and complex then when working with enumeration. 
For each state, we have concrete implementations, like regular state and overdrawn state. 
In these implementations the logic resides to transfer from one state to another. 
So in the regular state object's Withdraw method, we have code that will change the state on the bank account from regular to overdrawn state when the balance goes below zero and vice versa.</br> 
</br>
The more states you have, the more you will notice this logic will be less conditional and complex than when working with enumeration because typically you can't go from each state to all other states. 
The logic in the withdraw and deposit methods becomes easier as well. 
For example there is no conditional statement anymore in the withdraw method on our overdrawn state to check whether we can withdraw money or not.
We don't have to check for the state we are in as the state is represented by the object itself. </br>
</br>
So when depositing money or withdrawing money via the bank account object, it calls into the underlying Deposit and Withdraw methods on the BankAccount state object. </br>
And as we just detailed, doing that takes care of state-specific logic and state transitions. 
By doing so, we vastly diminish complexity. Each state object handles just its own possible transitions and logic. 
The more different states there are, the more obvious the advantages become. 


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368823-7a5be10e-4485-43e8-a36b-7a09780cc089.png)


## Use case
There is two good use cases for this pattern. </br>
The first case in which you should consider this pattern is when an object's behavior depends on its state, and it must change its behavior at runtime depending on that state.
That is the use case we just implemented with the bank account example. </br>
</br>
Another good use case is when your objects are dealing with large conditional switch or if statements that depends on the object state, for example by storing the state in an enumeration field on the object, also not unlike the use case from the demo.
This often results in several of your object operations to contain the same conditional structure. That is what we would have ended up with in our naive implementation. </br>
</br>
By using the state pattern, each branch of the conditional is put in a separate class, which lets you treat the object's state as an object in its own right. It can thus vary independently from other objects. 


## Consequences
This pattern localizes state-specific behavior and partitions behavior for different states.
We saw that as all the behavior associated with a particular state was put in an object of its own.
This works towards the single responsibility principle from the solid coding principles. </br>
</br>
Another positive consequence is that because state-specific code lives in a state subclass, new states and transitions can easily be added by defining new subclasses.
We saw that when we extended our example with the new state in the second demo. That is the open/closed principle from the solid coding principles at work. </br>
</br>
But this can have a possible  negative consequence as well. </br>
As the pattern distributes behavior across different state subclasses, the number of classes increased, which adds additional complexity. 
But seeing long conditional statements are not desirable, this becomes more of a positive consequences than a negative consequence once the amount of state subclasses is large.


## Related patterns
There is a few related patterns.</br>
The first one is the flyweight.
When you implement the state pattern without instance variables in the state objects, you are essentially making these state objects shareable, which makes them flyweights.</br>
</br>
There is also a relation to the singleton pattern as state objects often are singletons.</br>
 </br>
Strategy, bridge, and states are all related and look similar because they are based on composition, but they solve different problems. </br>
</br>
* Flyweight - Without instance variables in the state objects, they become flyweights.
* Singleton - State objects are often singleton.
* Strategy - Also based on composition, but solves a different problem.
* Bridge - Also based on composition, but solves a different problem.
