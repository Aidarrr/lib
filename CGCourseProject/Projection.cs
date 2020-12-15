using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class Projection //Проецирование и опр. цвета пов-ей
    {
        private List<Polygon> projectedPolygons;
        private FileService fileService;
        public Projection(FileService fileService)
        {
            this.fileService = fileService;
            projectedPolygons = new List<Polygon>();
        }

        public List<Polygon> GetPolygons()
        {
            return projectedPolygons;
        }

        

        public void ProjectAndNormalize()
        {
            Transformation transformation = new Transformation(fileService);
            Matrix t = transformation.LookAt(new Vector(0.2, 0.4, -0.8));

            Matrix viewportMatrix = new Matrix(0, 0, Form1.width, Form1.height);
            Matrix normalizationMatrix = new Matrix(fileService.minX, fileService.maxX, fileService.minY, fileService.maxY, fileService.minZ, fileService.maxZ);

            Matrix projectionMatrix = viewportMatrix * normalizationMatrix * t * new Matrix(0, 0, 8);

            List<Polygon> originalPolygons = fileService.GetPolygons();

            foreach (var polygon in originalPolygons)
            {
                Vector v1 = Vector.MatrixMultVector(projectionMatrix, polygon.vertexes[0]);
                Vector v2 = Vector.MatrixMultVector(projectionMatrix, polygon.vertexes[1]);
                Vector v3 = Vector.MatrixMultVector(projectionMatrix, polygon.vertexes[2]);

                projectedPolygons.Add(new Polygon(v1, v2, v3));
            }
        }

        public void SetGrayScaleColor()
        {
            foreach (var polygon in projectedPolygons)
            {
                polygon.SetColor();
            }
        }

        public void SortProjectedPolygons()
        {
            projectedPolygons.Sort(delegate (Polygon p1, Polygon p2) { return p1.GetZAverage().CompareTo(p2.GetZAverage()); });
        }
    }
}
