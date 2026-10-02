# Part 01 — answers

---

## ShippingCostCalculator

- What was the problem? the class violate the open /closed principle OCP and the single responsibility principle. It was doing too much and was hard to maintain or modify or add new shipping methods.
- What did you change? I refactored the class to use the strategy pattern. I created a new interface called ShippingCostStrategy and created separate classes for each shipping method that implement this interface.


---

## OrderProcessor

- What was the problem? the class violate single responsibility principle one class was doing too much no single source for changes and it was hard to maintain or modify and testing and violate dependency inversion principle DIP because it was tightly coupled by using new keyword .
- What did you change? extract each one of the responsibilities into separate classes and use dependency injection to inject the dependencies into the OrderProcessor class .

---

## Notifications

- What was the problem? the classses denpend on inheritance and tightly coupled and not easy to add more channels and use features didnot need them.
- What did you change? usingg compisition instead of inheritance and create a new interface called INotificationChannel and create separate classes for each notification channel that implement this interface and use dependency injection to inject the dependencies into the NotificationService class

---


//part2:

 why an abstract class is a better fit than an interface ?

 An abstract class is better suited here because the Template Method pattern relies on defining a shared algorithm skeleton (Export) and re-using common concrete helper logic (Load, Validate, Save) in one central place. An interface cannot hold state or fully enforce this sequence of execution without code duplication across all implementing classes.

 //part 3

 Before Refactoring: time=~3500 ms ,, Time Complexity: O(N * M)

 After Refactoring: time=1 ms ,, Time Complexity: O(N + M)