using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecursiveFunctions;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        private static readonly Random Rng = new Random();

        [TestMethod]
        public void TestAddition()
        {
            for (int i = 0; i < 10; ++i)
            {
                int a = Rng.Next(1024),
                    b = Rng.Next(1024);
                Assert.AreEqual(RecursiveOperations.Add.Call(a, b), a+b);
            }
        }

        [TestMethod]
        public void TestSubtraction()
        {
            for (int i = 0; i < 10; ++i)
            {
                int a = Rng.Next(1024),
                    b = Rng.Next(1024);
                Assert.AreEqual(RecursiveOperations.Sub.Call(a, b), Math.Max(a-b, 0));
            }
        }

        [TestMethod]
        public void TestDivision()
        {
            for (int i = 0; i < 10; ++i)
            {
                int a = Rng.Next(150),
                    b = Rng.Next(150) + 1;
                Assert.AreEqual(RecursiveOperations.Div.Call(a, b), a/b);
            }
        }

        [TestMethod]
        public void TestModulo()
        {
            for (int i = 0; i < 10; ++i)
            {
                int a = Rng.Next(150),
                    b = Rng.Next(150) + 1;
                Assert.AreEqual(RecursiveOperations.Mod.Call(a, b), a%b);
            }
        }

        [TestMethod]
        public void TestIsPrime()
        {
            for (int i = 3; i < 40; ++i)
                Assert.AreEqual(RecursiveOperations.IsP.Call(i) == 1, IsPrime(i));
        }

        [TestMethod]
        public void TestNextPrime()
        {
            for (int i = 0; i < 10; ++i)
            {
                int a = Rng.Next(30)+2;
                Assert.AreEqual(RecursiveOperations.NeP.Call(a), NextPrime(a));
            }
        }

        [TestMethod]
        public void TestNthPrime()
        {
            for (int i = 0; i < 12; ++i)
                Assert.AreEqual(RecursiveOperations.ThP.Call(i), NthPrime(i));
        }

        [TestMethod]
        public void TestPartialLog()
        {
            for (int i = 0; i < 10; ++i)
            {
                int @base = Rng.Next(5)+2,
                    n = Rng.Next(21)+1;
                Assert.AreEqual(RecursiveOperations.Log.Call(@base, n), PartialLog(@base, n));
            }
        }

        private bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i < Math.Sqrt(number) + 1; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        private int NextPrime(int number)
        {
            for (int i = number + 1; ; ++i)
                if (IsPrime(i))
                    return i;
        }

        private int NthPrime(int n)
        {
            int result = 2;
            for (int i = 0; i < n; ++i)
                result = NextPrime(result);
            return result;
        }

        private int PartialLog(int @base, int x)
        {
            for (int i = 0; i < 100; ++i)
            {
                if (x%@base != 0) return i;
                x /= @base;
                if (x == 0) return i+1;
            }
            return -1;
        }
    }
}
