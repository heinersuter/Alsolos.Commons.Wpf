namespace Alsolos.Commons.Wpf.UnitTests.Utils
{
    using Alsolos.Commons.Wpf.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComparisonComparerTests
    {
        [TestMethod]
        public void CompareNullWithNull()
        {
            var comparer = new ComparisonComparer<string>(CompareStrings);

            var result = comparer.Compare(null, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CompareAWithNull()
        {
            var comparer = new ComparisonComparer<string>(CompareStrings);

            var result = comparer.Compare("A", null);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CompareNullWithA()
        {
            var comparer = new ComparisonComparer<string>(CompareStrings);

            var result = comparer.Compare(null, "A");

            Assert.AreEqual(-1, result);
        }

        private static int CompareStrings(string x, string y)
        {
            return string.CompareOrdinal(x, y);
        }
    }
}
