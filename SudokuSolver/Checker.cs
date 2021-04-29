using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Checker
    {
        GameBoard gameBoard;
        int size = 9;

        public Checker(GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        public void checkBoard()
        {
            Cell[,] cells = gameBoard.cells;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(gameBoard.isCorrectBoard(cells, i, j, cells[i, j].Value))
                    {
                        cells[i,j].ForeColor = Color.Green;
                    }
                    else
                    {
                        cells[i, j].ForeColor = Color.Red;
                    }
                }
            }
            
        }
    }
}
