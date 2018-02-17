namespace DesignPatterns
{
    /// <summary>
    /// Why? - Easy to implement, when extension by subclassing has too many possibilities
    ///     - The decorator pattern can be used to make it possible to extend (decorate) the functionality of a certain object at runtime. 
    ///     - Forces you to create a contract. this can benefit testing
    /// Benefits - Subclassing can lead to issues surrounding the substitution principle. This avoids those issues and supports the Open/Closed principle
    ///          - Very flexible pattern
    ///          - Easy to extend functionality
    ///          - Handles multiple decorators every easily
    /// Uses - Streaming
    /// When not to use it - when things are not components of the base, i.e. beverage, cake, stream, Decorator must inherit from the base.
    ///                    - when subclassing and having the components at compile time are needed.
    /// </summary>
    public class DecoratorPattern
    {
        public void ShowPattern()
        {
            Beverage beverage1 = new Espresso();
            beverage1 = new Mocha(beverage1);
            beverage1 = new Mocha(beverage1);
            beverage1 = new Whip(beverage1);

            var desc = beverage1.GetDescription();
            var total = beverage1.Cost();
        }
    }


    public abstract class Beverage
    {
        protected string Description = "Unknown Beverage";

        public abstract double Cost();

        public abstract string GetDescription();
    }

    public abstract class CondimentDecorator : Beverage
    {
    }

    public class Espresso : Beverage
    {
        public override double Cost()
        {
            return 1.99;
        }

        public override string GetDescription()
        {
            return "Espresso";
        }
    }

    public class DarkRoast : Beverage
    {
        public override double Cost()
        {
            return .89;
        }

        public override string GetDescription()
        {
            return "Dark Roast";
        }
    }

    public class Mocha : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .20 + _beverage.Cost();
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Mocha";
        }
    }

    public class Whip : CondimentDecorator
    {
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return .38 + _beverage.Cost();
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Whip";
        }
    }

}
