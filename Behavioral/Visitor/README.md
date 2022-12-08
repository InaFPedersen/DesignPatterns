# Visitor Pattern


## Description
The Visitor Pattern is a ***Behavioral Pattern*** from the Gang of Four library of design patterns. </br>
</br>
Its intent is to represent an operation to be performed on the elements of an object structure. </br>
Visitor lets you define new operation without changing the classes of the elements on which it operates. </br>
That definition requires some further explanation. </br>
</br>
Imagine the following use case. We are building part of an order management system.</br>
You have got a large set of objects, but they are not all the same.</br>
You have got an InternalCustomer class, a GovernmentCustomer class, and a PrivateCustomer class and so on, all deriving from Customer, but all with their own custom behavior and properties.</br>
At a certain moment, a requirement comes in to add new behavior to all these objects. You need to calculate a discount depending on the amount of money the customer previously spent on orders. </br>
To add this behavior, you can implement it in all these classes, or depending on what needs to be known about the customer, you can implement it in a base class.</br>
</br>
But there is other types as well. Let's add an Employee class to the mix. </br>
Employees of companies also get discounts, but the calculations for these are completely different. </br>
They are based on the amount of years someone is employed.</br>
Employee and the customer don't have the same base class, so we can't use that approach anymore.</br>
</br>
We can however still add the method to calculate the discount on the concrete Employee class.</br>
Yet, what if after some time a new requirement comes in? </br>
Like you now need to calculate some shipping costs for each customer and for each employee. </br>
And after that, you need to add JSON export to all objects, and so on.</br>
This becomes cumbersome. You always need to change these classes, which is risky.</br>
Also, we need to start wondering whether it makes sense to have all that added behavior in all of these classes.</br>
Maybe it doesn't belong there if we keep the single responsibility principle in mind. </br>
</br>
Enter the visitor pattern. </br>
This allows adding behavior to classes by adding the behavior to another class, the visitor, which will visit the original classes and execute that behavior. </br>
To avoid overloading the screen with a huge diagram, let's just stick to a customer class and an employee class, unrelated to each other, and with their own properties and operations.</br>
But there can of course be many more classes. They have a discount field, which we will calculate using our visitor. </br>
</br>
We have both of them implement an interface, the IElement interface, which defines one method, accept. </br>
This method accepts a visitor, or rather an IVisitor, as we want to work on an interface here.</br>
</br>
On that interface, we define a method to visit the customer, which accepts our customer, and another method to visit the employee, which accepts our employee.</br>
In other words, one method per class so the discount can be calculated correctly, as the algorithm may be different for each class. </br>
</br>
A concrete class, DiscountVisitor, implements the IVisitor interface and contains the actual logic to calculate the discounts. </br>
</br>
The last thing we need is some sort of object structure that accepts our DiscountVisitor and is responsible for running through the customers and employees and passing the visitor through to the Accept methods on them. </br>
This can be a list or a composite, depending on your use case. For our case we will name it Container. </br>



## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206369119-a4c52d46-afae-4d0d-9b2f-c00e049177d9.png)



## Use case
A good use case for this pattern is when an object's structure contains many classes with objects with differing interfaces and you want to perform operations on them that depend on their concrete classes. In our example, these concrete classes were customers and employee. </br>
</br>
Another good use case is when you are in a situation where the classes defined in your object structure don't have to change often, but you do often want to define new operations over the structure, a discount visitor, a JSON export visitor, and so on. </br>
Using this pattern avoids having to change the classes, employee and customer, that define your object structure. </br>
</br>
Lastly, use it when you have got potentially many operations that need to be performed on objects in your object structure, but not necessarily on all of them.
The visitor pattern avoids that you have to pollute all your objects with these operations, even when they don't apply to them. </br>
Of course, a bit of reflection can help here as well, but that is typically a costly operation you want to avoid. </br>


## Consequences
The first consequence is that the visitor pattern makes adding new operations easy. </br>
You can define a new operation simply by creating a new visitor, and there is no need to change the classes the visitor visits. </br>
This is the open/closed principle at work.</br>
</br>
A definite advantage is that you can use the visitor to accumulate into on the objects it visits. </br>
We did that in our example by accumulating the total discount. </br>
</br>
What is also an advantage is that the visitor gathers related operations together and potentially separates unrelated ones.</br>
For example, all operations related to calculating discounts are grouped together in the same visitor class, all operations for calculating shipping costs, as well, and so on.</br>
Otherwise, they might be separated out into the classes that are visited, where they would represent a group of unrelated operations. </br>
This advantage works towards the single responsibility principle. </br>
</br>
There is also a few disadvantages. Adding a new concrete element can be hard, as you will potentially have to change all visitor interfaces and concrete implementations.</br>
</br>
And lastly, the visitor pattern might require you to break encapsulation. </br>
The visitor needs access to all properties or operations on each concrete element to do its job, which might require you to make more operations accessible on these classes than would otherwise be required.


## Related patterns
The visitor pattern is related to the composite pattern. We know that, as the object structure we used in our example was a composite. </br>
So the visitor pattern can be used to apply an operation over an object structure defined by the composite pattern. </br>
</br>
It can also be used together with an iterator.</br>
You could use an iterator to traverse a potentially complex  data structure and then use the visitor to apply some logic to the items in that structure. </br>
</br>

* Composite - A visitor can be used to apply an operation over an object structure defined by the composite pattern
* Iterator - You can use an iterator to traverse a potentially complex data structure, and apply logic to the items in that structure with a visitor.
