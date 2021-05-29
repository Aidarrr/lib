using DT_CW;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ConjTable.Demo
{
    public partial class MainForm : Form
    {
        CoefficientContainer container;

        public MainForm()
        {
            InitializeComponent();

            container = new CoefficientContainer();
            container.calculateCoefficients();
            container.fillListOfCoefficients();
        }

        int[,] _matrix = new int[,]
            {
                {0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            conjTable1.Build(_matrix);
            conjPanel1.Build(_matrix, container.getCoefficients());
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix, container.getCoefficients());
        }

        private void conjTable1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            conjPanel1.Build(conjTable1.Matrix, container.getCoefficients());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьСхемуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int width = conjPanel1.Size.Width;
            int height = conjPanel1.Size.Height;

            Bitmap bm = new Bitmap(width, height);
            conjPanel1.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
            bm.Save(@"TestDrawToBitmap.bmp", ImageFormat.Bmp);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void показатьГрафикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlots formPlots = new FormPlots(container);
            formPlots.Show();
        }
    }
}
