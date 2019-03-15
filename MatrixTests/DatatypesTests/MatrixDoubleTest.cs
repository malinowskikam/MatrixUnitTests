using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MatrixLibrary.Datatypes;
    
namespace MatrixTests.DatatypesTests
{
    [TestFixture]
    class MatrixDoubleTest
    {
        [Test]
        public void ZeroConstantTest()
        {
            double expected = 0.0;

            double actual = new MatrixDouble().GetZero().GetValue();
            
            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void OneConstantTest()
        {
            double expected = 1.0;

            double actual = new MatrixDouble().GetOne().GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void MinusOneConstantTest()
        {
            double expected = -1.0;

            double actual = new MatrixDouble().GetMinusOne().GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void AddTest()
        {
            double expected = 7.0;

            double actual = new MatrixDouble(5.99).Add(new MatrixDouble(1.01)).GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void SubtractTest()
        {
            double expected = -1.0;

            double actual = new MatrixDouble(0.1).Subtract(new MatrixDouble(1.1)).GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void MultiplyTest()
        {
            double expected = 2.5;

            double actual = new MatrixDouble(0.25).Multiply(new MatrixDouble(10.0)).GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void DivideTest()
        {
            double expected = 0.5;

            double actual = new MatrixDouble(12.0).Divide(new MatrixDouble(24.0)).GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void DivideByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(delegate { new MatrixDouble(12.0).Divide(new MatrixDouble(0)).GetValue(); } );
        }

        [Test]
        public void InverseTest()
        {
            double expected = 1 / 6.54;

            double actual = new MatrixDouble(6.54).GetInverse().GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void EqualsTest()
        {
            MatrixDouble first = new MatrixDouble(11.11);
            MatrixDouble second = new MatrixDouble(11.11);

            bool actual = first.Equals(second);

            Assert.IsTrue(actual);
        }

        [Test]
        public void CompareTest()
        {
            MatrixDouble first = new MatrixDouble(75.01);
            MatrixDouble second = new MatrixDouble(-144.511);

            int result = first.CompareTo(second);

            Assert.That(result, Is.Positive);
        }

        [Test]
        public void AbsPositiveTest()
        {
            double expected = 0.654;

            double actual = new MatrixDouble(0.654).Abs().GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void AbsNegativeTest()
        {
            double expected = 14.56;

            double actual = new MatrixDouble(-14.56).Abs().GetValue();

            Assert.That(actual, Is.EqualTo(expected).Within(1e-10));
        }
    }
}
