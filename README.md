# GoF - Creational - Builder

- [UML diagram](#uml-diagram)
- [Intent](#intent)
- [Example](#example)
- [Components](#components)
- [:warning: Important Consideration](#warning-important-consideration)
- [Pros and Cons](#pros-and-cons)
- [Other Variations](#other-variations)
  - [Simplified Builder](#simplified-builder)
  - [Fluent Builder](#fluent-builder)
  - [Nested Builder](#nested-builder)
  - [Combining with Factory Method](#combining-with-factory-method)
  - [Hierarchical Builder](#hierarchical-builder)
  - [Complex Builder](#complex-builder)
- [References](#references)



## UML diagram
![State](https://www.dofactory.com/img/diagrams/net/builder.png)



## Intent

The Builder is a creational design pattern used to construct complex objects step by step. This approach allows for the creation of different representations of an object using the same construction process. Moreover, it helps to separate the responsibility of constructing an object from its use, enhancing the flexibility and control over the construction process.



## Example

Imagine you're customizing a car directly from the manufacturer. You begin by choosing a basic model, and then you add various options: the type of engine, the color of the paint, the materials for the interior, and technological enhancements like a premium sound system or GPS navigation.

In this scenario, the manufacturer acts as the **Director** within the Builder pattern, guiding the assembly of your car. The specific options you select (such as the engine, paint color, interior materials, and technology features) function as **Concrete Builders**. Each one contributes unique customizations to the final product: your customized car.

This method showcases the Builder pattern's ability to facilitate the step-by-step construction of a complex object—the car. It provides substantial flexibility in how the object is customized, all while clearly distinguishing the process of building the object from the utilization of the finished product.

> [Demo Code](./Dotnet/ClassicBuilder/Program.cs)



## Components

- **Director**: Oversees the construction process, determining the sequence of operations to produce the desired object. It instructs the Builder on the subsequent steps but remains detached from the detailed creation of individual components.

- **Builder Interface**: Defines the blueprint for constructing parts of a complex object. This contract is fulfilled by **Concrete Builders** to methodically build and assemble the object's elements.

- **Concrete Builder**: Executes the **Builder Interface**, implementing the specific steps required. Each **Concrete Builder** is tailored to create a unique version of the product, equipped with the logic necessary for its construction. This builder manages the construction sequence and provides access to the completed **Product**.

- **Product**: Represents the culmination of the building process, varying in design and features based on the client's requirements and the **Concrete Builder's** execution.



## :warning: Important Consideration

The Builder pattern is tasked with ensuring objects are only created in valid states. It enforces the construction process's rules and constraints, maintaining the object's consistency. Should any step directed by the **Director** be overlooked or performed out of sequence, the **Concrete Builder** must identify and halt the creation of an invalid object.



## Pros and Cons

- ✅ **Separation of Construction and Representation**: Allows building complex objects step by step and varying the product with the same construction process.
- ✅ **Encapsulation of Code for Construction**: The actual construction code is isolated from the part of the code that uses the object, improving maintainability.
- ✅ **Flexibility in Object Creation**: Provides control over the construction process, allowing for different representations of an object from the same builder.
- ✅ **Improved Readability**: When creating complex objects, the builder pattern can make code more readable and manageable.
- ❌ **Complexity:** Introduces multiple new classes, which can complicate the codebase unnecessarily for simpler objects.
- ❌ **Mutable Builder State**: If not carefully implemented, builders can retain state between object constructions, leading to unexpected results.
- ❌ **Performance Overhead**: The additional layer of abstraction can introduce a slight performance overhead.
- ❌ **Verbose**: For straightforward object constructions, using the pattern might result in more verbose code compared to using telescoping constructors or static factory methods.



## Other Variations


### Simplified Builder

In scenarios where the goal is to streamline the creation process, and there's no need for multiple builders, opting for a simplified approach without the **Director** and **Builder Interface** is common. This variant relies solely on the **Concrete Builder** and the **Product**, offering the flexibility to construct an object from various points in the code.

- **Objects with Numerous Optional Parameters**: The Builder pattern facilitates the construction process, allowing for the specification of essential parameters first, followed by any optional ones as necessary.

- **Objects Whose Constructors Have Many Parameters**: Employing the Builder pattern streamlines object creation, enabling the setting of mandatory parameters upfront, with the flexibility to add optional parameters later.

> [Demo Code](./Dotnet/SimplifiedBuilder/Program.cs)


### Fluent Builder

Implementing the Builder pattern with a fluent interface enhances readability and expressiveness by enabling method call chaining. This approach results in cleaner and more intuitive code, where each method call returns the builder object itself, allowing for the seamless integration of multiple configuration steps.

> [Demo Code](./Dotnet/FluentBuilder/Program.cs)


### Nested Builder

Nested classes in many programming languages offer a unique way to implement the Builder pattern. This method keeps an object's properties private, ensuring they're only accessible through the builder class or the object's own methods (Product). It's an effective strategy to guarantee the object remains in a valid state throughout its construction.

In languages like C#, this approach can be further enhanced with the `partial` keyword, allowing the construction logic to be kept separate from the object's structural definition, thereby maintaining clean and organized code.

> [Demo Code](./Dotnet/NestedBuilder/Program.cs)


### Combining with Factory Method

Integrating the Builder pattern with the Factory Method pattern offers nuanced control over object creation, enhancing encapsulation and abstraction.

- **Concealing Object Creation**: To abstract the instantiation process from clients, the Builder pattern can obfuscate the direct use of the `new` keyword, offering a fluent interface for object creation without exposing construction details.

> [Demo Code](./Dotnet/FactoryBuilder/Program.cs)

- **Supporting Multiple Builders**: For systems requiring diverse object configurations, employing multiple builders facilitates a robust and adaptable codebase. This approach allows for the detailed customization of objects through distinct builders.

> [Demo Code](./Dotnet/FactoryMultiBuilders/Program.cs)

- **Leveraging Implicit Build**: Languages like C# support implicit operators, a contemporary twist on the Factory Method pattern. This technique can conceal the `Build()` method, streamlining the object creation process into a more implicit operation.

> [Demo Code](./Dotnet/ImplicitBuild/Program.cs)


### Hierarchical Builder

Employing the Builder pattern for constructing hierarchical object structures facilitates the creation of complex entities with nested levels. This method is particularly useful for building objects that require multiple layers of composition, ensuring clarity and maintainability in the construction process.

> [Demo Code](./Dotnet/HierarchicalBuilder/Program.cs)


### Complex Builder

The Builder pattern is adept at managing the construction of objects that entail intricate assembly procedures. It excels in scenarios where the creation process involves numerous steps, conditional logic, or requires the integration of various components, providing a structured and scalable approach to object instantiation.

> [Demo Code](./Dotnet/ComplexBuilder/Program.cs)


## References
- [doFactory](https://www.dofactory.com/net/builder-design-pattern)
- [Other Design Patterns](https://github.com/NelsonBN/design-patterns)
