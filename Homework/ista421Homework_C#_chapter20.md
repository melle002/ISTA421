# ISTA-421
## Chapter 20, C# Step by Step
#### Readings
Read chapter 20, pages 439 { 466 in the C# Step by Step book.
#### Discussion Questions

##### 1. What is a delegate? Explain delegates in terms of pointers and reference types.
A delegate is a reference type that can be used to encapsulate a named or an anonymous method. Delegates are similar to function pointers in C++; however, delegates are type-safe and secure.

##### 2. How do you declare a delegate? Include a discussion of types, return values, names, and parameters.
* you use the delegate keyword
* You specify the return type, a name for the delegate, and any parameters
```
delegate void stopMachineryDelegate();
```

##### 3. How do you create instances of delegates and assign values to the instance? What are the values?
After you have declared the delegate, you can create an instance and make it and make it refer to a matching method by using the += compound assignment operator.
```
class Controller
{
  delegate void stopMachineryDelegate();   //the delegate type
  private stopMachineryDelegate stopMachinery;   //an instance of the delegate
......
  public Controller()
  {
    this.stopMachinery += folder.StopFolding;
  }
......
}
```


##### 4. How do you invoke a method that has been added to a delegate?
You call the method by invoking the delegate.

##### 5. What is an event? Why do we have events?
 used to define and trap significant actions and arrange for a delegate to be called to handle the situation

##### 6. How do you declare events?
You declare an event similaly to how you declare a field. However, because events are intended to be used with delegates, the type of an event must be a delegate, and you must prefix the declaration with the event keyword.
```
event delegateTypeName eventName
```

##### 7. How do delegates recognize event subscriptions? How do you unsubscribe an event from a delegate?
by using the += operator and the -= operators respectively

##### 8. How do you raise an event? How do you declare code that raises an event?
You can raise an event by calling it like a method.

##### 9. Explain with specicity what happens when an event fires and that event has been attached to a delegate.
All attached delegates are called in sequence
