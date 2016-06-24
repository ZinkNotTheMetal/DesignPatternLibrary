namespace DesignPatterns
{
    /// <summary>
    /// Why? - Clean interface, handles many dependent subsystems, makes software easier to understand and test
    /// Benefits - cleaner code, subsystems can be switched out relatively easily
    /// Uses - Harmony Remote system - very smooth 
    /// Why not everywhere? - Complex, not needed, confusing to read with one subsystem, introducing another layer
    /// 
    /// Defining the Facade Pattern
    ///   1) What is the interface that we want / need
    ///   2) Research each of the subsystems
    ///   3) Implement all subsystems in concrete class of interface
    /// </summary>
    public class FacadePattern
    {
        public void ShowPattern()
        {
            IFacadePattern harmonyRemote = new HomeTheaterFacade(new Amplifier(), new Television(), new DvdPlayer());
            harmonyRemote.WatchMovie();
        }
    }

    /// <summary>
    /// The difference between Facade and Adapter pattern is the intent.
    /// The intent of the Facade Pattern is to provide a simplified interface to a subsystem or many subsystems
    /// </summary>
    public class HomeTheaterFacade : IFacadePattern
    {
        public Amplifier Amplifier { get; set; }
        public Television Television { get; set; }
        public DvdPlayer DvdPlayer { get; set; }

        public HomeTheaterFacade(Amplifier amp, Television tv, DvdPlayer dvd)
        {
            Amplifier = amp;
            Television = tv;
            DvdPlayer = dvd;
        }
        
        public void WatchMovie()
        {
            Amplifier.IsOn = true;
            Television.IsOn = true;
            DvdPlayer.IsOn = true;
        }

        public void WatchTv()
        {
            Amplifier.IsOn = true;
            Television.IsOn = true;
            DvdPlayer.IsOn = true;
        }
    }

    public interface IFacadePattern
    {
        Amplifier Amplifier { get; set; }

        Television Television { get; set; }

        DvdPlayer DvdPlayer { get; set; }

        void WatchMovie();

        void WatchTv();
    }

    /// <summary>
    /// Subsystem
    /// </summary>
    public class Amplifier
    {
        public bool IsOn { get; set; }
    }

    /// <summary>
    /// Subsystem
    /// </summary>
    public class Television
    {
        public bool IsOn { get; set; }
    }

    /// <summary>
    /// Subsystem
    /// </summary>
    public class DvdPlayer
    {
        public bool IsOn { get; set; }
    }



}
