# ISTA-421
## Chapter 22, C# Step by Step
#### Readings
Read chapter 22, pages 493 { 514 in the C# Step by Step book.
#### Discussion Questions
##### 1. Explain the difference between the concepts of associativity and precedence.
associativity defines whether the operator evaluates from left to right or from right to left and precedence is the order in which each operator is executed

##### 2. Explain the difference between the concepts of binary and unary operators.
A unary operator is an operator that has just one operand and a binary operator is an operator that has two operands.

##### 3. List four constraints imposed by C# with respect to operator overloading.
* You cannot change the precedence and associativity of an operator. Precedence and
associativity are based on the operator symbol (for example, +) and not on the type (for example, int) on which the operator symbol is being used. Hence, the expression a + b * c is
always the same as a + (b * c) regardless of the types of a, b, and c.
* You cannot change the multiplicity (the number of operands) of an operator. For example, * (the symbol for multiplication) is a binary operator. If you declare a * operator for your own type, it must be a binary operator.
* You cannot invent new operator symbols. For example, you can’t create an operator symbol such as ** for raising one number to the power of another number. You’d have to defi ne a
method to do that.
* You can’t change the meaning of operators when they are applied to built-in types. For
example, the expression 1 + 2 has a predefined meaning, and you’re not allowed to override this
meaning. If you could do this, things would be too complicated.
* There are some operator symbols that you can’t overload. For example, you can’t overload the dot (.) operator, which indicates access to a class member. Again, if you could do this, it would lead to unnecessary complexity


##### 4. What is the syntax for overloading operators? Discuss access, scope, return value types, and parameter types and multiplicity.
```
struct Hour
{
public Hour(int initialValue) => this.value = initialValue;
public static Hour operator +(Hour lhs, Hour rhs) => new Hour(lhs.value + rhs.value);
...
private int value;
}
```
* The operator is public. All operators must be public.
* The operator is static. All operators must be static. Operators are never polymorphic and cannot
use the virtual, abstract, override, or sealed modifi ers.
* A binary operator (such as the + operator shown in this example) has two explicit arguments, and a unary operator has one explicit argument. (C++ programmers should note that operators never have a hidden this parameter.)

##### 5. What are symmetric overloaded binary operators and how do they differ from non-symmetric over- loaded binary operators?
symmetric overloaded binary operators are valid for both sides of the equation; meaning that both types can be computed right to left and left to right, where as non-symmetric cannot.
##### 6. Can you overload compound assignment operators? If so, please state how you do so. If not, explain why not.
Yes and No because when you have overloaded the appropriate simple operator the overloaded version  is automatically called when you use its associated compound assignment operator.

##### 7. What is the diference between overloading increment and decrement operators for value types and reference types?
```
Hour now = new Hour(9);
Hour postfix = now;
now = Hour.operator ++(now); // pseudocode, not valid C#
```
If Hour is a class, the assignment statement postfi x = now makes the variable postfi x refer to the same object as now. Updating now automatically updates postfix! If Hour is a structure, the assignment statement makes a copy of now in postfix, and any changes to now leave postfix unchanged, which is what you want.

##### 8. Why do we overload some operators in pairs?
Some operators naturally come in pairs.

##### 9. What is the difference between widening conversion and narrowing conversion?
result is wider than the original value
int => double
result is narrower than original value
double => int

##### 10. What is the difference between explicit conversion and implicit conversion?
explicit's result is narrower and data loss may occur
implicit's result is wider and requires no special syntax and never throws an
exception.
