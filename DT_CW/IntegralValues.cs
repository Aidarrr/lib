using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_CW
{
    class IntegralValues
    {
        private int amountOfMonths = 18;
        private string[] integralVarNames = new string[] { "NPV", "PI", "MinCash" };

        public string getVarName(int integralVarNumber)
        {
            return integralVarNames[integralVarNumber];
        }

        public void calculateIntegralValue(int integralVarNumber, int indepVarNumber, List<Tuple<double, double>> tableForCoefficient, List<Tuple<string, double>> dataFromFile)
        {
            if(integralVarNumber == 0)
            {
                calcNPV(indepVarNumber, tableForCoefficient, dataFromFile);
            }
            else if(integralVarNumber == 1)
            {
                calcPI(indepVarNumber, tableForCoefficient, dataFromFile);
            }
            else
            {
                calcMinCash(indepVarNumber, tableForCoefficient, dataFromFile);
            }
        }

        private void calcNPV(int indepVarNumber, List<Tuple<double, double>> tableForCoefficient, List<Tuple<string, double>> dataFromFile)
        {
            for (int i = 0; i < tableForCoefficient.Count; i++)
            {
                double npv = 0;

                if(indepVarNumber == 0)
                {
                    npv += tableForCoefficient[i].Item1;
                } 
                else
                {
                    npv += dataFromFile[0].Item2;
                }

                for (int j = 1; j < dataFromFile.Count - 1; j++)
                {
                    if(j == indepVarNumber)
                    {
                        npv -= tableForCoefficient[i].Item1;
                        continue;
                    }

                    npv -= dataFromFile[j].Item2;
                }

                npv = npv * amountOfMonths;

                if(indepVarNumber == dataFromFile.Count - 1)
                {
                    npv -= tableForCoefficient[i].Item1;
                }
                else
                {
                    npv -= dataFromFile[dataFromFile.Count - 1].Item2;
                }

                tableForCoefficient[i] = new Tuple<double, double>(tableForCoefficient[i].Item1, npv);
            }
        }

        private void calcPI(int indepVarNumber, List<Tuple<double, double>> tableForCoefficient, List<Tuple<string, double>> dataFromFile)
        {
            calcNPV(indepVarNumber, tableForCoefficient, dataFromFile);

            for (int i = 0; i < tableForCoefficient.Count; i++)
            {
                var pi = tableForCoefficient[i].Item2;

                if (indepVarNumber == dataFromFile.Count - 1)
                {
                    pi += tableForCoefficient[i].Item1;
                    pi /= tableForCoefficient[i].Item1;
                }
                else
                {
                    pi += dataFromFile[dataFromFile.Count - 1].Item2;
                    pi /= dataFromFile[dataFromFile.Count - 1].Item2;
                }

                tableForCoefficient[i] = new Tuple<double, double>(tableForCoefficient[i].Item1, pi);
            }
        }

        private void calcMinCash(int indepVarNumber, List<Tuple<double, double>> tableForCoefficient, List<Tuple<string, double>> dataFromFile)
        {
            calcNPV(indepVarNumber, tableForCoefficient, dataFromFile);

            for (int i = 0; i < tableForCoefficient.Count; i++)
            {
                var minCash = tableForCoefficient[i].Item2;

                if (indepVarNumber == dataFromFile.Count - 1)
                {
                    minCash += tableForCoefficient[i].Item1;
                }
                else
                {
                    minCash += dataFromFile[dataFromFile.Count - 1].Item2;
                }
                minCash /= amountOfMonths;

                tableForCoefficient[i] = new Tuple<double, double>(tableForCoefficient[i].Item1, minCash);
            }
        }
    }
}
