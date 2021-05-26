using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DT_CW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CoefficientContainer container = new CoefficientContainer();
            container.calculateCoefficients();
            container.fillListOfCoefficients();

            //FileReader fr = new FileReader();
            //fr.readInputData("input.txt");
            //IntegralValues integralValues = new IntegralValues();
            //DependencyElement dependencyElement = new DependencyElement(fr.getDataFromFile(), 0, 3);
            //dependencyElement.calculateCoefficientTableData(integralValues);
            //dependencyElement.calculateCoefficient();
        }
    }
}
