using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static int height = 800;
        public static int width = 800;
        public static int thick = 10;
        public static int count_pix = 0;
        public int drawedpixels = 0;
        public List<Color> pixels = new List<Color>();
        Graphics Graph;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            count_pix = pictureBox1.Width / (thick);
            this.Size = new System.Drawing.Size(pictureBox1.Width + 50, pictureBox1.Height + 50);

        }
        public void DrawGrid()
        {
            for (int i = 0; i <= count_pix; i++)
            {
                Pen pen = new Pen(Color.Gray, 1);
                Graph.DrawLine(pen, new Point(0, i * thick), new Point(pictureBox1.Width, i * thick));
                Graph.DrawLine(pen, new Point(i * thick, 0), new Point(i * thick, pictureBox1.Height));
            }

        }
        public void PutPixel(int x, int y, Color color)
        {
            for (int i = 0; i < pixels.Count; i++)
            {
                if (i % count_pix == x && i / count_pix == y)
                {
                    pixels[i] = color;
                }
            }
        }
        public void DrawPixels()
        {
            for (int i = 0; i < pixels.Count; i++)
            {
                if (pixels[i] != Color.White)
                {
                    Graph.FillRectangle(new SolidBrush(pixels[i]), i % count_pix * thick, i / count_pix * thick, thick, thick);
                }
            }
        }
        public void ClearList()
        {
            for (int i = 0; i < count_pix * count_pix; i++)
            {
                pixels[i] = Color.White;
            }
        }
        public void FillList()
        {
            for (int i = 0; i < count_pix * count_pix; i++)
            {
                pixels.Add(Color.White);
            }
        }

        public void DrawLineBrezenham(int x1, int y1, int x2, int y2, Color color)
        {
            x1 /= thick;
            y1 /= thick;
            x2 /= thick;
            y2 /= thick;
            int dx = (x2 > x1) ? (x2 - x1) : (x1 - x2);
            int dy = (y2 > y1) ? (y2 - y1) : (y1 - y2);
            int sx = (x2 >= x1) ? (1) : (-1);
            int sy = (y2 >= y1) ? (1) : (-1);

            if (dy < dx)
            {
                int d = 2 * dy - dx;
                int d1 = dy * 2;
                int d2 = 2 * (dy - dx);
                PutPixel(x1, y1, color);
                int x = x1 + sx;
                int y = y1;
                for (int i = 0; i < dx; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        y += sy;
                    }
                    else
                    {
                        d += d1;
                    }
                    PutPixel(x, y, color);
                    x += sx;
                }
            }
            else
            {
                int d = 2 * dx - dy;
                int d1 = dx * 2;
                int d2 = 2 * (dx - dy);
                PutPixel(x1, y1, color);
                int x = x1;
                int y = y1 + sy;
                for (int i = 0; i < dy; i++)
                {
                    if (d > 0)
                    {
                        d += d2;
                        x += sx;
                    }
                    else
                    {
                        d += d1;
                    }
                    PutPixel(x, y, color);
                    y += sy;
                }
            }
        }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public struct Pixel
        {
            public int X { get; }
            public int Y { get; }
            public UInt32 color { get; }

            public Pixel(int x, int y, UInt32 color)
            {
                this.X = x;
                this.Y = y;
                this.color = color;
            }
        }
        void Triangle(Pixel t0, Pixel t1, Pixel t2)
        {

            if (t0.Y > t1.Y) Swap(ref t0, ref t1);
            if (t0.Y > t2.Y) Swap(ref t0, ref t2);
            if (t1.Y > t2.Y) Swap(ref t1, ref t2);

            Point A = new Point();
            Point B = new Point();

            int total_height = t2.Y - t0.Y;
            if (t1.Y - t0.Y != 0)
            {
                if (t1.X > t2.X || t0.X < t2.X && t1.X == t2.X)
                {
                    for (int y = t0.Y + 1; y <= t1.Y; y++)
                    {
                        A.Y = y;
                        B.Y = y;
                        int segment_height = t1.Y - t0.Y;
                        float alpha = (float)(y - t0.Y) / total_height;
                        float beta = (float)(y - t0.Y) / segment_height;
                        A.X = (int)(t0.X + (t2.X - t0.X) * alpha);
                        B.X = (int)(t0.X + (t1.X - t0.X) * beta);
                        if (A.X > B.X) Swap(ref A, ref B);
                        UInt32 color_left = Lerp(t0.color, t2.color, y, t0.Y, t2.Y);
                        UInt32 color_right = Lerp(t0.color, t1.color, y, t0.Y, t1.Y);
                        for (int j = A.X; j <= B.X; j++)
                        {
                            UInt32 col = Lerp(color_right, color_left, j, B.X, A.X);
                            PutPixel(j, y, Color.FromArgb((int)col));
                        }
                    }
                }
                else
                {
                    for (int y = t0.Y + 1; y <= t1.Y; y++)
                    {
                        A.Y = y;
                        B.Y = y;
                        int segment_height = t1.Y - t0.Y;
                        float alpha = (float)(y - t0.Y) / segment_height;
                        float beta = (float)(y - t0.Y) / total_height;
                        A.X = (int)(t0.X + (t1.X - t0.X) * alpha);
                        B.X = (int)(t0.X + (t2.X - t0.X) * beta);
                        if (A.X > B.X) Swap(ref A, ref B);
                        UInt32 color_left = Lerp(t0.color, t1.color, y, t0.Y, t1.Y);
                        UInt32 color_right = Lerp(t0.color, t2.color, y, t0.Y, t2.Y);
                        for (int j = A.X; j <= B.X; j++)
                        {
                            UInt32 col = Lerp(color_right, color_left, j, B.X, A.X);
                            PutPixel(j, y, Color.FromArgb((int)col));
                        }
                    }
                }
            }
            if (t2.Y - t1.Y != 0)
            {
                if (t1.X > t2.X || t0.X < t2.X && t1.X == t2.X)
                {
                    for (int y = t1.Y + 1; y <= t2.Y; y++)
                    {
                        A.Y = y;
                        B.Y = y;
                        int segment_height = t2.Y - t1.Y;
                        float alpha = (float)(y - t0.Y) / total_height;
                        float beta = (float)(y - t1.Y) / segment_height;
                        A.X = (int)(t0.X + (t2.X - t0.X) * alpha);
                        B.X = (int)(t1.X + (t2.X - t1.X) * beta);
                        if (A.X > B.X) Swap(ref A, ref B);
                        UInt32 color_left = Lerp(t0.color, t2.color, y, t0.Y, t2.Y);
                        UInt32 color_right = Lerp(t1.color, t2.color, y, t1.Y, t2.Y);
                        for (int j = A.X; j <= B.X; j++)
                        {
                            UInt32 col = Lerp(color_right, color_left, j, B.X, A.X);
                            PutPixel(j, y, Color.FromArgb((int)col));
                        }
                    }
                }
                else
                {
                    for (int y = t1.Y + 1; y <= t2.Y; y++)
                    {
                        A.Y = y;
                        B.Y = y;
                        int segment_height = t2.Y - t1.Y;
                        float alpha = (float)(y - t1.Y) / segment_height;
                        float beta = (float)(y - t0.Y) / total_height;
                        A.X = (int)(t1.X + (t2.X - t1.X) * alpha);
                        B.X = (int)(t0.X + (t2.X - t0.X) * beta);
                        if (A.X > B.X) Swap(ref A, ref B);
                        UInt32 color_left = Lerp(t1.color, t2.color, y, t1.Y, t2.Y);
                        UInt32 color_right = Lerp(t0.color, t2.color, y, t0.Y, t2.Y);
                        for (int j = A.X; j <= B.X; j++)
                        {
                            UInt32 col = Lerp(color_right, color_left, j, B.X, A.X);
                            PutPixel(j, y, Color.FromArgb((int)col));
                        }
                    }
                }
            }
        }
        private UInt32 Lerp(UInt32 xl, UInt32 xr, int x, int a, int b)
        {
            UInt32 pixelValue;
            double d = (double)(x - b) / (double)(a - b);
            double d2 = (double)(a - x) / (double)(a - b);
            pixelValue = 0xFFFFFFFF;
            pixelValue = (UInt32)0xFF000000 |
                ((UInt32)(d * ((xl & 0x00FF0000) >> 16) + d2 * ((xr & 0x00FF0000) >> 16)) << 16) |
                ((UInt32)(d * ((xl & 0x0000FF00) >> 8) + d2 * ((xr & 0x0000FF00) >> 8)) << 8) |
                (UInt32)(d * (xl & 0x000000FF) + d2 * (xr & 0x000000FF));
            return pixelValue;
        }
        public void DrawFigure1(int x, int y, int size, Color color)
        {
            Point p1 = new Point(x, y);
            Point p2 = new Point(x + size * thick, y);
            Point p3 = new Point(x + size * thick, y + size / 2 * thick);
            Point p4 = new Point(x, y + size / 2 * thick);
            Point p5 = new Point(x + size * thick / 2, y + size * thick / 4);
            BariTriangle(p5.X, p5.Y, p1.X, p1.Y, p2.X, p2.Y, Color.Red.ToArgb());
            BariTriangle(p5.X, p5.Y, p2.X, p2.Y, p3.X, p3.Y, Color.Green.ToArgb());
            BariTriangle(p5.X, p5.Y, p3.X, p3.Y, p4.X, p4.Y, Color.Blue.ToArgb());
            BariTriangle(p5.X, p5.Y, p4.X, p4.Y, p1.X, p1.Y, Color.Brown.ToArgb());
            DrawLineBrezenham(p1.X, p1.Y, p2.X, p2.Y, color);
            DrawLineBrezenham(p2.X, p2.Y, p3.X, p3.Y, color);
            DrawLineBrezenham(p3.X, p3.Y, p4.X, p4.Y, color);
            DrawLineBrezenham(p4.X, p4.Y, p1.X, p1.Y, color);
            DrawLineBrezenham(p1.X, p1.Y, p3.X, p3.Y, color);
            DrawLineBrezenham(p2.X, p2.Y, p4.X, p4.Y, color);

        }
        public void DrawFigure2(int x, int y, int size, Color color)
        {
            Point p1 = new Point(x, y);
            Point p2 = new Point(x + size * thick, y);
            Point p3 = new Point(x + size * thick, y + size / 2 * thick);
            Point p4 = new Point(x, y + size / 2 * thick);
            Point p5 = new Point(x + size * thick / 2, y + size * thick / 4);
            Triangle(new Pixel(p1.X / thick, p1.Y / thick, 1000000), new Pixel(p2.X / thick, p2.Y / thick, 2000000), new Pixel(p5.X / thick, p5.Y / thick, 3000000));
            Triangle(new Pixel(p2.X / thick, p2.Y / thick, 4000000), new Pixel(p3.X / thick, p3.Y / thick, 5000000), new Pixel(p5.X / thick, p5.Y / thick, 6000000));
            Triangle(new Pixel(p3.X / thick, p3.Y / thick, 7000000), new Pixel(p4.X / thick, p4.Y / thick, 8000000), new Pixel(p5.X / thick, p5.Y / thick, 9000000));
            Triangle(new Pixel(p1.X / thick, p1.Y / thick, 10000000), new Pixel(p4.X / thick, p4.Y / thick, 11000000), new Pixel(p5.X / thick, p5.Y / thick, 12000000));
            DrawLineBrezenham(p1.X, p1.Y, p2.X, p2.Y, color);
            DrawLineBrezenham(p2.X, p2.Y, p3.X, p3.Y, color);
            DrawLineBrezenham(p3.X, p3.Y, p4.X, p4.Y, color);
            DrawLineBrezenham(p4.X, p4.Y, p1.X, p1.Y, color);
            DrawLineBrezenham(p1.X, p1.Y, p3.X, p3.Y, color);
            DrawLineBrezenham(p2.X, p2.Y, p4.X, p4.Y, color);

        }
        public UInt32 getColor(int x1, int y1, int x2, int y2, int x3, int y3, int x, int y, int color)
        {
            UInt32 pixelValue = 0xFFFFFFFF;
            double l1, l2, l3;
            l1 = ((y2 - y3) * ((double)(x) - x3) + (x3 - x2) * ((double)(y) - y3)) /
                ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            l2 = ((y3 - y1) * ((double)(x) - x3) + (x1 - x3) * ((double)(y) - y3)) /
                ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
            l3 = 1 - l1 - l2;
            if (l1 >= 0 && l1 <= 1 && l2 >= 0 && l2 <= 1 && l3 >= 0 && l3 <= 1)
            {
                pixelValue = (UInt32)0xFF000000 |
                    ((UInt32)(l1 * (((UInt32)color & 0x00FF0000) >> 16) + l2 * (((UInt32)(color) & 0x00FF0000) >> 16) + l3 * (((UInt32)(color) & 0x00FF0000) >> 16)) << 16) |
                    ((UInt32)(l1 * (((UInt32)(color) & 0x0000FF00) >> 8) + l2 * (((UInt32)(color) & 0x0000FF00) >> 8) + l3 * (((UInt32)(color) & 0x0000FF00) >> 8)) << 8) |
                    (UInt32)(l1 * ((UInt32)(color) & 0x000000FF) + l2 * ((UInt32)(color) & 0x000000FF) + l3 * ((UInt32)(color) & 0x000000FF));
            }
            return pixelValue;
        }
        public void BariTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int color)
        {
            x1 /= thick;
            y1 /= thick;
            x2 /= thick;
            y2 /= thick;
            x3 /= thick;
            y3 /= thick;
            for (int x = 0; x < pictureBox1.Width / thick; x++)
            {
                for (int y = 0; y < pictureBox1.Height / thick; y++)
                {
                    if (Color.FromArgb((int)getColor(x1, y1, x2, y2, x3, y3, x, y, color)) != Color.FromArgb(unchecked((int)(0xFFFFFFFF))))
                        PutPixel(x, y, Color.FromArgb((int)getColor(x1, y1, x2, y2, x3, y3, x, y, color)));
                }
            }
        }
        public UInt32[,] Inter(UInt32[,] old, int oldw, int oldh, int neww, int newh)
        {
            UInt32[,] newcolors = new UInt32[newh, neww];
            int i, j;
            int h, w;
            float t;
            float u;
            float tmp;
            float d1, d2, d3, d4;
            UInt32 p1, p2, p3, p4;
            UInt32 red, green, blue;
            for (j = 0; j < newh; j++)
            {
                tmp = (float)(j) / (float)(newh - 1) * (oldh - 1);
                h = (int)Math.Round(tmp, MidpointRounding.ToEven);
                if (h < 0)
                {
                    h = 0;
                }
                else
                {
                    if (h >= oldh - 1)
                    {
                        h = oldh - 2;
                    }
                }
                u = tmp - h;
                for (i = 0; i < neww; i++)
                {

                    tmp = (float)(i) / (float)(neww - 1) * (oldw - 1);
                    w = (int)Math.Round(tmp, MidpointRounding.ToEven);
                    if (w < 0)
                    {
                        w = 0;
                    }
                    else
                    {
                        if (w >= oldw - 1)
                        {
                            w = oldw - 2;
                        }
                    }
                    t = tmp - w;
                    d1 = (1 - t) * (1 - u);
                    d2 = t * (1 - u);
                    d3 = t * u;
                    d4 = (1 - t) * u;
                    p1 = old[h, w];
                    p2 = old[h, w + 1];
                    p3 = old[h + 1, w + 1];
                    p4 = old[h + 1, w];
                    blue = (UInt32)((p1 & 0x000000FF) * d1 + (p2 & 0x000000FF) * d2 + (p3 & 0x000000FF) * d3 + (p4 & 0x000000FF) * d4);
                    green = (UInt32)(((p1 & 0x0000FF00) >> 8) * d1 + ((p2 & 0x0000FF00) >> 8) * d2 + ((p3 & 0x0000FF00) >> 8) * d3 + ((p4 & 0x0000FF00) >> 8) * d4);
                    red = (UInt32)(((p1 & 0x00FF0000) >> 16) * d1 + ((p2 & 0x00FF0000) >> 16) * d2 + ((p3 & 0x00FF0000) >> 16) * d3 + ((p4 & 0x00FF0000) >> 16) * d4);
                    newcolors[j, i] = ((UInt32)0xFF000000 | (red << 16) | (green << 8) | (blue));
                }
            }
            return newcolors;
        }
        public UInt32 ToUint(Color c)
        {
            return (uint)(((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B) & 0xffffffffL);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap buf = new Bitmap(pictureBox1.Height, pictureBox1.Width);
            Graph = Graphics.FromImage(buf);
            Graph.Clear(Color.White);
            FillList();
            DrawFigure1(2 * thick, 2 * thick, 30, Color.Black);
            DrawFigure2(2 * thick + 30 * thick + 15 * thick, 2 * thick, 30, Color.Black);
            DrawPixels();
            DrawGrid();
            Graph.FillRectangle(new SolidBrush(Color.Gray), 0, 20 * thick, pictureBox1.Width, pictureBox1.Height - 20 * thick);
            Bitmap temp = new Bitmap("C:\\Users\\User\\source\\repos\\Computer Graphics 3\\2.png");
            const int ih = 400;
            const int iw = 400;
            UInt32[,] colors1 = new UInt32[temp.Width, temp.Height];
            UInt32[,] colors2 = new UInt32[iw, ih];
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    colors1[i, j] = ToUint(temp.GetPixel(i, j));
                }
            }
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    Graph.FillRectangle(new SolidBrush(Color.FromArgb((int)colors1[i, j])), i, j + 20 * thick, 1, 1);
                }
            }
            colors2 = Inter(colors1, temp.Width, temp.Height, iw, ih);
            for (int i = 0; i < iw; i++)
            {
                for (int j = 0; j < ih; j++)
                {
                    Graph.FillRectangle(new SolidBrush(Color.FromArgb((int)colors2[i, j])), i + pictureBox1.Width / 3, j + 20 * thick, 1, 1);
                }
            }
            pictureBox1.Image = buf;
            ClearList();
        }
    }
}
