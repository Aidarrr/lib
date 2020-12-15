using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class Matrix
    {
        public double[,] matrixData;

        public Matrix()
        {
            matrixData = new double[4, 4];
            for (int i = 0; i < 4; i++)
                matrixData[i, i] = 1.0;
        }

        public Matrix(double[,] matrixData)
        {
            this.matrixData = matrixData;
        }

        public Matrix(int x, int y, int w, int h) : this()
        {
            matrixData[0, 3] = x + 2 * w / 3.0;
            matrixData[1, 3] = y + h / 2.0;
            matrixData[2, 3] = 255.0 / 2.0;

            matrixData[0, 0] = w / 2.0;
            matrixData[1, 1] = h / -2.0;
            matrixData[2, 2] = 255.0 / 2.0;
        }

        public Matrix(double l, double r, double b, double t, double n, double f) : this()
        {
            matrixData[0, 0] = 2.0 / (r - l);
            matrixData[1, 1] = 2.0 / (t - b);
            matrixData[2, 2] = -2.0 / (f - n);

            matrixData[0, 3] = -(r + l) / (r - l);
            matrixData[1, 3] = -(t + b) / (t - b);
            matrixData[2, 3] = -(f + n) / (f - n);
        }

        public Matrix(Vector x, Vector y, Vector z, Vector c) : this()
        {
            matrixData[0, 0] = x.x;
            matrixData[0, 1] = x.y;
            matrixData[0, 2] = x.z;
            //matrixData[0, 3] = -c.x;

            matrixData[1, 0] = y.x;
            matrixData[1, 1] = y.y;
            matrixData[1, 2] = y.z;
            //matrixData[1, 3] = -c.y;

            matrixData[2, 0] = z.x;
            matrixData[2, 1] = z.y;
            matrixData[2, 2] = z.z;
            //matrixData[2, 3] = -c.z;


        }

        public Matrix(double sx, double sy, double sz, bool f) : this()
        {
            matrixData[0, 0] = sx;
            matrixData[1, 1] = sy;
            matrixData[2, 2] = sz;
        }

        public Matrix(double tx, double ty, double tz) : this()
        {
            matrixData[0, 3] = tx;
            matrixData[1, 3] = ty;
            matrixData[2, 3] = tz;
        }

        public Matrix(double angle) : this()
        {
            double rad = 0.0174533;
            double angleInRad = rad * angle;

            matrixData[0, 0] = Math.Cos(angleInRad);
            matrixData[0, 2] = Math.Sin(angleInRad);

            matrixData[2, 0] = -Math.Sin(angleInRad);
            matrixData[2, 2] = Math.Cos(angleInRad);
        }

        static public Matrix operator *(Matrix m1, Matrix m2)
        {
            double[,] resultMatrix = new double[4, 4];

            int i, j, k;
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    for (k = 0; k < 4; k++)
                        resultMatrix[i, j] += m1.matrixData[i, k] * m2.matrixData[k, j];

            return new Matrix(resultMatrix);
        }
    }
}
