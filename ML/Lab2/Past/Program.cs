using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Past
{
    class Program
    {
        public static Dictionary<char, List<int>> fillDict(int n, Dictionary<char, List<int>> arg, char[] input)
        {
            switch (n)
            {
                case (1):
                    arg.Add(input[0], new List<int>() { 0, 1 });
                    break;
                case 2:
                    arg.Add(input[0], new List<int>() { 0, 0, 1, 1 });
                    arg.Add(input[1], new List<int>() { 0, 1, 0, 1 });
                    break;
                case 3:
                    arg.Add(input[0], new List<int>() { 0, 0, 0, 0, 1, 1, 1, 1 });
                    arg.Add(input[1], new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1 });
                    arg.Add(input[2], new List<int>() { 0, 1, 0, 1, 0, 1, 0, 1 });
                    break;
                case 4:
                    arg.Add(input[0], new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 });
                    arg.Add(input[1], new List<int>() { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });
                    arg.Add(input[2], new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 });
                    arg.Add(input[3], new List<int>() { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 });
                    break;
            }

            return arg;
        }

        public static List<int> calc(List<int> a, List<int> b, int num, int n)
        {
            n = Convert.ToInt32(Math.Pow(2, n));
            //bool[] res = new bool[n];
            List<int> res = new List<int>();

            if (num == 1)
                for (int i = 0; i < n; i++)
                    res.Add(Convert.ToInt32(Convert.ToBoolean(a[i]) && Convert.ToBoolean(b[i])));
            else if (num == 2)
                for (int i = 0; i < n; i++)
                    res.Add(Convert.ToInt32(Convert.ToBoolean(a[i]) || Convert.ToBoolean(b[i])));
            else if (num == 3)
                for (int i = 0; i < n; i++)
                    res.Add(Convert.ToInt32(!(Convert.ToBoolean(a[i]) && Convert.ToBoolean(b[i]))));
            else if (num == 4)
                for (int i = 0; i < n; i++)
                    res.Add(Convert.ToInt32(Convert.ToBoolean(a[i]) && !Convert.ToBoolean(b[i])));
            else if (num == 5)
                for (int i = 0; i < n; i++)
                    res.Add(Convert.ToInt32(!Convert.ToBoolean(a[i]) && !Convert.ToBoolean(b[i])));
            return res;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(Char.Parse).ToArray();

            var arg = new Dictionary<char, List<int>>();
            fillDict(n, arg, input);

            var result = calc(calc(calc(calc(arg[input[0]], calc(arg[input[2]], calc(arg[input[1]], arg[input[2]], 1, n), 2, n), 2, n), calc(arg[input[2]], arg[input[3]], 3, n), 1, n), calc(arg[input[2]], arg[input[3]], 4, n), 1,n), calc(calc(arg[input[2]], calc(arg[input[3]], arg[input[2]], 5, n), 2, n), arg[input[3]], 2, n), 1, n);

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }

            if (n == 1)
                Console.WriteLine("Упрощенное выражение = 0");

        }
    }
}
