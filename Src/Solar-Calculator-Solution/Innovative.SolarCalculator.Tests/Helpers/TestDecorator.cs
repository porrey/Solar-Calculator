using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
    public class Assert2
    {
        public static void AreEqual(object x, object y)
        {
            Assert.That(x, Is.EqualTo(y));
        }

        public static void AreEqual(double x, double y, double delta)
        {
            Assert.Multiple(()=>
            {
                Assert.That(x, Is.AtLeast(y - delta));
                Assert.That(x, Is.AtMost(y + delta));
            });
        }

        public static void IsTrue(bool value)
        {
            Assert.That(value, Is.EqualTo(true));
        }

        public static void IsFalse(bool value)
        {
            Assert.That(value, Is.EqualTo(false));
        }

        public static void AreSame(object x, object y)
        {
            Assert.That(x, Is.SameAs(y));
        }
    }
}
