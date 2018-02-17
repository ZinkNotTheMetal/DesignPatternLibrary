namespace DesignPatterns
{
    /// <summary>
    /// Why? - To get Object / classes to look similar
    /// Benefits - Ability to interact with multiple ypes by making a base, creating interface design
    /// Uses - AutoMapper - from something to something else
    ///      - DTO - tranfering from DataTransfer Objects to ViewModels or Models
    ///      - Legacy systems - working with legacy systems to redesign the UI but keep and maintain the existing structure.
    ///      - Agregating - pulling in multiple third party sources but providing and defining our own models.
    /// Why not everywhere? - need, composition can get out of hand.
    /// The difference between Facade and Adapter pattern is the intent.
    /// The intent of the Adapter Pattern is to alter an intrface so that it matches one that a client is expecting.
    /// </summary>
public class AdapterPattern
    {
        public static void Example()
        {
            OldBrokenDownCar oldCar = new OldBrokenDownCar();
            NewCar newCar = new NewCar();

            TestCar(oldCar);
            TestCar(newCar);
        }

        public static string TestCar(ICar car)
        {
            return $"Honk: {car.Honk()}  &  Drive: {car.Drive()}";
        }
    }

    /// <summary>
    /// In this case we are using the adapter pattern to abstact out what is common between these two cars.
    /// Then we create a method TestCar which takes in the Interface and allows us to interact with each of the cars
    /// </summary>
    public class NewCar : ICar
    {
        public string Drive()
        {
            return "Driving real fast";
        }

        public string Honk()
        {
            return "Honk, Honk";
        }
    }

    public class OldBrokenDownCar : ICar
    {
        public string Drive()
        {
            return "Barely turns on";
        }

        public string Honk()
        {
            return "boop";
        }
    }

    public interface ICar
    {
        string Drive();
        string Honk();
    }
}
