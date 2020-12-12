using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGCourseProject
{
    public partial class Form1 : Form
    {
        static public int width = 920, height = 600;
        Bitmap pictureBitmap;
        Graphics graphics;
        FileService fileService = new FileService("Chair.obj");

        public Form1()
        {
            pictureBitmap = new Bitmap(width, height);
            graphics = Graphics.FromImage(pictureBitmap);
            
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Transformation transformation = new Transformation(fileService);

            if (e.KeyCode == Keys.Right)
            {
                graphics.Clear(Color.White);
                transformation.Rotate(10);
                DrawModel();
            }
            else if (e.KeyCode == Keys.Left)
            {
                graphics.Clear(Color.White);
                transformation.Rotate(-10);
                DrawModel();
            }
            pictureBox1.Image = pictureBitmap;
        }

        private void DrawModel()
        {
            Projection projection = new Projection(fileService);
            projection.ProjectAndNormalize();
            projection.SetGrayScaleColor();
            projection.SortProjectedPolygons();
            List<Polygon> polygons = projection.GetPolygons();

            foreach (var polygon in polygons)
            {
                Vector v1 = polygon.vertexes[0];
                Vector v2 = polygon.vertexes[1];
                Vector v3 = polygon.vertexes[2];

                Point[] points = new Point[3] { new Point(Convert.ToInt32(v1.x), Convert.ToInt32(v1.y)), new Point(Convert.ToInt32(v2.x), Convert.ToInt32(v2.y)), new Point(Convert.ToInt32(v3.x), Convert.ToInt32(v3.y)) };

                graphics.FillPolygon(new SolidBrush(Color.FromArgb((int)polygon.color)), points);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileService.GetModelFromFile();

            DrawModel();

            pictureBox1.Image = pictureBitmap;
        }
    }
}
