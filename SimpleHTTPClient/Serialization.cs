namespace lab2
{
    public class Ser
    {
        public class Input
        {
            public int K { get; set; }
            public decimal[] Sums { get; set; }
            public int[] Muls { get; set; }
        }
        public class Output
        {
            public decimal SumResult { get; set; }
            public int MulResult { get; set; }
            public decimal[] SortedInputs { get; set; }

            public Output()
            {
                this.SumResult = 0;
                this.MulResult = 1;
            }

            public Output(Input vvod)
            {
                int lngth, i, j;
                decimal tmp;

                this.MulResult = 1;
                this.SumResult = 0;

                foreach (decimal element in vvod.Sums)
                {
                    this.SumResult += element;
                }
                this.SumResult *= vvod.K;

                foreach (int element in vvod.Muls)
                {
                    this.MulResult *= element;
                }

                lngth = vvod.Muls.Length + vvod.Sums.Length;

                this.SortedInputs = new decimal[lngth];

                for (i = 0; i < vvod.Muls.Length; i++)
                    this.SortedInputs[i] = vvod.Muls[i];

                for (i = vvod.Muls.Length; i < lngth; i++)
                    this.SortedInputs[i] = vvod.Sums[i - vvod.Muls.Length];

                for (i = 0; i < lngth - 1; i++)
                {
                    for (j = i + 1; j < lngth; j++)
                    {
                        if (this.SortedInputs[i] > this.SortedInputs[j])
                        {
                            tmp = this.SortedInputs[i];
                            this.SortedInputs[i] = this.SortedInputs[j];
                            this.SortedInputs[j] = tmp;
                        }
                    }
                }
            }
        }
    }
}
