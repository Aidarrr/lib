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
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        FileReader fileReader;
        Level level;
        Game game;
        ImageContainer imageContainer;
        Menu menu;
        GameInfo gameInfo;

        Color bgColor = Color.White;
        int offset = 30, sx = 100, sy = 100;
        int levelCount = 0;

        public Form1(int levelNum = 1)
        {
            InitializeComponent();
            fileReader = new FileReader();
            fileReader.readMap(levelNum);
            levelCount = fileReader.getLevelsCount();

            level = fileReader.getLevelObject();
            game = new Game(level);
            imageContainer = new ImageContainer();
            menu = new Menu();
            gameInfo = new GameInfo();

            lblLevelNum.Text = gameInfo.getLabelForLevel(fileReader);
            lblMovesCount.Text = gameInfo.getLabelForMovesCount(game);
            gameInfo.updateStopWatch();
            timer.Enabled = true;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
        }

        public void setAnotherLevel()
        {
            level = fileReader.getLevelObject();
            game = new Game(level);

            lblLevelNum.Text = gameInfo.getLabelForLevel(fileReader);
            lblMovesCount.Text = gameInfo.getLabelForMovesCount(game);
            gameInfo.updateStopWatch();
            timer.Enabled = true;

            drawMap();
        }

        public void drawMap()
        {
            char[,] map = level.getMap();
            sx = (bitmap.Width - map.GetLength(0) * offset) / 2;
            sy = (bitmap.Height - map.GetLength(1) * offset) / 2;

            graphics.Clear(bgColor);
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    graphics.DrawImage(imageContainer.getImageByChar(map[x, y], level), sx + x * offset, sy + y * offset);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;

            drawMap();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void chooseLevel_Click(object sender, EventArgs e)
        {
            LevelBoard levelBoard = menu.createLevelBoard(levelCount);
            LevelForm levelForm = new LevelForm(levelBoard, levelCount, this, fileReader);
            levelForm.Show();
        }

        private void ходНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.makeMoveBackward();
            lblMovesCount.Text = gameInfo.getLabelForMovesCount(game);
            drawMap();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = gameInfo.getLabelForTime();
        }

        private void начатьСначалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileReader.readMap(fileReader.lvlNumber);
            setAnotherLevel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                game.move(1, 0);
            }
            else if (e.KeyCode == Keys.Left)
            {
                game.move(-1, 0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                game.move(0, -1);
            }
            else if (e.KeyCode == Keys.Down)
            {
                game.move(0, 1);
            }


            lblMovesCount.Text = gameInfo.getLabelForMovesCount(game);
            drawMap();

            if (game.isWon())
            {
                timer.Enabled = false;
                FormForCompletedLevel completedForm = new FormForCompletedLevel(lblLevelNum.Text, lblMovesCount.Text, lblTime.Text, this, fileReader);
                completedForm.Show();
            }
        }
    }
}
