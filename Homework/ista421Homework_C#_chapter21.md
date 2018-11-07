# ISTA-421
## Chapter 21, C# Step by Step
#### Readings
Read chapter 21, pages 469 { 492 in the C# Step by Step book.
#### Discussion Questions

##### 1. What is the difference in the purposes of SQL and LINQ? In other words, why do we need two different query languages? Does LINQ replace SQL? Does SQL make LINQ unnecesary?
LINQ looks similar to SQL but it is far more flexible and can handle a wider variety of logical data structures

##### 2. What is the one essential requirement for the datastructures used with LNQ? Why is this requirement important?
LINQ requires the data to be stored in a data structure that implements the IEnumerable or
IEnumerable<T> interface

##### 3. Were does the LINQ Select() method live?
The Select method is not actually a method of the Array type. It is an extension method of
the Enumerable class. The Enumerable class is located in the System.Linq namespace and
provides a substantial set of static methods for querying objects that implement the generic
IEnumerable<T> interface.

##### 4. (Select) Explain, token by token, each token in this line of code:
```
IEnumerable<string> customerFirstNames = customers.Select(cust => cust.FirstName);
```
the Select method returns an enumerable collection based on a single type.

##### 5. (Filter) Explain, token by token, each token in this line of code:
```
IEnumerable<string> usCompanies = addresses.Where(addr =>
String.Equals(addr.Country, "United States")).Select(usComp => usComp.CompanyName);
```
The variable addr is an alias for a row in the addresses array, and the lambda expres-
sion returns all rows where the Country fi eld matches the string “United States”. The Where method returns an enumerable collection of rows containing every fi eld from the original collection. The Select method is then applied to these rows to project only the CompanyName field from this enumerable collection to return another enumerable collection of string objects. (The variable usComp is an alias for the type of each row in the enumerable collection returned by the Where method.) The type of the result of this complete expression is, therefore, IEnumerable<string>.

##### 6. (OrderBy) Explain, token by token, each token in this line of code:
```
IEnumerable<string> companyNames = addresses.OrderBy(addr =>
addr.CompanyName).Select(comp => comp.CompanyName);
```
To retrieve data in a particular order, you can use the OrderBy method. Like the Select and Wherecmethods, OrderBy expects a method as its argument. This method identifi es the expressions that you want to use to sort the data.

##### 7. (Group) Explain, token by token, each token in this line of code:
```
var companiesGroupedByCountry = addresses.GroupBy(addrs => addrs.Country);
```
The enumerable set returned by GroupBy contains all the fi elds in the original source collection, but the rows are ordered into a set of enumerable collections based on the fi eld identifi ed by the method specifi ed by GroupBy

##### 8. (Distinct) Explain, token by token, each token in this line of code:
```
int numberOfCountries = addresses.Select(addr => addr.Country).Distinct().Count();
```
You can eliminate duplicates from the calculation by using the Distinct method

##### 9. (Join) Explain, token by token, each token in this line of code:
```
var companiesAndCustomers =
customers.Select(c =>
new { c.FirstName, c.LastName, c.CompanyName }).Join(addresses, custs =>
custs.CompanyName, addrs => addrs.CompanyName, (custs, addrs) =>
new {custs.FirstName, custs.LastName, addrs.Country });
```
The Select method specifies the fields of interest in the customers array (FirstName and LastName), together with the field containing the common key (CompanyName). You use the Join method to join the data identified by the Select method with another enumerable collection. The parameters to the Join method are as follows:

* The enumerable collection with which to join
* A method that identifies the common key fields from the data identified by the Select method
* A method that identifies the common key fields on which to join the selected data
* A method that specifies the columns you require in the enumerable result set returned by the Join method


##### 10. Explain the difference between a deferred collection and a static, cached collection.
