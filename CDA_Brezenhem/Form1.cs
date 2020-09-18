using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDA_Brezenhem
{
    public partial class Form1 : Form
    {
        static int wPbLine = 911, hPbLine = 281, wCDA = 445, hCDA = 278, wBrez = 459, hBrez = 279;
        int step = 20;

        int[,] figure = new int[20, 4]
        { {9, 2, 6, 3 }, { 9, 2, 12, 3 }, { 9, 2, 9, 5 },  { 7, 7, 9, 5 }, { 9, 5, 11, 7 },
          {4, 6, 6, 3},{ 14, 6, 12, 3}, { 4, 6, 7, 7 }, { 14, 6, 11,7 }, { 7, 7, 8, 9 },
          { 11, 7, 10, 9}, { 4, 6, 4, 9 }, { 14, 6, 14, 9 }, { 4, 9, 6, 11 }, { 12, 11, 14, 9 },
          { 8, 9, 10, 9}, { 6, 11, 8, 9 }, { 12, 11, 10, 9}, { 6, 11, 9, 12 }, {12, 11, 9, 12 } };

        public Form1()
        {
            InitializeComponent();
        }

        public void PutPixel(int x, int y, bool[,] pixels)
        {
            pixels[x,y] = true;
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
            while (--kl >= 0) {
                if (s >= 0) {
                    if (swap) xn += sx; else yn += sy;
                    s -= incr2;
                }
                if (swap) yn += sy; else xn += sx;
                s += incr1;
                PutPixel(xn, yn, pixels); 
            }
        } 

        void DDA(int xn, int yn, int xk, int yk, bool[,] pixels)
        {
            int dx, dy, s;

            dx = xk - xn; dy = yk - yn;
            var absdx = Math.Abs(dx); var absdy = Math.Abs(dy);

            PutPixel(xn, yn, pixels);

            if (dx == 0 && dy == 0) return;

            if (absdy == absdx)
            {                 
                var t = absdx;
                while (t > 0)
                {
                    t--;
                    xn = xn + Math.Sign(dx) * 1;
                    yn += Math.Sign(dy) * 1;
                    PutPixel(xn, yn, pixels);
                }
            }
            else if (absdx > absdy)
            {           
                var t = absdx;
                s = 0;
                while (t > 0)
                {
                    t--;
                    xn = xn + Math.Sign(dx)* 1;
                    s = s + absdy;
                    if (s >= absdx) { s = s - absdx; yn = yn + Math.Sign(dy)*1; }
                    PutPixel(xn, yn, pixels);
                }
            }
            else
            {                        
                var t = absdy;
                s = 0;
                while (t > 0)
                {
                    t--;
                    yn = yn + Math.Sign(dy)*1;
                    s = s + absdx;
                    if (s >= absdy) { s = s - absdy; xn = xn + Math.Sign(dx)*1; }
                    PutPixel(xn, yn, pixels);
                }
            }
        }  

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbLine_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            Bitmap bitmapLine = new Bitmap(wPbLine, hPbLine);
            Graphics graphicsLine = Graphics.FromImage(bitmapLine);
            var rand = new Random();
            int xn, yn, xk, yk;
            bool[,] pixelsLine = new bool[(wPbLine / step), (hPbLine / step)];
            xn = rand.Next(0, wPbLine/step);
            yn = rand.Next(0, hPbLine / step);
            xk = rand.Next(0, wPbLine / step);
            yk = rand.Next(0, hPbLine / step);
            Brezenham(xn, yn, xk, yk, pixelsLine);
            DrawGrid(wPbLine, hPbLine, pixelsLine, graphicsLine);
            graphicsLine.DrawLine(pen, xn * step, hPbLine - 1 - yn * step - step / 2, xk * step, hPbLine - 1 - yk * step - step / 2);
            pbLine.Image = bitmapLine;
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
                Brezenham(figure[i,0], figure[i, 1], figure[i, 2], figure[i, 3], pixels);
            }
        }

        public void Figure_CDA(bool[,] pixels)
        {
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                DDA(figure[i, 0], figure[i, 1], figure[i, 2], figure[i, 3], pixels);
            }
        }

        public void DrawOriginalFigure(Graphics graphics, Pen pen)
        {
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                graphics.DrawLine(pen, figure[i, 0] * step + 10, hBrez - 1 - figure[i,1] * step, figure[i,2] * step +10, hBrez - 1 - figure[i,3] * step);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Red, 3);
            bool[,] pixelsLine = new bool[(wPbLine / step), (hPbLine / step)];
            bool[,] pixelsCDA = new bool[(wCDA / step), (hCDA / step)];
            bool[,] pixelsBrez = new bool[(wBrez / step), (hBrez / step)];
            Bitmap bitmapLine = new Bitmap(wPbLine, hPbLine);
            Graphics graphicsLine = Graphics.FromImage(bitmapLine);
            Bitmap bitmapCDA = new Bitmap(wCDA, hCDA);
            Graphics graphicsCDA = Graphics.FromImage(bitmapCDA);
            Bitmap bitmapBrez = new Bitmap(wBrez, wBrez);
            Graphics graphicsBrez = Graphics.FromImage(bitmapBrez);


            Brezenham(1, 1, 6, 4, pixelsLine);
            Figure_Brezenham(pixelsBrez);
            Figure_CDA(pixelsCDA);

            DrawGrid(wPbLine, hPbLine, pixelsLine, graphicsLine);
            graphicsLine.DrawLine(pen, 1 * step, hPbLine - 1 - 1 * step - step/2, 6 * step, hPbLine - 1 - 4 * step - step/2);
            pbLine.Image = bitmapLine;
            DrawGrid(wBrez, hBrez, pixelsBrez, graphicsBrez);
            DrawOriginalFigure(graphicsBrez, pen); //на pbBrez
            pbBrez.Image = bitmapBrez;
            DrawGrid(wCDA, hCDA, pixelsCDA, graphicsCDA);
            DrawOriginalFigure(graphicsCDA, pen);   //на pbCDA
            pbCDA.Image = bitmapCDA;
        }
    }
}
