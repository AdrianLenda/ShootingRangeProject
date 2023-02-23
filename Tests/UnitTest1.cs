namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Test sprawdzaj�cy, czy 2 + 2 = 4
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Test sprawdzaj�cy, czy d�ugo�� tekstu jest poprawnie obliczana
            string text = "Hello, world!";
            Assert.AreEqual(13, text.Length);
        }

        [TestMethod]
        public void TestMethod3()
        {
            // Test sprawdzaj�cy, czy lista jest poprawnie sortowana
            List<int> numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
            numbers.Sort();
            CollectionAssert.AreEqual(new List<int> { 1, 1, 2, 3, 3, 4, 5, 5, 6, 9 }, numbers);
        }

        [TestMethod]
        public void TestMethod4()
        {
            // Test sprawdzaj�cy, czy wyj�tek jest rzucony, gdy pr�bujemy podzieli� przez zero
            Assert.ThrowsException<DivideByZeroException>(() => { int result = 1 / 0; });
        }

        [TestMethod]
        public void TestMethod5()
        {
            // Test sprawdzaj�cy, czy warto�� zwracana przez funkcj� jest poprawna
            int result = SomeClass.Add(2, 3);
            Assert.AreEqual(5, result);
        }
    }

    public static class SomeClass
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

}