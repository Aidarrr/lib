using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interpolation
{
    struct rgb
    {
        int red;
        int green;
        int blue;
    }

    struct vec2d
    {
        int x;
        int y;

        public vec2d(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct triangle
    {
        vec2d[] vec2Ds;

        public triangle(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            vec2Ds = new vec2d[3] {new vec2d(x1,y1), new vec2d(x2, y2), new vec2d(x3, y3) };                                                                                                                                                                                                 
        }                                                                                                                              
    }

    public partial class Form1 : Form
    {
        static int widthGouraud = 532, heightGouraud = 341;
        int step = 20;
        //int[,] figure = new int[20, 4]
        //{ {9, 2, 6, 3 }, { 9, 2, 12, 3 }, { 9, 2, 9, 5 },  { 7, 7, 9, 5 }, { 9, 5, 11, 7 },
        //  {4, 6, 6, 3},{ 14, 6, 12, 3}, { 4, 6, 7, 7 }, { 14, 6, 11,7 }, { 7, 7, 8, 9 },
        //  { 11, 7, 10, 9}, { 4, 6, 4, 9 }, { 14, 6, 14, 9 }, { 4, 9, 6, 11 }, { 12, 11, 14, 9 },
        //  { 8, 9, 10, 9}, { 6, 11, 8, 9 }, { 12, 11, 10, 9}, { 6, 11, 9, 12 }, {12, 11, 9, 12 } };
        
        triangle[] figure = new triangle[]
        {
           new triangle(6, 3, 9, 2, 9, 5), 
           new triangle(9, 2, 12, 3, 9, 5),
           new triangle(12, 3, 14, 6, 9, 5),
           new triangle(9, 5, 11, 7, 14, 6),
           new triangle(),
           new triangle(),
           new triangle(),
           new triangle(),
        };

        public Form1()
        {
            InitializeComponent();
        }

        public void PutPixel(int x, int y, bool[,] pixels)
        {
            pixels[x, y] = true;
        }

        void Brezenham(int xn, int yn, int xk, int yk, bool[,] pixels)
        {
            int dx, dy;
            int s, sx, sy, kl, incr1, incr2;
            bool swap;

            sx = 0;
            if ((dx = xk - xn) < 0) { dx = -dx; --sx; } else if (dx > 0) ++sx;
            sy = 0;
            if ((dy = yk - yn) < 0) { dy = -dy; --sy; } else if (dy > 0) ++sy;


            swap = false;
            kl = dx; s = dy;
            if (kl < s)
            {
                dx = s; dy = kl; kl = s; swap = true;
            }

            s = (incr1 = 2 * dy) - dx;
            incr2 = 2 * dx;

            PutPixel(xn, yn, pixels);
            while (--kl >= 0)
            {
                if (s >= 0)
                {
                    if (swap) xn += sx; else yn += sy;
                    s -= incr2;
                }
                if (swap) yn += sy; else xn += sx;
                s += incr1;
                PutPixel(xn, yn, pixels);
            }
        }

        public void DrawGrid(int width, int height, bool[,] pixels, Graphics graphics)
        {
            for (int y = 0; y < height / step; y++)
            {
                for (int x = 0; x < width / step; x++)
                {
                    graphics.DrawRectangle(Pens.Black, x * step, height - 1 - y * step - step, step, step);
                    if (pixels[x, y])
                        graphics.FillRectangle(Brushes.Green, x * step + 2, height - 1 - y * step - step + 2, step - 3, step - 3);
                    
                }
            }
        }

        public void Figure_Brezenham(bool[,] pixels)
        {
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                Brezenham(figure[i, 0], figure[i, 1], figure[i, 2], figure[i, 3], pixels);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool[,] pixelsFigure = new bool[(widthGouraud / step), (heightGouraud / step)];
            Bitmap bitmap = new Bitmap(widthGouraud, heightGouraud);
            Graphics graphics = Graphics.FromImage(bitmap);
            

        }
    }
}
