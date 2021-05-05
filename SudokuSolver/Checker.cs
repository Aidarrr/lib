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
        int boxSize = 3;

        public Checker(GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        private bool UsedInRow(Cell[,] grid, int row, int checkedColumn, int possibleCellValue)
        {
            for (int col = 0; col < size; col++)
                if (grid[row, col].Value == possibleCellValue && col != checkedColumn)
                    return true;

            return false;
        }


        private bool UsedInCol(Cell[,] grid, int col, int checkedRow, int possibleCellValue)
        {
            for (int row = 0; row < size; row++)
                if (grid[row, col].Value == possibleCellValue && row != checkedRow)
                    return true;

            return false;
        }


        private bool UsedInBox(Cell[,] grid, int boxStartRow, int boxStartCol, int possibleCellValue, int checkedRow, int checkedColumn)
        {
            for (int row = 0; row < boxSize; row++)
                for (int col = 0; col < boxSize; col++)
                    if (grid[row + boxStartRow, col + boxStartCol].Value == possibleCellValue && ((row + boxStartRow) != checkedRow || (col + boxStartCol) != checkedColumn))
                        return true;

            return false;
        }

        public bool isCorrectFilledBoard(Cell[,] grid, int row, int col)
        {
            return !UsedInRow(grid, row, col, grid[row, col].Value)
                   && !UsedInCol(grid, col, row, grid[row, col].Value)
                   && !UsedInBox(grid, row - row % 3, col - col % 3, grid[row, col].Value, row, col);
        }

        public void checkBoard()
        {
            Cell[,] cells = gameBoard.cells;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(isCorrectFilledBoard(cells, i, j))
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
