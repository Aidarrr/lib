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
            tableForCoefficientCalculation = new List<Tuple<double, double>>();

            elasticityCoefficient = 0;
            dependentVariableNumber = depVar;
            independentVariableNumber = indepVar;
        }

        public Tuple<double, double> getMinAndMax()
        {
            if (independentVariableNumber == 0)
            {
                return new Tuple<double, double>(870000, 12000000);
            } 
            else if (independentVariableNumber == 1)
            {
                return new Tuple<double, double>(400000, 6000000);
            }

            return new Tuple<double, double>(10000, 200000);
        }

        public void calculateCoefficientTableData(IntegralValues integralValues)
        {
            Random random = new Random();
            var minAndMax = getMinAndMax();

            for (int i = 0; i < sizeOfDataTable; i++)
            {
                tableForCoefficientCalculation.Add(new Tuple<double, double>(random.NextDouble() * (minAndMax.Item2 - minAndMax.Item1) + minAndMax.Item1, 0));
            }

            integralValues.calculateIntegralValue(dependentVariableNumber, independentVariableNumber, tableForCoefficientCalculation, dataFromFile);
        }

        public void calculateCoefficient()
        {
            double maxIntegralValue = tableForCoefficientCalculation.Max(x => x.Item2);
            double maxIndepValue = tableForCoefficientCalculation.Max(x => x.Item1);

            double deltaIntegralVar = (tableForCoefficientCalculation[sizeOfDataTable - 1].Item2 - tableForCoefficientCalculation[sizeOfDataTable - 2].Item2) / maxIntegralValue;
            double deltaIndepVar = (tableForCoefficientCalculation[sizeOfDataTable - 1].Item1 - tableForCoefficientCalculation[sizeOfDataTable - 2].Item1) / maxIndepValue;

            elasticityCoefficient = deltaIntegralVar / deltaIndepVar;
        }
    }
}
