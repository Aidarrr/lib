using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipping
{
    public partial class Form1 : Form
    {
        static int width = 1180, height = 732;
        int step = 20;
        int minX_i = 11, minX_j = 0, maxX_i = 12, maxX_j = 0;
        int minY_i = 2, minY_j = 1, maxY_i = 18, maxY_j = 3;
        int minRecX_i = 0, minRecX_j = 0, maxRecX_i = 0, maxRecX_j = 2;
        int minRecY_i = 0, minRecY_j = 1, maxRecY_i = 1, maxRecY_j = 3;

        int[,] figure = new int[20, 4]
        { {9, 2, 6, 3 }, { 9, 2, 12, 3 }, { 9, 2, 9, 5 },  { 7, 7, 9, 5 }, { 9, 5, 11, 7 },
          {4, 6, 6, 3},{ 14, 6, 12, 3}, { 4, 6, 7, 7 }, { 14, 6, 11,7 }, { 7, 7, 8, 9 },
          { 11, 7, 10, 9}, { 4, 6, 4, 9 }, { 14, 6, 14, 9 }, { 4, 9, 6, 11 }, { 12, 11, 14, 9 },
          { 8, 9, 10, 9}, { 6, 11, 8, 9 }, { 12, 11, 10, 9}, { 6, 11, 9, 12 }, {12, 11, 9, 12 } };

        double[,] rectangle = new double[4, 4]
        {
             {16.0, 11.0, 41.0, 11.0 }, { 41.0, 11.0, 41.0, 25.0 }, { 16.0, 25.0, 41.0, 25.0 },  { 16.0, 11.0, 16.0, 25.0 }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int moveX, moveY;
            int randomX_Positive = rand.Next(0, width / step - figure[maxX_i, maxX_j]);
            int randomX_Negative = -1 * (rand.Next(0, figure[minX_i, minX_j]));
            int randomY_Positive = rand.Next(0, height / step - figure[maxY_i, maxY_j]);
            int randomY_Negative = -1 * (rand.Next(0, figure[minY_i, minY_j]));

            if (randomX_Positive > Math.Abs(randomX_Negative))
                moveX = randomX_Positive;
            else
                moveX = randomX_Negative;

            if (randomY_Positive > Math.Abs(randomY_Negative))
                moveY = randomY_Positive;
            else
                moveY = randomY_Negative;

            for (int i = 0; i < figure.GetLength(0); i++)
            {
                figure[i, 0] += moveX;
                figure[i, 2] += moveX;
                figure[i, 1] += moveY;
                figure[i, 3] += moveY;
            }

            bool[,] pixelsFigure = new bool[(width / step), (height / step)];
            bool[,] pixelsRect = new bool[(width / step), (height / step)];
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);

            for (int i = 0; i < figure.GetLength(0); i++)
                Clip(figure[i, 0], figure[i, 1], figure[i, 2], figure[i, 3], pixelsFigure);

            Figure_Brezenham(pixelsRect, rectangle);

            DrawGrid(width, height, pixelsFigure, pixelsRect, graphics);
            pictureBox1.Image = bitmap;
        }

        int DefineCode(double xn, double yn) 
        {
            int code = 0;
            
            if (xn < rectangle[minRecX_i, minRecX_j]) 
                ++code;
            else if (xn > rectangle[maxRecX_i, maxRecX_j]) 
                code += 2;

            if (yn < rectangle[minRecY_i, minRecY_j]) 
                code += 4;
            else if (yn > rectangle[maxRecY_i, maxRecY_j]) 
                code += 8;
            return code;
        }

        private bool Clip(double x0, double y0, double x1, double y1, bool[,] pixelsFigure)
        {
            int codeBegin = DefineCode(x0, y0);
            int codeEnd = DefineCode(x1, y1);

            double dx = x1 - x0, dy = y1 - y0;
            double dxdy = 0, dydx = 0;
            if (dx != 0)
                dydx = dy / dx;
            if (dy != 0)
                dxdy = dx / dy;

            for (int j = 0; j < 5; j++)
            {
                if (codeBegin == 0 && codeEnd == 0)
                {
                    Brezenham((int)x0, (int)y0, (int)x1, (int)y1, pixelsFigure);
                    return true;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (((codeBegin >> i) & 1) == 1 && ((codeEnd >> i) & 1) == 1)
                        return false;
                }

                if (codeBegin != 0)
                {
                    double[] tempPoints = MovePoint(codeBegin, y0, x0, dxdy, dydx);
                    x0 = tempPoints[0]; y0 = tempPoints[1];
                    codeBegin = DefineCode(x0, y0);
                }
                else if(codeEnd != 0)
                {
                    double[] tempPoints = MovePoint(codeEnd, y1, x1, dxdy, dydx);
                    x1 = tempPoints[0]; y1 = tempPoints[1];
                    codeEnd = DefineCode(x1, y1);
                }
            }
            
            return false;
        }

        private double[] MovePoint(int code, double y, double x, double dxdy, double dydx)
        {
            if ((code & 1) == 1)
            {
                y += dydx * (rectangle[minRecX_i, minRecX_j] - x);    //(delta y / delta x) * delta x
                x = rectangle[minRecX_i, minRecX_j];
            }
            else if ((code & 2) == 2)
            {
                y += dydx * (rectangle[maxRecX_i, maxRecX_j] - x);
                x = rectangle[maxRecX_i, maxRecX_j];
            }
            else if ((code & 4) == 4)
            {
                x += dxdy * (rectangle[minRecY_i, minRecY_j] - y);
                y = rectangle[minRecY_i, minRecY_j];
            }
            else if ((code & 8) == 8)
            {
                x += dxdy * (rectangle[maxRecY_i, maxRecY_j] - y);
                y = rectangle[maxRecY_i, maxRecY_j];
            }

            return new double[2] { x, y };
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

        public void DrawGrid(int width, int height, bool[,] pixels, bool[,] pixels2, Graphics graphics)
        {
            for (int y = 0; y < height / step; y++)
            {
                for (int x = 0; x < width / step; x++)
                {
                    graphics.DrawRectangle(Pens.Black, x * step, height - 1 - y * step - step, step, step);
                    if (pixels[x, y])
                        graphics.FillRectangle(Brushes.Green, x * step + 2, height - 1 - y * step - step + 2, step - 3, step - 3);
                    if (pixels2[x, y])
                        graphics.FillRectangle(Brushes.Red, x * step + 2, height - 1 - y * step - step + 2, step - 3, step - 3);
                }
            }
        }

        public void Figure_Brezenham(bool[,] pixels, double[,] coords)
        {
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                Brezenham((int)coords[i, 0], (int)coords[i, 1], (int)coords[i, 2], (int)coords[i, 3], pixels);
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            bool[,] pixelsFigure = new bool[(width / step), (height / step)];
            bool[,] pixelsRect = new bool[(width / step), (height / step)];
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);

            Figure_Brezenham(pixelsRect, rectangle);
            //Figure_Brezenham(pixelsFigure, figure);

            DrawGrid(width, height, pixelsFigure, pixelsRect, graphics);
            pictureBox1.Image = bitmap;
        }
    }
}
