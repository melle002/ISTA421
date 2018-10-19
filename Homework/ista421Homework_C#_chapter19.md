# ISTA-421
## Chapter 19, C# Step by Step
#### Readings
Read chapter 19, pages 423 { 438 in the C# Step by Step book.
#### Discussion Questions
##### 1. What is an enumerable collection?
A collection that implements the System.Collections.IEnumerable interface

##### 2. What properties and methods does the IEnumerable interface contain?
Contains a single method named GetEnumerator()

##### 3. What properties and methods does the IEnumerator interface contain?
object Current { get; }
bool MoveNext();
void Reset();

##### 4. What values does the MoveNext() method return? What does it do?
true or false, moves the pointer dowm to the next (first) item in the list

##### 5. What values does the Reset() method return? What does it do?
returns nothing, returns the pointer back to before the first item in the list.

##### 6. Are IEnumerable and IEnumerator type safe? Why or why not? If not, how do you implement type safety?
The Current property of the IEnumerator interface exhibits non-type-safe behavior in that it returns an object rather than a specific type. However, the Microsoft .NET Framework class library also provides the generic IEnumerator<T> interface, which has a Current property that returns a T instead. Likewise, there is also an IEnumerable<T> interface containing a GetEnumerator method that returns an Enumerator<T> object. Both of these interfaces are defined in the System.Collections.Generic namespace, and you should make use of these generic interfaces rather than the nongeneric versions when you define enumerable collections

##### 7. Why don't recursive methods retain state when used with data structures like binary trees?
Recursive algorithms, such as that used when walking a binary tree, do not lend themselves to maintaining state information between method calls in an easily accessible manner because the data within the recursive calls is lost when they lose scope.

##### 8. How do you define an enumerator?
You define an enumerator be defining a class that implements the IEnumerator<T> interface and the type parameter must be a valid type for the object that the class enumerates, so it must be constrained to implement the IComparable<T> interface

##### 9. What is an iterator?
A block of code that yields an ordered sequence of values

##### 10. What does yield do?
indicates the value that should be returned by each iteration
