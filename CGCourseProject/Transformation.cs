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

        public void Rotate(double angle)
        {
            List<Polygon> originalPolygons = fileService.GetPolygons();
            Matrix rotationMatrix = new Matrix(angle);
            List<Polygon> rotatedPolygons = new List<Polygon>();

            foreach (var polygon in originalPolygons)
            {
                rotatedPolygons.Add(Polygon.MultiplyPolygonOnMatrix(rotationMatrix, polygon));
            }

            fileService.SetPolygons(rotatedPolygons);
        }

        public void Translate(double tx, double ty, double tz)
        {
            List<Polygon> originalPolygons = fileService.GetPolygons();
            Matrix translationMatrix = new Matrix(tx, ty, tz);
            List<Polygon> translatedPolygons = new List<Polygon>();

            foreach (var polygon in originalPolygons)
            {
                translatedPolygons.Add(Polygon.MultiplyPolygonOnMatrix(translationMatrix, polygon));
            }

            fileService.SetPolygons(translatedPolygons);
        }
    }
}
