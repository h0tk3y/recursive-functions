Recursive Functions
===================

SPb NRU ITMO, 2nd grade, Math Logic course, Hometask #6.
Implementing some arithmetic through recursive functions primitives.

See internal implementation of recursive functions primitives in
/RecursiveFunctions/RecursiveFunction.cs

See implementation of the arithmetic, which is required in the task:
/RecursiveFunctions/RecursiveOperations.cs

See tests and usage:
/UnitTests/Tests.cs

Synthax for recursive function example (should be defined in RecursiveOperations.cs)
```csharp
RecursiveFunction Foo = R(U(1), S(N, U(3))); //declaration
Foo.Call(a, b); //one way to call
((Call)Foo)(a,b); //another way to call
```
