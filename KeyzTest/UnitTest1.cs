using KeyzLibCalcul;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace KeyzTest
{
    public class CalculTests
    {
        private Calcul _calcul;

        [SetUp]
        public void Setup()
        {
            _calcul = new Calcul();
        }

        [Test]
        public void TestAddition()
        {
            double result = _calcul.Calculate("1.5+1.5");
            Assert.AreEqual(3.0, result);
        }

        [Test]
        public void TestSubtraction()
        {
            double result = _calcul.Calculate("5-2");
            Assert.AreEqual(3.0, result);
        }

        [Test]
        public void TestMultiplication()
        {
            double result = _calcul.Calculate("2*3");
            Assert.AreEqual(6.0, result);
        }

        [Test]
        public void TestDivision()
        {
            double result = _calcul.Calculate("6/2");
            Assert.AreEqual(3.0, result);
        }

        [Test]
        public void TestExponentiation()
        {
            double result = _calcul.Calculate("2^3");
            Assert.AreEqual(8.0, result);
        }

        [Test]
        public void TestIntegerDivision()
        {
            double result = _calcul.Calculate("7%2");
            Assert.AreEqual(3.0, result);
        }
    }
}
