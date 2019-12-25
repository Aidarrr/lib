using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagrange
{
    class Program
    {
        public static double[] factorial(int n)
        {
            double[] fact = new double[n];
            int i;
            fact[0] = 1;
            for (i = 1; i < n; i++)
                fact[i] = (fact[i - 1] * i);
            return fact;
        }

        public static double M(int n, List<List<double>> table)
        {
            double res = 0, denum = 1;

            for (int j = 0; j <= n+1; j++)
            {
                for (int i = 0; i <= n+1; i++)
                {
                    if(j != i)
                        denum *= table[j][0] - table[i][0];
                }
                res += table[j][1] / denum;
                denum = 1;
            }
            return Math.Abs(res);
        }

        public static double Error(double x, int n, double[] fact, List<List<double>> table)
        {
            double omega = 1 ;

            for (int j = 0; j <= n; j++)
                omega *= x - table[j][0];
            omega = Math.Abs(omega);

            return (M(n, table) / fact[n + 1]) * omega;
        }

        public static double Result(int n, List<List<double>> table, double x)
        {
            double numerator = 1, denumerator = 1, result = 0;

            for (int k = 0; k <= n; k++)
            {
                for (int i = 0; i <= n; i++)
                {
                    if(k != i)
                        numerator *= x - table[i][0];   
                
                    if (k != i)
                        denumerator *= table[k][0] - table[i][ 0];
                }

                result += numerator / denumerator * table[k][1];
                numerator = 1; denumerator = 1;
            }
            return result;
        }

        static void Main(string[] args)
        {
            double x = 0.114;
            double[] fact = factorial(4);
            double[,] input = new double[,] { { 0.02, 1.02316 }, { 0.08, 1.09590 }, { 0.12, 1.14725 }, { 0.17, 1.21483 }, { 0.23, 1.30120 }, { 0.3, 1.40976 } };
            List<List<double>> table = new List<List<double>>();
            for (int i = 0; i < input.Length; i++)
                if (i + 1 != input.Length)
                    if (x > input[i, 0] && x < input[i + 1, 0])
                    {
                        table.Add(new List<double> { input[i, 0], input[i, 1] });
                        table.Add(new List<double> { input[i + 1, 0], input[i + 1, 1] });

                        for (int j = i + 2; j < 6; j++)
                        {
                            table.Add(new List<double> { input[j, 0], input[j, 1] });
                            if (table.Count == 4)
                                break;
                        }
                        if (table.Count != 4)
                            for (int j = i - 1; table.Count != 4; j--)
                                table.Insert(0, new List<double> { input[j, 0], input[j, 1] });
                        break;
                    }

            Console.WriteLine("Линейная интерполяция {0}", Result(1, table, x));
            Console.WriteLine("Квадратичная интерполяция {0}", Result(2, table, x));
            Console.WriteLine("R1 <= {0:0.########}", Error(x, 1, fact, table));
            Console.WriteLine("R2 <= {0:0.########}", Error(x, 2, fact, table));
        }
    }
}
