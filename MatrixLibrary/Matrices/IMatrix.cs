using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary.Datatypes;
using MatrixLibrary.Norms;

namespace MatrixLibrary.Matrices
{
    public interface IMatrix<T1,T2> where T1 : IDatatype<T2>
    {
        int GetRowCount();
        int GetColumnCount();

        T1[,] GetRawMatrix();

        //Mnoży macierz przez inną macierz
        IMatrix<T1, T2> Multiply(IMatrix<T1, T2> Factor);
        //Dodaje 2 macierze
        IMatrix<T1, T2> Add(IMatrix<T1, T2> MatrixToAdd);
        //Mnoży macierz przez skalar
        IMatrix<T1, T2> Scale(T1 Scalar);
        //Oblicza podaną normę macierzy
        T2 GetNorm(INorm<T1, T2> Norm);

        bool Equals(Object o);
    }
}
