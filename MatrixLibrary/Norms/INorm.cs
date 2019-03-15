using MatrixLibrary.Datatypes;
using MatrixLibrary.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Norms
{
    public interface INorm<T1,T2> where T1 : IDatatype<T2> 
    {
        T2 CalculateNorm(IMatrix<T1, T2> Matrix);
    }
}
