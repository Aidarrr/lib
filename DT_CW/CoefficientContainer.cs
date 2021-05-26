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
            countOfIndepValues = 7; 
            countOfIntegralValues = 3;
            dependencyElements = new List<DependencyElement>();
            coefficients = new List<Tuple<string, double>>();
            integralValues = new IntegralValues();

            fileReader = new FileReader();
            fileReader.readInputData("input.txt");
        }

        public void calculateCoefficients()
        {
            int npvNum = 0, piNum = 1, minCashNum = 2;

            for (int indepVarNum = 0; indepVarNum < countOfIndepValues; indepVarNum++)
            {
                dependencyElements.Add(new DependencyElement(fileReader.getDataFromFile(), npvNum, indepVarNum));
                dependencyElements[dependencyElements.Count - 1].calculateCoefficientTableData(integralValues);
                dependencyElements[dependencyElements.Count - 1].calculateCoefficient();
            }

            int indepCountForPi = 3, indepCountForMinCash = 2, startForMinCash = 1;

            for (int indepVarNum = 0, i = 0; i < indepCountForPi; indepVarNum+=2, i++)
            {
                dependencyElements.Add(new DependencyElement(fileReader.getDataFromFile(), piNum, indepVarNum));
                dependencyElements[dependencyElements.Count - 1].calculateCoefficientTableData(integralValues);
                dependencyElements[dependencyElements.Count - 1].calculateCoefficient();
            }

            for (int indepVarNum = startForMinCash, i = 0; i < indepCountForMinCash; indepVarNum+=2, i++)
            {
                dependencyElements.Add(new DependencyElement(fileReader.getDataFromFile(), minCashNum, indepVarNum));
                dependencyElements[dependencyElements.Count - 1].calculateCoefficientTableData(integralValues);
                dependencyElements[dependencyElements.Count - 1].calculateCoefficient();
            }
        }

        public void fillListOfCoefficients()
        {
            foreach (var element in dependencyElements)
            {
                element.setNameOfDependentAndIndepVariables(integralValues);
                var dependentAndIndependentNames = element.getNamesOfDependency();

                string descriptionOfDependency = "Зависимость " + dependentAndIndependentNames.Item1 + " от параметра \"" + dependentAndIndependentNames.Item2 + "\"";
                coefficients.Add(new Tuple<string, double>(descriptionOfDependency, element.getCoefficient()));
            }
        }
    }
}
