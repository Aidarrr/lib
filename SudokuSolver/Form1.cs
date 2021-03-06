using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        GameBoard gameBoard = new GameBoard();
        

        public Form1()
        {
            InitializeComponent();

            createCells();
            emptyCells.Text = gameBoard.getEmptyCells().ToString();
        }

        private void createCells()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    gameBoard.cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    gameBoard.cells[i, j].Size = new Size(40, 40);
                    gameBoard.cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    gameBoard.cells[i, j].Location = new Point(j * 40, i * 40);
                    gameBoard.cells[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    gameBoard.cells[i, j].FlatStyle = FlatStyle.Flat;
                    gameBoard.cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    
                    panelSudokuGrid.Controls.Add(gameBoard.cells[i, j]);
                }
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            gameBoard.solveSudoku();
            backtrackingCount.Text = gameBoard.getBacktrackingCount().ToString();
            iterationsCount.Text = gameBoard.getIterationsCount().ToString();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog
            {
                Title = "Открыть Судоку",
                Filter = "TXT files|*.txt",
                InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory() + "\\..\\Puzzles")
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                gameBoard.loadSudokuFromFile(fileDialog.FileName);
            }

            emptyCells.Text = gameBoard.getEmptyCells().ToString();
            gameBoard.resetCountValues();
            backtrackingCount.Text = gameBoard.getBacktrackingCount().ToString();
            iterationsCount.Text = gameBoard.getIterationsCount().ToString();

            resetCellsColor();
        }

        public void resetCellsColor()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    gameBoard.cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Checker checker = new Checker(gameBoard);
            checker.checkBoard();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
