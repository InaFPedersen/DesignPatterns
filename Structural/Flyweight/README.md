# Flyweight Pattern


## Description
The flyweight pattern is a structural pattern from the Gang of Four patterns. </br>
</br>
The intent of the pattern is to use sharing to support large number of fine-grained objects efficiently. </br>
It does that by sharing parts of the state between these objects instead of keeping all that state in all of the objects.</br>
To explain this, by mapping it to a real-life situation. It is not that hard to come up with a good typical real-life example.</br>
We are going to use this pattern to share the characters of the document. </br>
That is a variation of the example that was originally used in the book from 1994. </br>
Afterwards, we will see why a lot of potential real-life situations that could call for this pattern actually don't.</br>
But in our case, it does look like a good fit. </br>
If each character in a document would have to be a new object instance, the amount of these that are required would explode. </br>
</br>
We start with an ICharacter interface. All characters must implement this. This can also be an abstract base class.</br>
In our example, there is one method on it defined, Draw, which gets the fontFamily and Size passed through that the character needs to draw itself in. </br>
</br>
Implementations of these are CharacterA and CharacterB and so on. </br>
We can consider these shared objects that can be used in multiple contexts simultaneously.</br>
Each of these acts as an independent object in each context. In that regard, it cannot be distinguished from an instance that isn't shared. </br>
And shared it because even though our document might have lots of A, B, and C characters, we will only hold onto one instance of each related class. </br>
</br>
The key concept to allow for this is intrinsic versus extrinsic state. </br>
The intrinsic state can be described as state data that is independent of the context.</br>
In other words, it is data that does not change if the object is used in different contexts. </br>
The character itself, the glyph if you want, A, B, C, remains as it is. That is intrinsic state.</br>
The extrinsic state then is data does vary with context. </br>
Different class instances might have different extrinsic state data, which cannot be shared.</br>
In our case, the fontFamily and fontSize would be extrinsic state. </br>
</br>
We could expose that by adding a Draw method to the characters that accepts this fontFamily and fontSize. </br>
Set it and then draw the character. But with that, we are not there yet. </br>
We would need something that will manage these flyweights for us, a component that would parse the document and, for each letter in the document, check whether the underlying characters has already been instantiated. </br>
And if it has, ensure that it can be reused. That is our character factory. </br>
</br>
Now there is a lot more examples you can think about that you could put in a pattern like this.</br>
Think about products with a fixed category and non-fixed weight and names, and ordering system with a few fixed intrinsic values per order, a library system, and so on. </br>
Yet, often it does not make sense to do that.</br>
</br>
There is a few things to consider before implementing this pattern. </br>
1. Does the app use a large number of objects? In our case, documents definitely use a lot of character objects.
2. Are storage costs, that is memory use, high because of the large amount of objects? In case of a document, yes.
3. Can most of the objects state be made extrinsic? Definitely in our case. The actual character glyphs are intrinsic, but things like color, font, size, etc., are extrinsic.
4. If you remove extrinsic state, can a large group of objects be replaced by relatively few shared objects? Yes, that is true too. In that case, we just end up with all the different characters in the alphabet. 
5. Does the application require object identity? If it doesn't it is a good candidate. True for our example. The application does not need to know an ID or unique way to identify each character.
</br>
The general rule is only use this pattern when all five are true.


## Pattern Structure 
FlyweightFactory ---------------> Flyweight
      |                          |         |
      |         ConcreteFlyweight1        ConcreteFlyweight2
      |                                    |           |           
      |                                    |           |
Client -------------------------------------------------</br></br>
![image](https://user-images.githubusercontent.com/42718910/206163977-e31239a5-7b9d-49d4-82fb-f513768995c2.png)

## Working with Unshared Concrete Flyweight
We are looking at the pattern structure we ended up with. </br>
A confession, when we looked into the pattern structure, somethings where skipped to make the pattern easier to grasp.</br>
</br>
The thing skipped was the UnsharedConcreteFlyweight, which also implements flyweight.</br>
This type of flyweight implementation does not need to be shared. </br>
The flyweight interface enables sharing, but it does not enforce it. </br>
The UnsharedConcreteFlyweight is such an implementation. </br>
It enables acting on extrinsic state, while having unshareable intrinsic state. </br>
</br>

FlyweightFactory ---------------> Flyweight
      |                                              |      |      |
      |              ConcreteFlyweight1    |      ConcreteFlyweight2
      |                      |                              |                       |
      |                      |  UnsharedConcreteFlyweight  |           
      |                      |                                                       |
Client ---------------------------------------------------------</br></br>
![image](https://user-images.githubusercontent.com/42718910/206164956-6711c118-bb8d-4a05-96eb-48e067ed55cc.png)


## Use case
The use cases for this pattern match the reasoning you would use in the first place to decide on whether the case is a good match for this pattern. </br>
We already looked into that when we described the pattern. </br>
</br>
	1. the application uses a large number of objects. 
	2. storage costs are high because the large amount of objects. 
	3. most of the object state can be made extrinsic.
	4. if you remove extrinsic state, a large group of objects can be replaced by relatively few shared objects.
	5. the application does not require object identity.
</br>
If these five rules check out, then you have got a good use case.</br>
A library system might be a good use case, a product categorization system might be a good use case, but they are not good use cases by default.</br>
Always check your specific requirements against these five rules. 


## Consequences
A positive consequence is that you may save lots of memory when you use this pattern for an applicable use case. </br>

That being said, it might be that you end up with some more processing costs because of the need to inject or compute extrinsic state if that state was stored as intrinsic state previously.</br>
That is a disadvantage, but that is almost always offset by the reduced storage costs, i.e. the reduced memory use. </br>
</br>
Another disadvantage is that this is quite a complex pattern, which means that your codebase, as a whole, will become a lot more complicated.

## Related patterns
The first related pattern is the state pattern.</br>
When you implement it without instance variables in the state objects, you are essentially making these state objects sharable, which makes them flyweights. </br>
</br>
The second related pattern is a strategy pattern. A strategy can also be implemented as a flyweight. </br>
</br>
* State - State without instance variables makes these objects flyweights.
* Strategy - Strategy can be implemented as a flyweight.
