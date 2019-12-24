using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        //Конечные разности
        public static double[] delta(List<double> y, int n, bool fl)
        {
            double[,] delta = new double[y.Count() ,n];     
            int lines = y.Count() - 1;                                  
            for (int i = 0; i < y.Count() - 1; i++)             //Заполнение первого столбца
                delta[i, 0] = y[i + 1] - y[i];
            
            for (int j = 1; j < n; j++)                         //Заполнение остальных столбцов
            {
                lines--;
                for (int i = 0; i < lines; i++)
                    delta[i, j] = delta[i + 1, j - 1] - delta[i, j - 1];
            }
            lines = y.Count() - 2;
            double[] res = new double[n];

            if (fl)                                             //Взятие определенных значений из таблицы в зависимости от формулы Ньютона
                for (int j = 0; j < n; j++)
                    res[j] = delta[0, j];
            else
                for (int j = 0; j < n; j++)
                    res[j] = delta[lines--, j];

            return res;
        }

        //Первая формула Ньютона
        public static double result_left(double t, double y0, double[] deltaY, int n)
        {
            double res = y0;
            double fact = 1, neg_t = t;
            
            for (int i = 1; i <= n; i++)
            { 
                fact *= i;
                res += ((deltaY[i - 1] * t) / (fact)) * neg_t;
                neg_t *= t - i;
            }
            return res;
        }

        //Вторая формула Ньютона
        public static double result_right(double t, double yn, double[] deltaY, int n)
        {
            double res = yn;
            double fact = 1, sum_t = t;
            
            for (int i = 1; i <= n; i++)
            {
                fact *= i;
                res += ((deltaY[i - 1] * t) / (fact)) * sum_t;
                sum_t *= t + i;
            }

            return res;
        }

        //Погрешность
        public static double Error(int n, double finiteY, double h, double t, bool left)
        {
            double fact = 1;
            for (int i = 1; i <= n+1; i++)
                fact *= i;

            double R = (Math.Abs(finiteY / (fact * Math.Pow(h, n + 1)))) / fact;  //Вычисление  M / (n+1)!
            R *= Math.Pow(h, n + 1);

            if(left)
                for (int i = 0; i <= n; i++)
                    R *= Math.Abs(t - i);
            else
                for (int i = 0; i <= n; i++)
                    R *= Math.Abs(t + i);
            return R;
        }

        static void Main(string[] args)
        {
            const double h = 0.05;
            double[] x = new double[] { 0.027, 0.525, 0.008, 0.61 };
            var input = new List<List<double>> {new List<double> {0.01, 0.06, 0.11, 0.16, 0.21, 0.26, 0.31, 0.36, 0.41, 0.46, 0.51, 0.56 }, 
                                            new List<double> { 0.991824, 0.951935, 0.913650, 0.876905, 0.841638, 0.807789, 0.775301, 0.744120, 0.714193, 0.685470, 0.657902, 0.631442 } };
            var table = new List<List<double>>();
            double[] deltaY;
            double t;

            //Выбор узлов
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < input[0][0])
                {
                    table.Add(new List<double> { input[0][0], input[0][1], input[0][2], input[0][3] }); //Значения x
                    table.Add(new List<double> { input[1][0], input[1][1], input[1][2], input[1][3] }); //Значения y
                    deltaY = delta(table[1], 3, true);                                                  //Конечные разности
                    t = (x[i] - table[0][0]) / h;
                    Console.WriteLine("x = {0}", x[i]);
                    Console.WriteLine(result_left(t, table[1][0], deltaY, 1));                          //Значение функции при линейной интерполяции
                    Console.WriteLine(result_left(t, table[1][0], deltaY, 2));                          //Значение функции при квадратичной интерполяции
                    Console.WriteLine("{0:0.########}", Error(1, deltaY[1], h, t, true));               //Погрешность
                    Console.WriteLine("{0:0.########}", Error(2, deltaY[2], h, t, true));
                }
                else if (x[i] > input[0][input[0].Count - 1])
                {
                    table.Add(new List<double> { input[1][input[1].Count - 1], input[1][input[1].Count - 2], input[1][input[1].Count - 3], input[1][input[1].Count - 4] });
                    table[0].Reverse();
                    deltaY = delta(table[0], 3, false);
                    t = (x[i] - input[0][input[0].Count - 1]) / h;
                    Console.WriteLine("x = {0}", x[i]);
                    Console.WriteLine(result_right(t, input[1][input[1].Count - 1], deltaY, 1));
                    Console.WriteLine(result_right(t, input[1][input[1].Count - 1], deltaY, 2));
                    Console.WriteLine("{0:0.########}", Error(1, deltaY[1], h, t, false));
                    Console.WriteLine("{0:0.########}", Error(2, deltaY[2], h, t, false));
                }
                else
                {
                    for (int j = 0; j < input[0].Count; j++)
                    {
                        if (x[i] > input[0][j] && x[i] < input[0][j + 1] && input[0].Count - j > (input[0].Count / 2))
                        {
                            table.Add(new List<double> { input[0][j], input[0][j + 1], input[0][j + 2], input[0][j + 3] });
                            table.Add(new List<double> { input[1][j], input[1][j + 1], input[1][j + 2], input[1][j + 3] });
                            deltaY = delta(table[1], 3, true);
                            t = (x[i] - table[0][0]) / h;
                            Console.WriteLine("x = {0}", x[i]);
                            Console.WriteLine(result_left(t, table[1][0], deltaY, 1));
                            Console.WriteLine(result_left(t, table[1][0], deltaY, 2));
                            Console.WriteLine("{0:0.########}", Error(1, deltaY[1], h, t, true));
                            Console.WriteLine("{0:0.########}", Error(2, deltaY[2], h, t, true));
                        }
                        else if(x[i] > input[0][j] && x[i] < input[0][j + 1] && input[0].Count - j < (input[0].Count / 2))
                        {
                            table.Add(new List<double> { input[0][j+1], input[0][j], input[0][j - 1], input[0][j - 2] });
                            table.Add(new List<double> { input[1][j + 1], input[1][j], input[1][j - 1], input[1][j - 2] });
                            table[1].Reverse();
                            deltaY = delta(table[1], 3, false);
                            t = (x[i] - table[0][0]) / h;
                            Console.WriteLine("x = {0}", x[i]);
                            Console.WriteLine(result_right(t, table[1][3], deltaY, 1));
                            Console.WriteLine(result_right(t, table[1][3], deltaY, 2));
                            Console.WriteLine("{0:0.########}", Error(1, deltaY[1], h, t, false));
                            Console.WriteLine("{0:0.########}", Error(2, deltaY[2], h, t, false));
                        }
                    }
                }
                table.Clear();
            }
        }
    }
}
