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
    public partial class FormForCompletedLevel : Form
    {
        Form1 mainForm;
        Menu menu;
        FileReader fileReader;
        int levelCount;

        public FormForCompletedLevel(string lblLevelNum, string lblMovesCount, string lblTime, Form1 mainForm, FileReader fileReader)
        {
            InitializeComponent();

            this.lblLevelNum.Text = lblLevelNum;
            this.lblMovesCount.Text = lblMovesCount;
            this.lblTime.Text = lblTime;

            this.mainForm = mainForm;
            this.menu = new Menu();
            this.fileReader = fileReader;

            levelCount = fileReader.getLevelsCount();
        }

        private void btnChooseLvl_Click(object sender, EventArgs e)
        {
            LevelBoard levelBoard = menu.createLevelBoard(levelCount);
            LevelForm levelForm = new LevelForm(levelBoard, levelCount, mainForm, fileReader);
            levelForm.Show();
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            fileReader.readMap(fileReader.lvlNumber);
            mainForm.setAnotherLevel();
            this.Close();
        }

        private void btnNextLevel_Click(object sender, EventArgs e)
        {
            int nextLvl = fileReader.lvlNumber == levelCount ? 1 : fileReader.lvlNumber + 1;

            fileReader.readMap(nextLvl);
            mainForm.setAnotherLevel();
            this.Close();
        }
    }
}
