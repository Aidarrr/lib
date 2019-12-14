using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_lab_4
{
    class Program
    {
        static string[,] fillArray(int lines, int col)
        {
            string[,] TM = new string[lines, col];

            TM[0, 0] = "aR1"; TM[0, 1] = "aL3"; TM[0, 2] = "aL3"; TM[0, 3] = "bL5"; TM[0, 4] = "yL5";
            TM[1, 0] = "bR1"; TM[1, 1] = "bL4"; TM[1, 2] = "bL3"; TM[1, 3] = "bL5"; TM[1, 4] = "yL5";
            TM[2, 0] = "yL2"; TM[2, 1] = "-"; TM[2, 2] = "bC0"; TM[2, 3] = "-"; TM[2, 4] = "yC0";

            return TM;
        }

        static void Main(string[] args)
        {
            var input = new StringBuilder();
            string temp;
            temp = Console.ReadLine();
            input.AppendLine(temp);
            input.Insert(0, 'y');
            var TM = fillArray(3, 5);
            int q = 1, i = 1, line;
            char letter;
            Console.Clear();
            while(q != 0)
            {
                letter = input[i];
                if (letter == 'a')
                    line = 0;
                else if (letter == 'b')
                    line = 1;
                else
                {
                    letter = 'y';
                    line = 2;
                }

                for (int j = 0; j < input.Length; j++)
                {
                    if (j == i)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(input[j]);
                }
                Console.WriteLine("q{0}", q);
                temp = TM[line, q - 1];
                Console.WriteLine("({0}, {1}) -> {2}", letter, q, temp);
                Console.WriteLine();
                if (temp != "-")
                {
                    input[i] = temp[0];
                    if (temp[1] == 'R')
                        i++;
                    else if (temp[1] == 'L')
                        i--;

                    q = Convert.ToInt32(temp[2]) - 48;
                }
            }

            Console.Write("Результат: ");
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] != 'y')
                Console.Write(input[j]);
            }
            
        }
    }
}
