using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.MatrixUtils
{
    public class ArrayGenerator
    {
        public static double[,] Generate2DArrayOfDouble(int x,int y)
        {
            Random r = new Random((int)nanoTime());
            double[,] array = new double[x, y];

            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    array[i, j] = r.NextDouble();

            return array;
        }

        //ze stacka
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
