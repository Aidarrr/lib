using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Cell : Button
    {
        public static int unassigned = 0;
        public int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Cell(int X, int Y)
        {
            Value = unassigned;
            this.X = X;
            this.Y = Y;
            this.Text = String.Empty;
        }

        public void Clear()
        {
            this.Text = string.Empty;
        }

        
    }
}
