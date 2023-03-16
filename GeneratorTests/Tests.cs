using LRS;

namespace GeneratorTests
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void PseudoFinonacciTest()
        {
            int[] coeffs = new int[] { 1, 1 };
            int absoluteMember = 0;
            int[] firstElements = new int[] { 0, 1 };
            var random = new CSR(coeffs, absoluteMember, firstElements);
            var expected = new int[] { 1, 0, 1, 1, 0, 1 };
            var actualResults = new int[] { random.GetRandom(), random.GetRandom(), random.GetRandom(), random.GetRandom(), random.GetRandom(), random.GetRandom() };

            Assert.That(actualResults, Is.EqualTo(expected));
        }
        [Test]
        public void ZeroesTest1()
        {
            var coeffs = new int[] { 0, 0, 0 };
            int absoluteMember = 0;
            int[] firstElements = new int[] { 0, 0, 0 };

            var random = new CSR(coeffs, absoluteMember, firstElements);
            var expected = new int[10];
            var actualResults = new int[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = 0;
                actualResults[i] = random.GetRandom();
            }

            Assert.That(actualResults, Is.EqualTo(expected));
        }
        [Test]
        public void ZeroesTest2()
        {
            var coeffs = new int[] { 0, 0, 0 };
            int absoluteMember = 0;
            int[] firstElements = new int[] { 1, 1, 1 };

            var random = new CSR(coeffs, absoluteMember, firstElements);
            var expected = new int[10];
            var actualResults = new int[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = 0;
                actualResults[i] = random.GetRandom();
            }

            Assert.That(actualResults, Is.EqualTo(expected));
        }

        [Test]
        public void ZeroesTest3()
        {
            var coeffs = new int[] { 1, 1, 1 };
            int absoluteMember = 0;
            int[] firstElements = new int[] { 0, 0, 0 };

            var random = new CSR(coeffs, absoluteMember, firstElements);
            var expected = new int[10];
            var actualResults = new int[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = 0;
                actualResults[i] = random.GetRandom();
            }

            Assert.That(actualResults, Is.EqualTo(expected));
        }
        [Test]
        public void OneTest1()
        {
            var coeffs = new int[] { 1, 1, 1 };
            int absoluteMember = 0;
            int[] firstElements = new int[] { 1, 1, 1 };

            var random = new CSR(coeffs, absoluteMember, firstElements);
            var expected = new int[10];
            var actualResults = new int[10];
            for (int i = 0; i < 10; i++)
            {
                expected[i] = 1;
                actualResults[i] = random.GetRandom();
            }

            Assert.That(actualResults, Is.EqualTo(expected));
        }
    }
}