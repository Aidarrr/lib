using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static Dictionary<char, List<int>> fillDict(int n, Dictionary<char, List<int>> arg)
        {
            switch (n)
            {
                case (1):
                    arg.Add('x', new List<int>() { 0, 1 });
                    break;
                case 2:
                    arg.Add('x', new List<int>() { 0, 0, 1, 1 });
                    arg.Add('y', new List<int>() { 0, 1, 0, 1 });
                    break;
                case 3:
                    arg.Add('x', new List<int>() { 0, 0, 0, 0, 1, 1, 1, 1 });
                    arg.Add('y', new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1 });
                    arg.Add('z', new List<int>() { 0, 1, 0, 1, 0, 1, 0, 1 });
                    break;
                case 4:
                    arg.Add('x', new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 });
                    arg.Add('y', new List<int>() { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });
                    arg.Add('z', new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 });
                    arg.Add('b', new List<int>() { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 });
                    break;
                case 5:
                    arg.Add('x', new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                    arg.Add('y', new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 });
                    arg.Add('z', new List<int>() { 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1 });
                    arg.Add('b', new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1 });
                    arg.Add('m', new List<int>() { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 });
                    break;
            }

            return arg;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var result = Console.ReadLine().Split(' ').Select(Int32.Parse).ToArray();
            StringBuilder function = new StringBuilder();

            Dictionary<char, List<int>> arg = new Dictionary<char, List<int>>();
            arg = fillDict(n, arg);
            Console.WriteLine();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == 0)
                {
                    function.Append('(');
                    foreach (var item in arg)
                    {
                        if (item.Value[i] == 1)
                        {
                            function.Append(item.Key);
                            function.Append(" || ");
                        }
                        else if (item.Value[i] == 0)
                        {
                            function.Append(Char.ToUpper(item.Key));
                            function.Append(" || ");
                        }
                    }
                    function.Remove(function.Length - 4, 4);
                    function.Append(')');
                }
            }

            Console.WriteLine(function.ToString());
        }
    }
}

