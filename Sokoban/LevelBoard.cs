using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public class LevelBoard
    {
        public Button[,] cells;
        int buttonInRow = 5;
        int buttonSize = 60;
        int sx = 100, sy = 100, offset = 30;

        public int getButtonInRowCount()
        {
            return buttonInRow;
        }

        public LevelBoard(int levelsCount)
        {
            if(levelsCount % buttonInRow != 0)
                cells = new Button[levelsCount / buttonInRow + 1, buttonInRow];
            else
                cells = new Button[levelsCount / buttonInRow, buttonInRow];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < buttonInRow; j++)
                {
                    if ((i * buttonInRow + j) == levelsCount)
                        break;
                    cells[i, j] = new Button();

                    cells[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 20);
                    cells[i, j].Size = new Size(buttonSize, buttonSize);
                    cells[i, j].ForeColor = SystemColors.ControlDarkDark;
                    cells[i, j].BackColor = SystemColors.Control;
                    cells[i, j].FlatStyle = FlatStyle.Flat;
                    cells[i, j].FlatAppearance.BorderColor = Color.Black;
                    cells[i, j].Location = new Point(j * buttonSize + sx + j * offset, i * buttonSize + sy + i * offset);
                    cells[i, j].Text = (i * buttonInRow + j + 1).ToString();
                    
                }
            }
        }
    }
}
