using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class Vector
    {
        public double x, y, z, w;
        public Vector()
        {
            x = 0.0;
            y = 0.0;
            z = 0.0;
            w = 1.0;
        }
        public Vector(double x1, double y1, double z1)
        {
            x = x1;
            y = y1;
            z = z1;
            w = 1.0;
        }

        public Vector(Vector v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
            w = v.w;
        }

        static public Vector MatrixMultVector(Matrix m, Vector v) //Умножение матрицы на вектор
        {
            double[] v1 = new double[4];
            v1[0] = v.x;
            v1[1] = v.y;
            v1[2] = v.z;
            v1[3] = v.w;
            double[] arr_res = new double[4];

            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    arr_res[i] += m.matrixData[i, j] * v1[j];
                }
            }

            Vector v_res = new Vector();
            v_res.x = arr_res[0];
            v_res.y = arr_res[1];
            v_res.z = arr_res[2];
            v_res.w = arr_res[3];
            return v_res;
        }
    }
}
