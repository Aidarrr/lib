using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_CW
{
    class CoefficientContainer
    {
        private List<Tuple<string, double>> coefficients;
        private List<DependencyElement> dependencyElements;
        private int countOfIntegralValues, countOfIndepValues;
        IntegralValues integralValues;
        FileReader fileReader;
        

        public CoefficientContainer()
        {
            countOfIndepValues = 3; 
            countOfIntegralValues = 3;
            dependencyElements = new List<DependencyElement>();
            coefficients = new List<Tuple<string, double>>();
            integralValues = new IntegralValues();

            fileReader = new FileReader();
            fileReader.readInputData("input.txt");
        }

        public void calculateCoefficients()
        {
            for (int integralVarNum = 0; integralVarNum < countOfIntegralValues; integralVarNum++)
            {
                for (int indepVarNum = 0; indepVarNum < countOfIndepValues; indepVarNum++)
                {
                    dependencyElements.Add(new DependencyElement(fileReader.getDataFromFile(), integralVarNum, indepVarNum));
                    dependencyElements[dependencyElements.Count - 1].calculateCoefficientTableData(integralValues);
                    dependencyElements[dependencyElements.Count - 1].calculateCoefficient();
                }
            }
        }
    }
}
