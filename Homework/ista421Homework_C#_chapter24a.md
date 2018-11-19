# ISTA-421
## Chapter 24a, C# Step by Step
#### Readings
Read chapter 24, pages 559 - 575 in the C# Step by Step book.
#### Discussion Questions

##### 1. What is an asynchronous method? When the book talks about a contract, what is the contract and who is it with?
An asynchronous method is one that does not block the current thread on which it starts to run. When an application invokes an asynchronous method, an implied contract expects the method to return control to the calling environment quite quickly and to perform its work on a separate thread.
##### 2. What can be the problem with decomposing a series of discrete method calls into a set of tasks, such as we saw in chapter 23?
Although the start method initiates a task, it does not wait for it to complete, so events can occur out of sequence.
##### 3. What can be the problem with decomposing a series of discrete method calls into a set of continuations? When does the last continuation complete" as compared to the previous continuations? What problem might this cause?
Using a Wait method can block the thread executing the method and obviate the purpose of using a continuation in the first place.
##### 4. What might be the problem with implementing te previous solution as a continuation passing a delegate? What would be your interpretation with this error message: The application called an interface that was marshaled for a diferent thread."?
The issue here is that only the user interface thread can manipulate user interface controls, and now you are attempting to write to a control from a different thread; the thread being used to run the Task.
##### 5. The book suggests a solution using a continuation delegate calling another continuation delegate via an anonymous function. What does the book ientify as a problem with this suggested solution?
It is messy an difficult to maintain.
##### 6. What does the async modier do? What does the await operator do?
The purpose of the async and await keywords in C# is to enable you to define and call methods that can run asynchronously. The async modifier indicates that a method contains functionality that can be run asynchronously. The await operator specifies the points at which this asynchronous functionality should be performed.
##### 7. What is an awaitable object? Be specic.

An awaitable object is a type that provides the GetAwaiter method, which returns an object that in turn provides methods for running code and waiting for it to complete. The C# compiler converts your code into statements that use these methods to create an appropriate continuation.
##### 8. In a method denition, how do you create and run a Task and return a reference to the Task? What is the type of such a method? What does the method return?
Within the method definition you declare a task object calling the .Run method and return the task object.  The method type is Task
##### 9. How do you dene method calls in the implementation of an async method? Specically, you must define a task, you must run the task, you must implement the task, and you must await the task. What is the syntax for doing this?
```
private async Task doFirstLongRunningOperation()
{
  Task first = Task.Run(() => {code for first operation});
  Task second = Task.Run(() => {code for second operation});
  await first;
  await second;
}
```
##### 10. What is the diference between decomposing a series of method calls that do not return values, and a series of method calls that return values? What is the Result property of a method that returns a value? How do you use the await operator in this circumstance?
To do this you use the generic Task< TResult > class, where the type parameter TResult specifies the type of the result.
You create and start a Task< TResult > object in a similar way as for an ordinary Task. The primary difference is that the code you execute should return a value. The await operator extracts the value from the Task and assigns it to the return variable.
##### 11. What is the dierence between the await operator and the Wait method?

The wait method always blocks the current thread and does not allow it to be reused until the task completes.
