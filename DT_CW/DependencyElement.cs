using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_CW
{
    class DependencyElement
    {
        static int sizeOfDataTable = 10;
        private List<Tuple<double, double>> tableForCoefficientCalculation; 
        private List<Tuple<string, double>> dataFromFile;
        private double elasticityCoefficient;
        private Tuple<string, string> dependentAndIndependent;
        private int dependentVariableNumber, independentVariableNumber;

        public DependencyElement(List<Tuple<string, double>> dataFromFile, int depVar, int indepVar)
        {
            this.dataFromFile = dataFromFile;
            elasticityCoefficient = 0;
            dependentVariableNumber = depVar;
            independentVariableNumber = indepVar;
        }

        public void calculateCoefficientTableData()
        {

        }

        public void calculateCoefficient()
        {

        }
    }
}
