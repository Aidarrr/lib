using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGCourseProject
{
    public class FileService
    {
        private string fileName;
        private List<Vector> vectors;
        private List<Polygon> polygons;
        public double maxX = double.MinValue, minX = double.MaxValue,
                       maxY = double.MinValue, minY = double.MaxValue,
                       maxZ = double.MinValue, minZ = double.MaxValue;

        public FileService(string fileName)
        {
            this.fileName = fileName;
            vectors = new List<Vector>();
            polygons = new List<Polygon>();
        }

        public List<Polygon> GetPolygons()
        {
            return polygons;
        }

        public void SetPolygons(List<Polygon> polygons)
        {
            this.polygons = polygons;
        }

        private void GetVectorsFromFile(StreamReader file)
        {
            string line;
            string[] words;

            while (true)
            {
                line = file.ReadLine();
                if (line.Length < 2)
                    continue;
                else if (line.Substring(0, 2) == "v ")
                    break;
            }


            while (line.Substring(0, 2) == "v ")
            {
                words = line.Split(' ');

                double x = Convert.ToDouble(words[1]);
                double y = Convert.ToDouble(words[2]);
                double z = Convert.ToDouble(words[3]);

                vectors.Add(new Vector(x, y, z));

                if (x > maxX)
                    maxX = x;
                if (x < minX)
                    minX = x;
                if (y > maxY)
                    maxY = y;
                if (y < minY)
                    minY = y;
                if (z > maxZ)
                    maxZ = z;
                if (z < minZ)
                    minZ = z;

                line = file.ReadLine();
            }
        }

        private void GetPolygonsFromFile(StreamReader file)
        {
            string line;
            string[] words;
            string[] subwords;
            int[] vertexNumber = new int[Polygon.countVertexes];

            while (true)
            {
                line = file.ReadLine();
                if (line.Length < 2)
                    continue;
                else if (line.Substring(0, 2) == "f ")
                    break;
            }

            while (line != null && line.Length >= 2 && line.Substring(0, 2) == "f ")
            {
                words = line.Split(' ');

                for (int i = 1; i < words.Length; i++)
                {
                    subwords = words[i].Split('/');
                    vertexNumber[i - 1] = Convert.ToInt32(subwords[0]) - 1;
                }

                polygons.Add(new Polygon(
                                            new Vector(vectors[vertexNumber[0]]),
                                            new Vector(vectors[vertexNumber[1]]),
                                            new Vector(vectors[vertexNumber[2]])
                                        )
                            );

                line = file.ReadLine();
            }
        }

        public void GetModelFromFile()
        {
            StreamReader file = new StreamReader(fileName, Encoding.UTF8);

            GetVectorsFromFile(file);
            GetPolygonsFromFile(file);

            file.Close();
        }
    }
}
