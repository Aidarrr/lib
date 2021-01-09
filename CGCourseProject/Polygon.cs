using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class Polygon
    {
        public Vector[] vertexes;
        public UInt32 color;
        private int zAverage;
        static public int countVertexes = 3;

        public Polygon()
        {
            vertexes = new Vector[3];
        }

        public Polygon(Vector v1, Vector v2, Vector v3)
        {
            vertexes = new Vector[3] { new Vector(v1), new Vector(v2), new Vector(v3) };
        }

        public int GetZAverage()
        {
            return zAverage;
        }

        public UInt32 SetColor()
        {
            double sum = 0;
            foreach (var vector in vertexes)
            {
                sum += vector.z;
            }

            zAverage = Convert.ToInt32(sum / countVertexes);
            if (zAverage > 240)
                zAverage = 240;

            UInt32 intermediateColor = Convert.ToUInt32(Math.Abs(zAverage));
            color = 0xFF000000 | intermediateColor | intermediateColor << 8 | intermediateColor << 16;

            return color;
        }

        public static Polygon MultiplyPolygonOnMatrix(Matrix m, Polygon p)
        {
            Vector v1 = Vector.MatrixMultVector(m, p.vertexes[0]);
            Vector v2 = Vector.MatrixMultVector(m, p.vertexes[1]);
            Vector v3 = Vector.MatrixMultVector(m, p.vertexes[2]);

            return new Polygon(v1, v2, v3);
        }
    }
}
