using MatrixLibrary.Datatypes;
using MatrixLibrary.Exceptions;
using MatrixLibrary.Matrices;
using MatrixLibrary.Norms;
using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTests.MatricesTests
{
    [TestFixture]
    class MatrixTest
    {
        [Test]
        public void DimensionsTest()
        {
            int ExpectedRowCount = 2;
            int ExpectedColumnCount = 2;

            IDatatype<double>[,] rawMatrix = new IDatatype<double>[ExpectedRowCount, ExpectedColumnCount];

            for (int i = 0; i < ExpectedRowCount; i++)
                for (int j = 0; j < ExpectedColumnCount; j++)
                    rawMatrix[i, j] =
                        new MatrixLibrary.Datatypes.Fakes.StubIDatatype<double>();

            Matrix<double> m = new Matrix<double>(rawMatrix);

            Assert.IsTrue(m.GetRowCount()==ExpectedRowCount && m.GetColumnCount()==ExpectedColumnCount);
        }

        [Test]
        [TestCase(new double[] { 2, 3, 1, 4 })]
        [TestCase(new double[] { 0.1, 22, 0, 11 })]
        [TestCase(new double[] { 100, 200, 300, 400 })]
        [TestCase(new double[] { -1, 40, 110, 10 })]
        public void TypeTest(double[] input)
        {
            double[,] raw = { { input[0], input[1] }, { input[2], input[3] } };
            Matrix<double> m = Matrix<double>.OfDouble(raw);

            CollectionAssert.AllItemsAreInstancesOfType(m.GetRawMatrix(), typeof(IDatatype<double>));
        }

        [Test]
        [TestCase(new double[] { 2, 3, 1, 4 },2)]
        [TestCase(new double[] { 0.1, 22, 0, 11 }, 0.1)]
        [TestCase(new double[] { 100, 200, 300, 400 }, 100)]
        [TestCase(new double[] { -1, 40, 110, 10 }, -1)]
        [TestCase(new double[] { 0, 0, 0, 0 }, 0)]
        public void NormTest(double[] rawMatrix,double expectedNorm)
        {
            INorm<IDatatype<double>, double> norm =
                new MatrixLibrary.Norms.Fakes.StubINorm<IDatatype<double>, double>()
                {
                    CalculateNormIMatrixOfT0T1 = (expectedMatrix) => { return expectedMatrix.GetRawMatrix()[0,0].Evaluate(); }
                };

            double[,] values = { { rawMatrix[0], rawMatrix[1] }, { rawMatrix[2], rawMatrix[3] } };
            Matrix<double> matrix = Matrix<double>.OfDouble(values);

            double actualNorm = matrix.GetNorm(norm);

            Assert.That(actualNorm, Is.EqualTo(expectedNorm));
        }

        [Test]
        public void AddingTest()
        {
            double[,] expected = { { 1, 4 }, { 2, 7 } };
            double[,] raw1 = { { 3, 2 }, { -5, 4 } };
            double[,] raw2 = { { -2, 2 }, { 7, 3 } };

            Matrix<double> expectedMatrix = Matrix<double>.OfDouble(expected);
            Matrix<double> actual = (Matrix<double>)Matrix<double>.OfDouble(raw1).Add(Matrix<double>.OfDouble(raw2));

            CollectionAssert.AreEqual(expectedMatrix.GetRawMatrix(), actual.GetRawMatrix());
        }

        [Test]
        public void AddingErrorTest()
        {
            double[,] raw1 = { { 3, 2 }, { -5, 4 } };
            double[,] raw2 = { { -2, 2, 1 }, { 7, 3, 2 } };

            Assert.Throws<MatrixDimensionsMismatchException>(delegate { Matrix<double>.OfDouble(raw1).Add(Matrix<double>.OfDouble(raw2)); });
        }

        [Test]
        public void ScalingTest()
        {
            double[,] expected = { { 6, 4 }, { -10, 8 } };
            double[,] raw = { { 3, 2 }, { -5, 4 } };
            double scalar = 2;

            Matrix<double> expectedMatrix = Matrix<double>.OfDouble(expected);

            Matrix<double> actual = (Matrix<double>)Matrix<double>.OfDouble(raw).Scale(new MatrixDouble(scalar));

            CollectionAssert.AreEqual(expectedMatrix.GetRawMatrix(), actual.GetRawMatrix());
        }

        [Test]
        public void MultiplicationTest()
        {
            double[,] expected = { { 28, 13 }, { 4, 5 } };
            double[,] raw1 = { { 7, 3 }, { 1, 2 } };
            double[,] raw2 = { { 4, 1 }, { 0, 2 } };

            Matrix<double> expectedMatrix = Matrix<double>.OfDouble(expected);

            Matrix<double> actual = (Matrix<double>)Matrix<double>.OfDouble(raw1).Multiply(Matrix<double>.OfDouble(raw2));

            CollectionAssert.AreEqual(expectedMatrix.GetRawMatrix(), actual.GetRawMatrix());
        }

        [Test]
        public void MultiplicationErrorTest()
        {

            double[,] raw1 = { { 7, 3, 1 }, { 1, 2, 2 }, { 1, 1, 1 } };
            double[,] raw2 = { { 4, 1 }, { 0, 2 } };

            Assert.Throws<MatrixDimensionsMismatchException>(delegate { Matrix<double>.OfDouble(raw1).Multiply(Matrix<double>.OfDouble(raw2)); });
        }
    }
}
