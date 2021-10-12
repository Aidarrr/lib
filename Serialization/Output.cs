using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class Output
    {
        public decimal SumResult { get; set; }
        public int MulResult { get; set; }
        public decimal[] SortedInputs { get; set; }

        public void CalcSum(decimal[] Sums, int K)
        {
            SumResult = K * Sums.Sum();
        }

        public void CalcMul(int[] Muls)
        {
            MulResult = Muls.Aggregate(1, (a, b) => a * b);
        }

        public void SortInputs(int[] Muls, decimal[] Sums)
        {
            SortedInputs = new decimal[Muls.Length + Sums.Length];
            decimal[] MulsDecimalArr = Array.ConvertAll(Muls, x => (decimal) x);

            Array.Copy(Sums, SortedInputs, Sums.Length);
            Array.Copy(MulsDecimalArr, 0, SortedInputs, Sums.Length, Muls.Length);
            Array.Sort(SortedInputs);
        }
    }
}
