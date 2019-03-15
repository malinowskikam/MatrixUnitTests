using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Datatypes
{
    public interface IDatatype<T>
    {
        IDatatype<T> GetZero();
        IDatatype<T> GetMinusOne();
        IDatatype<T> GetOne();

        T GetValue();
        //void SetValue(T NewValue);
        double Evaluate();
        IDatatype<T> Add(IDatatype<T> number);
        IDatatype<T> Subtract(IDatatype<T> number);
        IDatatype<T> Multiply(IDatatype<T> number);
        IDatatype<T> Divide(IDatatype<T> number);
        IDatatype<T> GetInverse();
        IDatatype<T> Abs();
        int CompareTo(IDatatype<T> number);
        bool Equals(Object o);
        String ToString();

    }
}
