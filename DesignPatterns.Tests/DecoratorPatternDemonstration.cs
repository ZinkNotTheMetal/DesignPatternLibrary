using NUnit.Framework;

namespace DesignPatterns.Tests
{
    [TestFixture]
    public class DecoratorPatternDemonstration
    {
        [Test]
        public void ShowPattern()
        {
            var decoratorPattern = new DecoratorPattern();
            decoratorPattern.ShowPattern();
        }
    }
}
