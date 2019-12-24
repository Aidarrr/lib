using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagrange
{
    class Program
    {
        public static int[] factorial(int n)
        {
            int[] fact = new int[n];
            int i;
            fact[0] = 1;
            for (i = 1; i < n; i++)
                fact[i] = (fact[i - 1] * i);
            return fact;
        }

        public static double M(int n, List<List<double>> table)
        {
            double res = 0, denum = 1;

            for (int j = 0; j <= n + 1; j++)
            {
                for (int i = 0; i <= n + 1; i++)
                {
                    if (j != i)
                        denum *= table[j][0] - table[i][0];
                }
                res += table[j][1] / denum;
                denum = 1;
            }
            return Math.Abs(res);
        }

        public static double Error(double x, int n, int[] fact, List<List<double>> table)
        {
            double omega = 1;
            for (int i = 0; i < table.Count; i++)
            {
                if(x > table[i][0] && x < table[i + 1][ 0])
                for (int j = i; j <= n+i; j++)
                    omega *= x - table[j][0];
            }
            
            omega = Math.Abs(omega);

            return (M(n, table) / fact[n + 1]) * omega;
        }

        public static double Result(int n, double t, List<List<double>> table, int[] fact)
        {
            double numerator = 1, denumerator = 1, result = 0;

            for (int k = 0; k <= n; k++)
            {
                for (int i = 0; i <= n; i++)
                {
                    if (k != i)
                        numerator *= t - i;
                }
                
                denumerator = fact[k] * Math.Pow(-1, n - k) * fact[n - k];

                result += (numerator / denumerator) * table[k][1];
                numerator = 1; denumerator = 1;
            }
            return result;
        }

        static void Main(string[] args)
        {
            double[,] input = new double[,] { {0.115, 8.65729 }, {0.120, 8.29329 }, {0.125, 7.95829 }, { 0.130, 7.64893 }, { 0.135, 7.36235 }, { 0.140, 7.09613 } };
            
            var fact = factorial(4);
            List<List<double>> table = new List<List<double>>();
            double x = 0.1315;
            for (int i = 0; i < input.Length; i++)
                if (i + 1 != input.Length)
                    if (x > input[i, 0] && x < input[i + 1, 0])
                    {
                        table.Add(new List<double> { input[i, 0], input[i, 1] });
                        table.Add(new List<double> { input[i + 1, 0], input[i+1, 1] });
                        for (int j = i + 2; j < 6; j++)
                        {
                            table.Add(new List<double> { input[j, 0], input[j, 1] });
                            if (table.Count == 4)
                                break;
                        }
                        if (table.Count!=4)
                            for (int j = i-1; table.Count != 4; j--)
                                table.Insert(0, new List<double> { input[j, 0], input[j, 1] });
                        break;
                    }
            double t = (x - table[0][0]) / 0.005;
            Console.WriteLine("Линейная интерполяция {0}", Result(1, t, table, fact));
            Console.WriteLine("Квадратичная интерполяция {0}", Result(2, t, table, fact));
            Console.WriteLine("{0:0.########}", Error(x, 1, fact, table));
            Console.WriteLine("{0:0.########}",Error(x, 2, fact, table));
        }
    }
}
