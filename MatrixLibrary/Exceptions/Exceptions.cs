using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Exceptions
{
    public class MatrixDimensionsMismatchException : Exception
    {
        public MatrixDimensionsMismatchException(String msg) : base(msg) { }
    }
}
