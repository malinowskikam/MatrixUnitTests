using MatrixLibrary.Datatypes;
using MatrixLibrary.Matrices;
using MatrixLibrary.Norms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTests.MatricesTests
{
    [TestFixture]
    class GenericMatrixTest
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
    }
}
