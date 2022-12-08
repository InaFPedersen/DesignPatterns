# Interpreter Pattern


## Description
The interpreter pattern is a ***Behavioral Pattern*** from the Gang of Four library of design patterns. </br>
</br>
Its intent is to, given a language, define a representation for its grammar along with an interpreter that uses the representation to interpret sentence in the language.
In other words it defines a grammatical representation for a language and an interpreter to interpret the grammar. 
And that is also why it is not something you will often create yourself. 
You don't define a language every day, yet it is something we use a lot in our day-to-day programming life. </br>
</br>
When you use LINQ queries, behind the scenes an interpreter-like pattern can handle translation between LINQ and, for example, SQL, or the interpreter for regular expressions or even the way the C# compiler interprets the code we write.
All of these could use a variation of this interpreter pattern. There are other patterns and possibilities.
We will cover that once we get to the use cases, but know that it would be possible to use the interpreter pattern for all these examples.</br>
</br>
Imagine the use case in which we want to translate Arabic numerals to Roman numerals.
Say that we have the number 181. How would that go around? </br>
If we stick to the hundreds as a maximum, there is 999 possible outcomes, or 1000 if we include 0.
Imagine the switch statement we'd have to write. That is completely unmanageable. Enter the interpreter pattern. </br>
</br>
We can look at 181 as a sentence in a grammar we are going to define.
That grammar exists of a set of expressions. The first expression would be the 100 expression, the second one the then expression, the third one the one expression.</br>
Each expression is then responsible for translating the word, which is one number in our case, that is passed in. In other words, it is responsible for interpreting the word. 
So we define a grammar through a set of expressions. You can call that a syntax tree, which is a word. That means we don't need that huge switch statement anymore. </br>


## Pattern Structure 
![image](https://user-images.githubusercontent.com/42718910/206368280-719b0c46-6fec-438a-bae5-21328c180a02.png)



## Terminal VS NonTerminal Expression
When we looked into the pattern structure, we learned that one possible implementation of an abstact expression is a terminal expression.</br> 
There is another possible implementation, a non-terminal expression. It is not applicable to our example, but it is nevertheless interesting to know about. </br>
</br>
All language consist of symbols. A symbol is the smallest meaningful part or unit of language, for example, a word, a number, an operator, things like that. 
These symbols are called terminals implemented through a terminal expression.
When you think about it, you notice that all these terminals make up statements. </br>
</br>
For example, 5 + 10 = 15. That is a statement made up of a set of terminals. 
In a programming language, you could have a while or a conditional statement made up of terminals.
That is the statements that are made up of terminals and that are allowed by a language, those are called nonterminals. 
Nonterminals can consist of terminals and/or additional nonterminals.
So that is what these two mean and how they differ. </br>
</br>
Terminal expression:</br>
* A symbol (the smallest meaningful part or unit of a language) is called a Terminal.
* Implemented through a Terminal expression.
</br>

NonTerminal expression:</br>
* Statements that are made up of terminals and are allowed by a language are called NonTerminals.
* Can consist of Terminal(s) and/or NonTerminal(s).

</br>
So that is what these two mean and how they differ. </br>
A non-terminal expression is symbolized by a non-terminal expression in the pattern structure.
It maintains a list of abstract expressions that make up the non-terminal expression.
Interpreting a non-terminal expression is typically done via recursion on all the variables that represented. 


## Use case
The use case for this pattern is when there is a language you can interpret, and you can represent statements in the language as an abstract syntax tree.
But that use case would apply to many types of languages, even though this pattern isn't necessarily a good fit for all of them. </br>
</br>
Keep in mind that this is a good fit when the grammar is simple. When it becomes complex, the class hierarchy of the grammar becomes large and unmanageable. </br>

Also, it is not the most efficient interpreter. The most efficient ones are usually implemented by translating parsed trees to another form first.
Regular expressions, for example, are often transformed into state machines first.
Yet even then, the translator itself can be implemented by the interpreter pattern. So, it is still applicable. 


## Consequences
The first consequence is an advantage it is easy to change and extend the grammar.</br>
Grammar rules are represented by classes and these can be extended via inheritance. </br>
</br>
Also implementing the grammar is easy too, as all classes that implement the abstract expression have similar implementations. </br>

The disadvantage is that complex grammars are hard to maintain. There is at least one class for every rule in the grammar.</br>
So, if you got a large set of rules, you have got a large set of classes to manage and maintain. 


## Related patterns
The interpreter is related to two other patterns. </br>
The first one is the composite as the abstract syntax tree is, in fact, an instance of the composite pattern. </br>
</br>
The second related pattern is the iterator because, in regards to traversing the structure, an iterator could be used. </br>

* Composite - The abstract syntax tree is an instance of the composite pattern.
* Iterator - You can use an iterator to traverse the tree.
