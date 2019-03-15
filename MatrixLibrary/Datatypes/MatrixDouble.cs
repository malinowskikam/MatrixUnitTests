using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Datatypes
{
    public class MatrixDouble : IDatatype<double>
    {
        private double Value;

        private static MatrixDouble MD_ZERO = new MatrixDouble(0.0);
        private static MatrixDouble MD_ONE = new MatrixDouble(1.0);
        private static MatrixDouble MD_M_ONE = new MatrixDouble(-1.0);

        public MatrixDouble()
        {
        }

        public MatrixDouble(double Value)
        {
            this.Value = Value;
        }

        public double GetValue()
        {
            return this.Value;
        }
        /*
        public void SetValue(double NewValue)
        {
            this.Value = NewValue;
        }
        */
        public IDatatype<double> GetZero()
        {
            return MD_ZERO;
        }

        public IDatatype<double> GetOne()
        {
            return MD_ONE;
        }

        public IDatatype<double> GetMinusOne()
        {
            return MD_M_ONE;
        }

        public double Evaluate()
        {
            return GetValue();
        }

        public IDatatype<double> Add(IDatatype<double> Number)
        {
            return new MatrixDouble(this.GetValue() + Number.GetValue());
        }

        public IDatatype<double> Subtract(IDatatype<double> Number)
        {
            return new MatrixDouble(this.GetValue() - Number.GetValue());
        }

        public IDatatype<double> Multiply(IDatatype<double> Number)
        {
            return new MatrixDouble(this.GetValue() * Number.GetValue());
        }

        public IDatatype<double> Divide(IDatatype<double> Number)
        {
            if (Number.GetValue() == 0.0)
                throw new DivideByZeroException();
            return new MatrixDouble(this.GetValue() / Number.GetValue());
        }

        public IDatatype<double> GetInverse()
        {
            return new MatrixDouble(1.0 / this.GetValue());
        }

        public int CompareTo(IDatatype<double> Number)
        {
            return this.GetValue().CompareTo(Number.GetValue());
        }

        public IDatatype<double> Abs()
        {
            if (this.GetValue() < 0)
                return new MatrixDouble(-1.0 * this.GetValue());
            else
                return new MatrixDouble(this.GetValue());
        }

        public override bool Equals(Object o)
        {
            return this.GetValue() == ((IDatatype<double>)o).GetValue();
        }

        public override int GetHashCode()
        {
            return -1937169414 + Value.GetHashCode();
        }
    }
}
