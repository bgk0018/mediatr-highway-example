# To Note

Typically, if there are any cross cutting concerns that we want to decorate over any object, this is where it would be tested.

For example, if we want to require authorization for access to a particular ```IServiceClient```, we would use the decorator pattern, implement
```IServiceClient``` with ```AuthorizingServiceClient```, and it would take in the ```IServiceClient``` it wants to decorate.
We then register everything with the IoC Container.

[An example of how to utilize decorator pattern](http://blog.ploeh.dk/2010/04/07/DependencyInjectionisLooseCoupling/)

The other thing we typically test if available, is the object graph registered in the container. Containers like SimpleInjector have
a ```Verify()``` method that will then traverse the registered services to insure that all dependencies are accounted for.
This is very helpful as a unit test as we don't have to wait until runtime to realize that we accidentally didn't register that 
new ```FooFactory``` I created.

Today, it looks like ```IServiceCollection``` doesn't have this feature and so we'll need to find another way to test the object graph's completness.