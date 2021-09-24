using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form1 : Form
    {
        List<List<bool[,]>> figures;
        List<Color> colors;
        Random rand;

        Bitmap bitmap, nextFigBitmap;
        Graphics graphics, graphicsNextFig;
        int cellSize;
        int tickCountForPlacingShape;

        GameBoard gameBoard;

        public Form1()
        {
            InitializeComponent();


            figures = new List<List<bool[,]>>()
            {
                new List<bool[,]>()
                {
                    new bool[,] { {true, false},
                                  {true, true}, 
                                  {true, false} },

                    new bool[,] { {true, true, true},
                                  {false, true, false}, },

                    new bool[,] { {false, true},
                                  {true, true},
                                  {false, true} },

                    new bool[,] { {false, true, false},
                                  {true, true, true}, },
                },

                new List<bool[,]>()
                {
                    new bool[,] { {false, true},
                                  {false, true},
                                  {true, true} },

                    new bool[,] { {true, false, false},
                                  {true, true, true}, },

                    new bool[,] { {true, true},
                                  {true, false},
                                  {true, false} },

                    new bool[,] { {true, true, true},
                                  {false, false, true}, },
                },

                new List<bool[,]>()
                {
                    new bool[,] { {false, true},
                                  {false, true},
                                  {true, true} },

                    new bool[,] { {true, false, false},
                                  {true, true, true}, },

                    new bool[,] { {true, true},
                                  {true, false},
                                  {true, false} },

                    new bool[,] { {true, true, true},
                                  {false, false, true}, },
                },

                new List<bool[,]>()
                {
                    new bool[,] { {false, true},
                                   {true, true},
                                   {true, false} },

                    new bool[,] { {true, true, false},
                                  {false, true, true}, },
                },

                new List<bool[,]>()
                {
                    new bool[,] { {false, true},
                                  {false, true},
                                  {true, true} },

                    new bool[,] { {true, false, false},
                                  {true, true, true}, },

                    new bool[,] { {true, true},
                                  {true, false},
                                  {true, false} },

                    new bool[,] { {true, true, true},
                                  {false, false, true}, },
                },

                new List<bool[,]>()
                {
                    new bool[,] { {true, true, true, true}, },

                    new bool[,] { {true},
                                  {true},
                                  {true},
                                  {true}},
                },

                new List<bool[,]>()
                {
                    new bool[,] { {true, true},
                                  {true, true}, }
                }
            };

            colors = new List<Color>()
            {
                Color.Blue, Color.Red, Color.Purple,
                Color.Yellow, Color.LightBlue, Color.Green,
                Color.Orange, 
            };

            rand = new Random();
            gameBoard = new GameBoard(rand, figures, colors);
            

            tickCountForPlacingShape = 4;
            cellSize = (Screen.PrimaryScreen.Bounds.Height - 100) / gameBoard.height;
            pbGameBoard.Width = gameBoard.width * cellSize + 3;
            pbGameBoard.Height = gameBoard.height * cellSize + 3;

            bitmap = new Bitmap(pbGameBoard.Width, pbGameBoard.Height);
            graphics = Graphics.FromImage(bitmap);
            nextFigBitmap = new Bitmap(pbNextFigure.Width, pbNextFigure.Height);
            graphicsNextFig = Graphics.FromImage(nextFigBitmap);
            DrawNextShape();

            
        }

        public void DrawShape()
        {
            Shape currentShape = gameBoard.currentShape;
            int sx = currentShape.x;
            int sy = currentShape.y;
            int resizedCell = cellSize - 5;

            for (int x = 0; x < currentShape.figureData.GetLength(1); x++)
            {
                for (int y = 0; y < currentShape.figureData.GetLength(0); y++)
                {
                    if (currentShape.figureData[y, x])
                    {
                        graphics.FillRectangle(new SolidBrush(currentShape.color), (x + sx)  * cellSize, (y + sy) * cellSize, cellSize, cellSize);
                    }
                }
            }
        }

        public void DrawNextShape()
        {
            Shape nextShape = gameBoard.nextShape;
            int sx = 1;
            int sy = 1;
            graphicsNextFig.Clear(Color.Transparent);
            

            for (int x = 0; x < nextShape.figureData.GetLength(1); x++)
            {
                for (int y = 0; y < nextShape.figureData.GetLength(0); y++)
                {
                    if (nextShape.figureData[y, x])
                    {
                        graphicsNextFig.FillRectangle(new SolidBrush(nextShape.color), (x + sx) * cellSize, (y + sy) * cellSize, cellSize, cellSize);
                    }
                }
            }

            pbNextFigure.Image = nextFigBitmap;
        }

        public void DrawBoard()
        {
            graphics.Clear(Color.White);
            pbGameBoard.Location = new Point((Form1.ActiveForm.Width / 2) - (pbGameBoard.Width / 2), pbGameBoard.Location.Y);
            pbNextFigure.Location = new Point(pbGameBoard.Location.X + pbGameBoard.Width + 10, pbGameBoard.Location.Y);
            lblScores.Location = new Point(pbNextFigure.Location.X + cellSize, pbNextFigure.Location.Y + pbNextFigure.Height + 10);

            for (int x = 0; x < gameBoard.width; x++)
            {
                for (int y = 0; y < gameBoard.height; y++)
                {
                    if(!gameBoard.board[x, y].isFigure)
                    {
                        graphics.DrawRectangle(new Pen(Color.Black), x * cellSize, y * cellSize, cellSize, cellSize);
                    } else
                    {
                        graphics.FillRectangle(new SolidBrush(gameBoard.board[x, y].figureColor), x * cellSize, y * cellSize, cellSize, cellSize);
                    }
                }
            }

            DrawShape();
            pbGameBoard.Image = bitmap;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gameBoard.Move(0, 1);
            if(gameBoard.notMovedCount >= tickCountForPlacingShape)
            {
                gameBoard.placeShape();
                gameBoard.SearchFilledRows();
                gameBoard.ClearFilledRows();
                DrawNextShape();
                lblScores.Text = "Scores: " + gameBoard.scores; 
                timer.Interval = 1000;
            }


            DrawBoard();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                gameBoard.Move(1, 0);
            }
            else if (e.KeyCode == Keys.Left)
            {
                gameBoard.Move(-1, 0);
            } 
            else if(e.KeyCode == Keys.Down)
            {
                timer.Interval = 100;
            }
            else if (e.KeyCode == Keys.Up)
            {
                timer.Interval = 1000;
            }
            else if(e.KeyCode == Keys.Space)
            {
                gameBoard.RotateShape();
            }
            else if(e.KeyCode == Keys.P)
            {
                timer.Enabled = !timer.Enabled;
            }

            DrawBoard();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
