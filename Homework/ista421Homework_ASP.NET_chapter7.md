# Homework 1A
## ASP Chapter 7

##### 1. What is a Visual Studio Solution? How do you create them?

A visual Studio solution is a container for one or more projects. You create them by navigating to new project and then selecting blank solution under the other project types/visual studio solutions subheading.

##### 2. Why would you use an Empty project instead of a completed template? What are the
advantages of an empty project, are there disadvantages with creating a project from a
template?

By manually setting up the content and configuration, you learn more about the MVC framework. Also the initial investment in an MVC application pays dividends resulting in maintainable, extensible, well structured code with excellent support for unit testing.

##### 3. What is Nuget? Describe how you use it and why?

NuGet is a package manager for .NET and Visual Studio. NuGet can be used to find and install packages, that is, software pieces and assemblies and things that you want to use in your project. NuGet is not a tool that is specific to ASP.NET MVC projects. This is a tool that you can use inside of Visual Studio for console applications, WPF applications, Azure applications, any types of application. NuGet is a package manager, and is responsible for downloading, installing, updating, and configuring software in your system.


##### 4. Explain what a Reference is, what is it used for? How you would add or remove one?

A reference is similar to a link or connection between the program you are writing and a collection of namespaces, classes, and interfaces that support your program.  Once a resource has been referenced in your program then the program can access any code in that resource.  References are used both to minimize the work and duplication of code that already exists and also to link separate parts of a program to each other. They can be added with using statements or by right clicking on a project (or class within the project) and selecting add reference.  From that menu you can navigate and select any of the available installed resources or search source files elsewhere on your computer.

##### 5. What is a DI Container? In this book they reference Ninject as the software being used, are there
other software products that can be used for DI in Visual Studio?

A DI containter is a dependency injection container. The idea is to decouple the components in an MVC application, with a combination of interfaces, and a DI container that creates instances of objects by creating implementations of the interfaces they depend on and injecting them into the constructor. There are a plethora of other software products that can be used for DI in fact the visual studio default is IServiceCollection.

##### 6. What is a domain model and how is it used? What is a view model and how is it used?

You create a domain model by identifying the real world entities, operations, and rules that exist in the industry or activity that the application must support, known as the domain. You then create a software representation of the domain: the domain model. For the purposes of the ASP.NET MVC framework, the domain model is a set of C# types, classes and structs collectively known as domain types.  A view model is an abstract representation of a user interface, typically a C# class that exposes both properties for the data to be displayed in the UI and operations on the data that can be invoked from the UI.

##### 7. What is meant by the term Repository Pattern? How is it used?

Repository pattern refers to a mechanism that maintains a degree of separation between the data model entities and the storage and retrieval logic.

##### 8. What software development strategy is the term Mock Repository referring to? Why would you create a Mock repository?

The mock repository refers to the Test Driven Development strategy as creating mock objects allows for a narrow scope of testing when the particular method or class that you are testing references other parts of the program that perhaps have not been written yet.

##### 9. Describe the role played by a Controller in this chapter, what is a View as explained in this chapter?

In this chapter the controller serves the purpose of displaying the details of the products stored in our mock repository. The controller also contains a method that renders a view for the UI. A view is any output representation of information.

##### 10. What is a default route and what purpose does it serve? In what way does having readable URLs impact the website?

A default route tells the MVC Framework that it should send requests that arrive to your root URL of your application to a specified location.  Human readable URL's are a important because search engines weight keyword's found in URL's, users are more likely to navigate directly using human readable URL's and people are more likely to link to your URL if they understand and can easily type the routing.

##### 11. What is ORM? Are we employing this technique? If so how?

An ORM is an object relational mapper. It presents the tables, columns, and rows of a relational database through regular C# objects. It makes it much easier to incorporate a database into your program.  We have been using the entity framework ORM which prevents us from having to manually input SQL source code using ADO.NET directly.

##### 12. How many ways can you add Database support to your solution? Name at least one way.

There are a number of different ways to add database support to a solution.  The way we have learned is through the entity framework using SQL server and the LocalDB feature.

##### 13. What is a context class? Be specific.

A context class is a go between that will associate the model with the database when implementing a database in an MVC program.

##### 14. How are optional parameters used within this chapter, give examples.

One example is in implementing pagination into the view.  When  declaring the method ViewResult to display the page we set the default page value to 1. By setting a default value for a parameter we have made that parameter optional meaning if the parameter is omitted in the method call then it will default to whatever we set it to, in this case 1. We did something similar for the default routing.

##### 15. What does TDD mean?

Test Driven Development.

##### 16. What method is used in TDD to verify the success or failure of the code?

Unit testing is most common however, integration testing can also be used.  The idea being that before the code is written the tests are created from the program requirements and then the code is written to pass the tests.

##### 17. What are Html Helpers?

Using the HTML Helper class, we can create HTML Controls programmatically. HTML Helpers are used in View to render HTML content. HTML Helpers (mostly) is a method that returns a string. It is not mandatory to use HTML Helper classes for building an ASP.NET MVC application. We can build an ASP.NET MVC application without using them, but HTML Helpers helps in the rapid development of a view. HTML Helpers are more lightweight as compared to ASP.NET Web Form controls as they do not use ViewState and do not have event models.


##### 18. Breakdown this expression:
```
a. @Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new { page = x }))
```

This is a method call to an HTML helper, specifically one for creating a pagination index. An object is passed from the modelView to the HTML helper.

##### b. What does MvcHtmlString represent? How is it used?

It represents an HTML encoded string that should not be encoded again. It initializes a new instance of the MvcHtmlString class.

##### 19. What is Bootstrap? What is it used for?

Bootstrap is currently the most popular web framework for developing responsive web applications. It offers a number of features and benefits that can improve your users' experience with your web site, whether you're a novice at front-end design and development or an expert. Bootstrap is deployed as a set of CSS and JavaScript files, and is designed to help your website or application scale efficiently from phones to tablets to desktops.
