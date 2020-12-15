using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class Transformation
    {
        private FileService fileService;

        public Transformation(FileService fileService)
        {
            this.fileService = fileService;
        }

        private void Transform (Matrix transformationMatrix)
        {
            List<Polygon> originalPolygons = fileService.GetPolygons();
            List<Polygon> transformatedPolygons = new List<Polygon>();

            foreach (var polygon in originalPolygons)
            {
                transformatedPolygons.Add(Polygon.MultiplyPolygonOnMatrix(transformationMatrix, polygon));
            }

            fileService.SetPolygons(transformatedPolygons);
        }


        public void Rotate(double angle)
        {
            Matrix rotationMatrix = new Matrix(angle);

            Transform(rotationMatrix);
        }

        public void Translate(double tx, double ty, double tz)
        {
            Matrix translationMatrix = new Matrix(tx, ty, tz);

            Transform(translationMatrix);
        }

        public Matrix LookAt(Vector cameraPosition)
        {
            Vector x;
            Vector y;
            Vector z;
            Vector u = new Vector(0, 1, 0);

            Vector center = new Vector(0, 0, 0);

            z = center - cameraPosition;
            x = u ^ z;
            y = z ^ x;

            return new Matrix(x, y, z, cameraPosition);

        }

        private Vector GetModelCenter()
        {
            List<Polygon> originalPolygons = fileService.GetPolygons();
            double epsilon = 0.1;

            foreach (var polygon in originalPolygons)
            {
                foreach (var vector in polygon.vertexes)
                {
                    double length1 = Math.Abs(fileService.maxY - vector.y);
                    double length2 = Math.Abs(fileService.minY - vector.y);

                    if (Math.Abs(length2 - length1) < epsilon)
                        return new Vector(vector.x / (fileService.maxX - fileService.minX), vector.y / (fileService.maxY - fileService.minY), vector.z / (fileService.maxZ - fileService.minZ));
                }
                
            }

            return new Vector(0, 0, 0);
        }
    }
}
