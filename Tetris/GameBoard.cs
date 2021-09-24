using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameBoard
    {
        public Shape currentShape, nextShape;
        public Cell[,] board;
        public int width, height;
        private List<int> filledRows;
        public int notMovedCount, scores;

        Random rand;
        List<List<bool[,]>> figures;
        List<Color> possibleColors;

        public GameBoard(Random rand, List<List<bool[,]>> figures, List<Color> possibleColors)
        {
            width = 10;
            height = 20;
            notMovedCount = 0;
            scores = 0;

            board = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    board[x, y] = new Cell();
                }
            }

            this.rand = rand;
            this.figures = figures;
            this.possibleColors = possibleColors;

            currentShape = new Shape(rand, figures, possibleColors);
            nextShape = new Shape(rand, figures, possibleColors);
        }

        public void createNewShape()
        {
            currentShape = new Shape(nextShape);
            nextShape = new Shape(rand, figures, possibleColors);
        }

        public void placeShape()
        {
            for (int y = 0; y < currentShape.figureData.GetLength(0); y++)
            {
                for (int x = 0; x < currentShape.figureData.GetLength(1); x++)
                {
                    if (!board[x + currentShape.x, y + currentShape.y].isFigure)
                    {
                        board[x + currentShape.x, y + currentShape.y].isFigure = currentShape.figureData[y, x];
                        board[x + currentShape.x, y + currentShape.y].figureColor = currentShape.color;
                    }
                }
            }

            createNewShape();
        }

        public void RotateShape()
        {
            currentShape.Rotate(figures[currentShape.figureNumber]);

            if(!IsMovePossible(0, 0))
            {
                currentShape.RotateBack(figures[currentShape.figureNumber]);
            }
        }

        public void Move(int deltaX, int deltaY)
        {
            if(IsMovePossible(deltaX, deltaY))
            {
                currentShape.x += deltaX;
                currentShape.y += deltaY;
                notMovedCount = 0;
            } else
            {
                notMovedCount++;
            }
        }

        public bool IsMovePossible(int deltaX, int deltaY)
        {
            int newX = currentShape.x + deltaX;
            int newY = currentShape.y + deltaY;

            if(newX + currentShape.figureData.GetLength(1) > width || newY + currentShape.figureData.GetLength(0) > height || newX < 0)
            {
                return false;
            }

            for (int y = 0; y < currentShape.figureData.GetLength(0); y++)
            {
                for (int x = 0; x < currentShape.figureData.GetLength(1); x++)
                {
                    if(currentShape.figureData[y, x] && board[newX + x, newY + y].isFigure)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsRowFilled(int row)
        {
            for (int x = 0; x < width; x++)
            {
                if(!board[x, row].isFigure)
                {
                    return false;
                }
            }

            return true;
        }

        public void SearchFilledRows()
        {
            filledRows = new List<int>();

            for (int y = height - 1; y >= 0; y--)
            {
                if (IsRowFilled(y))
                {
                    filledRows.Add(y);
                }
            }
        }

        public void ClearFilledRows()
        {
            if (filledRows.Count == 0)
                return;

            Cell[,] newBoard = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newBoard[x, y] = new Cell();
                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = height - 1; y > filledRows[0]; y--)
                {
                    newBoard[x, y].isFigure = board[x, y].isFigure;
                    newBoard[x, y].figureColor = board[x, y].figureColor;
                }

                for (int i = 1; i < filledRows.Count; i++)
                {
                    for (int y = filledRows[i - 1] - 1; y > filledRows[i]; y--)
                    {
                        newBoard[x, y + i].isFigure = board[x, y].isFigure;
                        newBoard[x, y + i].figureColor = board[x, y].figureColor;
                    }
                }

                for (int y = filledRows[filledRows.Count - 1] - 1; y >= 0; y--)
                {
                    newBoard[x, y + filledRows.Count].isFigure = board[x, y].isFigure;
                    newBoard[x, y + filledRows.Count].figureColor = board[x, y].figureColor;
                }
            }

            scores += 100 * filledRows.Count;
            board = newBoard;
            filledRows.Clear();
        }

        public bool IsLost()
        {
            if(board[currentShape.x, currentShape.y + currentShape.figureData.GetLength(0) - 1].isFigure || 
                board[currentShape.x + currentShape.figureData.GetLength(1) - 1, currentShape.y].isFigure)
            {
                return true;
            }

            return false;
        }
    }
}
