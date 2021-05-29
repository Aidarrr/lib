using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DT_CW;

namespace ConjTable.Demo
{
    public partial class FormPlots : Form
    {
        
        public FormPlots(CoefficientContainer container)
        {
            InitializeComponent();
            drawPlots(container);
        }

        public void drawPlots(CoefficientContainer container)
        {
            var dependencyElements = container.getDependencyElements();
            List<DataTable> tablesForPlots = new List<DataTable>();
            List<Tuple<string, double>> coefficients = container.getCoefficients(); //for getting names
            List<Tuple<string, string>> namesOfAxis = new List<Tuple<string, string>>();


            foreach (var element in dependencyElements)
            {
                tablesForPlots.Add(new DataTable());
                tablesForPlots[tablesForPlots.Count - 1].Columns.Add("X_Value", typeof(double));
                tablesForPlots[tablesForPlots.Count - 1].Columns.Add("Y_Value", typeof(double));

                foreach (var row in element.getTableForCoefficientCalculation())
                {
                    tablesForPlots[tablesForPlots.Count - 1].Rows.Add(Math.Round(row.Item1, 2), Math.Round(row.Item2, 2));
                }

                namesOfAxis.Add(element.getNamesOfDependency());
            }

            drawOnCharts(tablesForPlots, coefficients, namesOfAxis);
        }

        public void drawOnCharts(List<DataTable> tablesForPlots, List<Tuple<string, double>> coefficients, List<Tuple<string, string>> namesOfAxis)
        {
            chart0.DataSource = tablesForPlots[0];
            chart0.Series[coefficients[0].Item1].XValueMember = "X_Value";
            chart0.Series[coefficients[0].Item1].YValueMembers = "Y_Value";
            chart0.Series[coefficients[0].Item1].ChartType = SeriesChartType.Line;

            chart1.DataSource = tablesForPlots[1];
            chart1.Series[coefficients[1].Item1].XValueMember = "X_Value";
            chart1.Series[coefficients[1].Item1].YValueMembers = "Y_Value";
            chart1.Series[coefficients[1].Item1].ChartType = SeriesChartType.Line;

            chart2.DataSource = tablesForPlots[2];
            chart2.Series[coefficients[2].Item1].XValueMember = "X_Value";
            chart2.Series[coefficients[2].Item1].YValueMembers = "Y_Value";
            chart2.Series[coefficients[2].Item1].ChartType = SeriesChartType.Line;

            chart3.DataSource = tablesForPlots[3];
            chart3.Series[coefficients[3].Item1].XValueMember = "X_Value";
            chart3.Series[coefficients[3].Item1].YValueMembers = "Y_Value";
            chart3.Series[coefficients[3].Item1].ChartType = SeriesChartType.Line;

            chart4.DataSource = tablesForPlots[4];
            chart4.Series[coefficients[4].Item1].XValueMember = "X_Value";
            chart4.Series[coefficients[4].Item1].YValueMembers = "Y_Value";
            chart4.Series[coefficients[4].Item1].ChartType = SeriesChartType.Line;

            chart5.DataSource = tablesForPlots[5];
            chart5.Series[coefficients[5].Item1].XValueMember = "X_Value";
            chart5.Series[coefficients[5].Item1].YValueMembers = "Y_Value";
            chart5.Series[coefficients[5].Item1].ChartType = SeriesChartType.Line;

            chart6.DataSource = tablesForPlots[6];
            chart6.Series[coefficients[6].Item1].XValueMember = "X_Value";
            chart6.Series[coefficients[6].Item1].YValueMembers = "Y_Value";
            chart6.Series[coefficients[6].Item1].ChartType = SeriesChartType.Line;

            chart7.DataSource = tablesForPlots[7];
            chart7.Series[coefficients[7].Item1].XValueMember = "X_Value";
            chart7.Series[coefficients[7].Item1].YValueMembers = "Y_Value";
            chart7.Series[coefficients[7].Item1].ChartType = SeriesChartType.Line;

            chart8.DataSource = tablesForPlots[8];
            chart8.Series[coefficients[8].Item1].XValueMember = "X_Value";
            chart8.Series[coefficients[8].Item1].YValueMembers = "Y_Value";
            chart8.Series[coefficients[8].Item1].ChartType = SeriesChartType.Line;

            chart9.DataSource = tablesForPlots[9];
            chart9.Series[coefficients[9].Item1].XValueMember = "X_Value";
            chart9.Series[coefficients[9].Item1].YValueMembers = "Y_Value";
            chart9.Series[coefficients[9].Item1].ChartType = SeriesChartType.Line;

            chart10.DataSource = tablesForPlots[10];
            chart10.Series[coefficients[10].Item1].XValueMember = "X_Value";
            chart10.Series[coefficients[10].Item1].YValueMembers = "Y_Value";
            chart10.Series[coefficients[10].Item1].ChartType = SeriesChartType.Line;

            chart11.DataSource = tablesForPlots[11];
            chart11.Series[coefficients[11].Item1].XValueMember = "X_Value";
            chart11.Series[coefficients[11].Item1].YValueMembers = "Y_Value";
            chart11.Series[coefficients[11].Item1].ChartType = SeriesChartType.Line;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
