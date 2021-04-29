using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class GameBoard
    {
        private int size = 9;
        private int boxSize = 3;
        public Cell[,] cells;

        public GameBoard()
        {
            cells = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    cells[i, j] = new Cell(i, j);
                }
            }
        }

        public void loadSudokuFromFile(String fileName)
        {
            string[] fileLines = File.ReadAllLines(fileName);

            for (int i = 0; i < fileLines.Length; i++)
            {
                for (int j = 0; j < fileLines[i].Length; j++)
                {
                    if(fileLines[i][j] == '-')
                    {
                        cells[i, j].Value = Cell.unassigned;
                        cells[i, j].Text = String.Empty;
                    }
                    else
                    {
                        cells[i, j].Text = fileLines[i][j].ToString();
                        cells[i, j].Value = Int32.Parse(cells[i, j].Text);
                    }
                }
            }
        }

        private bool FindUnassignedLocation(Cell[,] grid, ref int row, ref int col)
        {
            for (row = 0; row < size; row++)
                for (col = 0; col < size; col++)
                    if (grid[row, col].Value == Cell.unassigned)
                        return true;

            return false;
        }

        private bool UsedInRow(Cell[,] grid, int row, int possibleCellValue)
        {
            for (int col = 0; col < size; col++)
                if (grid[row, col].Value == possibleCellValue)
                    return true;

            return false;
        }


        private bool UsedInCol(Cell[,] grid, int col, int possibleCellValue)
        {
            for (int row = 0; row < size; row++)
                if (grid[row, col].Value == possibleCellValue)
                    return true;

            return false;
        }


        private bool UsedInBox(Cell[,] grid, int boxStartRow, int boxStartCol, int possibleCellValue)
        {
            for (int row = 0; row < boxSize; row++)
                for (int col = 0; col < boxSize; col++)
                    if (grid[row + boxStartRow, col + boxStartCol].Value == possibleCellValue)
                        return true;

            return false;
        }

        public bool isCorrectBoard(Cell[,] grid, int row, int col, int possibleCellValue)
        {
            return !UsedInRow(grid, row, possibleCellValue)
                   && !UsedInCol(grid, col, possibleCellValue)
                   && !UsedInBox(grid, row - row % 3, col - col % 3, possibleCellValue)
                   && grid[row, col].Value == Cell.unassigned;
        }

        public bool solveSudoku()
        {
            int row = 0, col = 0;

            if (!FindUnassignedLocation(cells, ref row, ref col))
                return true;

            for (int possibleCellValue = 1; possibleCellValue <= 9; possibleCellValue++)
            {
                if (isCorrectBoard(cells, row, col, possibleCellValue))
                {
                    cells[row, col].Value = possibleCellValue;
                    cells[row, col].Text = possibleCellValue.ToString();

                    if (solveSudoku())
                        return true;

                    cells[row, col].Value = Cell.unassigned;
                    cells[row, col].Text = String.Empty;
                }
            }

            return false;
        }
    }
}
