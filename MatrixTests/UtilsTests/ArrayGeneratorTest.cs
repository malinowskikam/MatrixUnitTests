using Microsoft.QualityTools.Testing.Fakes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MatrixLibrary.MatrixUtils;

namespace MatrixTests.UtilsTests
{
    class ArrayGeneratorTest
    {
        [Test]
        public void GenerationTest()
        {
            using (ShimsContext.Create())
            {
                MatrixLibrary.MatrixUtils.Fakes.ShimArrayGenerator.nanoTime = () =>
                {
                    return 10L;
                };

                double[,] array1 = ArrayGenerator.Generate2DArrayOfDouble(2, 2);

                double[,] expected = { { 0.950496411859289, 0.751511535491567}, { 0.757902594170488, 0.692590497290991} };

                Assert.That(array1, Is.EqualTo(expected).Within(1e-10));
            }
        }
    }
}
