using MatrixLibrary.Datatypes;
using MatrixLibrary.Exceptions;
using MatrixLibrary.Norms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Matrices
{
    public class Matrix<T1> : IMatrix<IDatatype<T1>, T1>
    {
        private readonly int RowCount;
        private readonly int ColumnCount;

        private IDatatype<T1>[,] Values;

        public Matrix(IDatatype<T1>[,] values)
        {
            Values = values;

            this.RowCount = values.GetLength(0);
            this.ColumnCount = values.GetLength(1);
        }
        public static Matrix<double> OfDouble(double[,] values)
        {
            int RowCount = values.GetLength(0);
            int ColumnCount = values.GetLength(1);

            IDatatype<double>[,] raw = new IDatatype<double>[RowCount, ColumnCount];

            for (int i = 0; i < RowCount; i++)
                for (int j = 0; j < ColumnCount; j++)
                    raw[i, j] = new MatrixDouble(values[i,j]);

            return new Matrix<double>(raw);
        }

        public IMatrix<IDatatype<T1>, T1> Add(IMatrix<IDatatype<T1>, T1> MatrixToAdd)
        {
            if (this.GetRowCount() != MatrixToAdd.GetRowCount())
                throw new MatrixDimensionsMismatchException("Row count mismatch");

            if (this.GetColumnCount() != MatrixToAdd.GetColumnCount())
                throw new MatrixDimensionsMismatchException("Column count mismatch");

            IDatatype<T1>[,] raw = new IDatatype<T1>[this.RowCount,this.ColumnCount];

            for (int i = 0; i < this.RowCount; i++)
                for (int j = 0; j < this.ColumnCount; j++)
                    raw[i, j] = (this.GetRawMatrix()[i, j]).Add(MatrixToAdd.GetRawMatrix()[i, j]);

            return new Matrix<T1>(raw);
        }

        public int GetColumnCount()
        {
            return this.ColumnCount;
        }

        public T1 GetNorm(INorm<IDatatype<T1>, T1> Norm)
        {
            return Norm.CalculateNorm(this);
        }

        public IDatatype<T1>[,] GetRawMatrix()
        {
            return this.Values;
        }

        public int GetRowCount()
        {
            return this.RowCount;
        }

        public IMatrix<IDatatype<T1>, T1> Multiply(IMatrix<IDatatype<T1>, T1> Factor)
        {
            if (this.GetColumnCount() != Factor.GetRowCount())
                throw new MatrixDimensionsMismatchException("Row/Column count mismatch");

            int newRowCount = this.GetRowCount();
            int newColCount = Factor.GetColumnCount();

            IDatatype<T1>[,] raw = new IDatatype<T1>[newRowCount,newColCount];

            for (int i = 0; i < newRowCount; i++) //wiersze
                for (int j = 0; j < newColCount; j++) //kolumny
                {
                    IDatatype<T1> res = this.GetRawMatrix()[i,0].Multiply(Factor.GetRawMatrix()[0,j]);
                    for (int k = 1; k < this.GetColumnCount(); k++)
                        res = res.Add(this.GetRawMatrix()[i,k].Multiply(Factor.GetRawMatrix()[k,j]));

                    raw[i,j] = res;
                }

            return new Matrix<T1>(raw);
        }



        public IMatrix<IDatatype<T1>, T1> Scale(IDatatype<T1> Scalar)
        {
            IDatatype<T1>[,] raw = new IDatatype<T1>[this.RowCount, this.ColumnCount];

            for (int i = 0; i < this.RowCount; i++)
                for (int j = 0; j < this.ColumnCount; j++)
                    raw[i, j] = this.GetRawMatrix()[i, j].Multiply(Scalar);

            return new Matrix<T1>(raw);
         }

        public override Boolean Equals(Object o)
        {
            Matrix<T1> m = (Matrix<T1>)o;

            if (this.GetRowCount() != m.GetRowCount())
                throw new MatrixDimensionsMismatchException("Row count mismatch");

            if (this.GetColumnCount() != m.GetColumnCount())
                throw new MatrixDimensionsMismatchException("Column count mismatch");

            return this.Values.Equals(m.Values);
        }

        public override int GetHashCode()
        {
            var hashCode = -1134529517;
            hashCode = hashCode * -1521134295 + RowCount.GetHashCode();
            hashCode = hashCode * -1521134295 + ColumnCount.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IDatatype<T1>[,]>.Default.GetHashCode(Values);
            return hashCode;
        }
    }
}
