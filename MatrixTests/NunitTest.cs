using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTests
{
    [TestFixture]
    class NunitTest
    {
        [Test]
        public void FrameworkTest()
        {
            Assert.That(true, Is.EqualTo(true));
        }
    }
}
