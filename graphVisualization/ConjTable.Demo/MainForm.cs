using DT_CW;
using System;
using System.Windows.Forms;

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
    }
}
