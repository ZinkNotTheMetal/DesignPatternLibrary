using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class StatePatternDemonstration
    {
        [Test]
        public void RunShowPattern()
        {
            StatePattern statePattern = new StatePattern();
            statePattern.ShowPattern();
        }
    }
}
