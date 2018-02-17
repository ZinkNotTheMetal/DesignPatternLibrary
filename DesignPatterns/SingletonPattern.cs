namespace DesignPatterns
{
    /// <summary>
    /// Why? - Only need 1 instance, easy instantiation, lifecycle problems
    /// Benefits - Modifying the object in one place, there is only one object in the entire lifecycle
    /// Uses? - IoC, Startup
    /// Why not everywhere? - Singletons cannot be subclassed, violates Single Responsibility, Couples code, Makes testing more difficult
    /// </summary>
    public class SingletonPattern
    {

        // Private static object can access only inside the Emp class.  
        private static SingletonPattern _instance;

        // Private empty constructor to restrict end use to deny creating the object.  
        private SingletonPattern() {}

        // A public property to access outside of the class to create an object.  
        public static SingletonPattern Instance => _instance ?? (_instance = new SingletonPattern());
    }
}