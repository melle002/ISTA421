# ISTA-421
## Chapter 23, C# Step by Step
#### Readings
Read chapter 23, pages 517 { 558 in the C# Step by Step book.
#### Discussion Questions

##### 1 List two reasons for multitasking, and explain the rationale for them.
To improve responsiveness by allowing multiple processes to take place at the same time and to improve scalability.  By allowing multiple operations to occur at once the application can do more within a given time frame and thus scale to something larger.

##### 2 Explain Moore's law. What does Moore's law have to do with multitasking?
The number of transistors that can be placed inexpensively on an integrated circuit will increase exponentially, doubling every two years.  This law has held true for 50 years and lead to the rise of multicore processors as we have reached the physical limit for how fast an individual processor can be.  Multicore processors work by multitasking allowing a machine to do multiple things at once improving it's overall efficiency and speed.

##### 3 In UWP, what namespace is used as the container for the multitasking methods?
`System.Threading.Tasks`

##### 4 What is the difference between tasks and threads? Explain.
A task is something you want done. A thread is one of the many possible workers which performs that task.

##### 5 What is the ThreadPool?
A queuing mechanism to distribute the workload across a set of threads allocated to a thread pool.

##### 6 What parameters does the Task() constructor take?
All versions of the Task() constructor take an action delegate as the parameter.

##### 7 How do you start a thread?
Call Start() on the thread object.

##### 8 What is the difference between the Start() and Run() methods?
The Start() method adds a task to the threadpool to be scheduled.  When it is time for the task to be run the Run() method is called to execute it.

##### 9 What is the difference between creating independent tasks with Tasks and paralleliztion with Parallel? Explain.
parallelization is automatic , more efficient , and easier on the programmer.


##### 10 Explain how manual cancellation works using a cancellation token.
it provides information on the status of the cancellation
