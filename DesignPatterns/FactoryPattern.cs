using System;

namespace DesignPatterns
{
    /// <summary>
    /// Why? - Protect and manage initialization, creation dependency on switching
    /// Benefits - Places that need the object, do not have to worry about instantiation. Code that needs the object doesn't need to have the instantiation at compile time.
    ///          - Reduces number of if this instantiated do this
    /// Uses? - AutoFac, Employee Repository with different Orms behind it
    /// Why not everywhere? - Have to change factory to add new implementations
    ///                     - have to have the same "base"
    ///                     - IoC might be able to do this for us
    ///                     - Factory cannot be changed out without changing code
    ///                     - Problem might not be complex enough to need a factory
    /// </summary>
    public class FactoryPattern
    {
        interface Product
        {

        }

        class ConcreteProductA : Product
        {
        }

        class ConcreteProductB : Product
        {
        }

        abstract class Creator
        {
            public abstract Product FactoryMethod(string type);
        }

        class ConcreteCreator : Creator
        {
            public override Product FactoryMethod(string type)
            {
                switch (type)
                {
                    case "A": return new ConcreteProductA();
                    case "B": return new ConcreteProductB();
                    default: throw new ArgumentException("Invalid type", "type");
                }
            }
        }
    }
}
