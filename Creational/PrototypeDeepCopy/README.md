# Prototype Deep Copy

## Description
The Prototype Deep Copy is a part of the prototype topic. </br>
See Prototype readme for full documentation.

## Shallow Copy VS Deep Copy
A shallow copy is a copy of primitive type values. 
Strings, integers, and so on will be copied. These are independent of the original object. 
But complex types that might be properties of the object you are cloning will be shared across the different clones. 
Because of that, changing a value from that complex object, for example the manager's name, results in changes on both the original object and the clone. </br>
</br>
A deep copy, on the other hand, also results in copies of the complex types.
In that case, we can modify the complex object properties of the original object without it affecting those of the cloned object and vice versa.
