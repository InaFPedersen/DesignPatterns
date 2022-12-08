# DesignPatterns
A project template with examples and individual documentation for each design pattern.

## Description
A project template with examples of all 23 different Design Patterns, originated from the Gang of Four library of Design Pattern. </br>
The design patterns are split into three categories, ***Behavioral***, ***Creational***, and ***Structural***. </br>
Each of the pattern has its own use cases where it can help optimalize the code.

## Tip
The examples in the codes uses either Abstract base classes, or interfaces. You can choose which you want to use depending on your own project's needs. </br>

### Abstract Class
An abstract class is a special type of class that cannot be instantiated, and is designed to be inherited by subclasses that either implement or overide its methods. 
An abstract class can have constructors.
An abstract base class allows you to create functionality that subclasses (Children) can implement or override.
A class can extend only one abstract class. 
You can take advantage of abstract classes to design components and specify some level of common functionality that must be implemented by derived classes.
An abstract class provide flexibility to have certain concrete methods and some other methods that the derived classes should implement.
If you have plans for future expansion, a future expansion is likely in the class hierarchy, a abstract class is a good choice.

### Interface
An interface is basically a contract, it doesn't have any implementation. 
Interfaces can contain only method declaration, it cannot contain method definitions.
Nor can you have any member data in a interface.
An interface may only have declarations of events, methods, and properties. 
All methods declared in the interface, must be implemented by the classes that implement the interface.
An interface only allows you to define functionality, not implement it.
A class can take advantage of multiple interfaces.
It is easy to add a new interface to the hierarchy. 
You should use an interface if you want a contract on some behavior or functionality.

## Original
The original definitions of the design patterns can be found in the book: </br>
"Design Patterns - Elements of Reusable Object-Oriented Software" written by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides in 1994.

## Tutorial
The tutorial that was followed is made by Kevin Dockx, and can be found at Pluralsight at: </br>
https://app.pluralsight.com/library/courses/c-sharp-10-design-patterns/table-of-contents

## Program
It was used Visual Studio with Console application to create this project. 

## Author
Written by Ina F. Pedersen

## Project Status
Complete

