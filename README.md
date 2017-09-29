# Project Description
This is a fork of PortableIoC created by Jeremy Likness.

Portable IOC is a tiny thread-safe Inversion of Control container for
Universal Windows Platform apps.

## About This Fork
This fork is intended to provide a simpler way register and resolve dependencies.

For example, this fork allows you to register an instance of IBar that depends on IFoo like this: 

```
ioc.Register<IFoo, Foo>()
ioc.Register<IBar, Bar>()
```

Instead of like this:

```
ioc.Register<IFoo>(ioc => new Foo());
ioc.Register<IBar>(ioc => new Bar(ioc.Resolve<IFoo>());
```

Registered implementations should have a constructor that takes only interfaces. These are then resovlved as dependencies through the container. For example, Bar contains the following constructor:

```
public Bar(IFoo foo) ...
```

Alternatively the implementation can have default parameterless constructor, like Foo.

## About PortableIoC
Portable IOC is a tiny (less than 200 lines of code) thread-safe and portable Inversion of Control container. It is designed to make it simple and easy to wire dependencies for client projects on the Universal Windows Platform (UWP). Features include:

* Dependency resolution
* Lifetime management (shared and non-shared copies) 
* Supports both constructor and property injection 
* Full control over registration - delete registrations and destroy shared copies as needed
* Multiple resolution support through a simple label

To create an instance of the master container simply new it: 

` IPortableIoC ioc = new PortableIoc(); `

The container will automatically register itself, so this is possible: 

` IPortableIoC anotherIoCReference = ioc.Resolve<IPortableIoC>(); `

To register an instance of IFoo that is implemented as Foo:

` ioc.Register<IFoo>(ioc => new Foo()); `

To register a specific instance of IFoo in a container called "container2" that is implemented as FooExtended:

` ioc.Register<IFoo>(ioc => new FooExtended(), "Container2"); `

To register an instance of IBar that depends on IFoo: 

` ioc.Register<IBar>(ioc => new Bar(ioc.Resolve<IFoo>()); `

If you are using property injection: 

` ioc.Register<IBar>(ioc => new Bar { Foo = ioc.Resolve<IFoo>() }); `

To resolve bar: 

` IBar bar = ioc.Resolve<IBar>(); `

To resolve bar from a named container: 

` IBar bar = ioc.Resolve<IBar>("Container2"); `

To resolve a non-shared copy of bar: 

` IBar bar = ioc.Resolve<IBar>(true); `

You can also unregister and destroy copies of objects.
