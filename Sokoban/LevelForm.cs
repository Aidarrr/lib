using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class LevelForm : Form
    {
        Form1 mainForm;
        FileReader fileReader;

        public LevelForm(LevelBoard levelBoard, int levelsCount, Form1 mainForm, FileReader fileReader)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.fileReader = fileReader;
            var cells = levelBoard.cells;

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if ((i * levelBoard.getButtonInRowCount() + j) == levelsCount)
                        break;

                    cells[i, j].Click += LevelForm_Click;
                    panel1.Controls.Add(cells[i, j]);
                }
            }
        }

        private void LevelForm_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            fileReader.readMap(Convert.ToInt32(clickedButton.Text));
            mainForm.setAnotherLevel();

            this.Close();
        }
    }
}
