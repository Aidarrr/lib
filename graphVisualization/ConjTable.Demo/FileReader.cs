using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT_CW
{
    public class FileReader
    {
        string[] rowNames = new string[] { "Поступления от продаж", "Прямые издержки", "Условно-постоянные издержки", 
                                           "Сдельная зарплата", "Несдельная зарплата", "Налоги", "Инвестиции в основные средства" };
        List<Tuple<string, double>> dataFromFile;

        public List<Tuple<string, double>> getDataFromFile()
        {
            return dataFromFile;
        }

        public void readInputData(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            dataFromFile = new List<Tuple<string, double>>();

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";

            for (int i = 0; i < lines.Length; i++)
            {
                dataFromFile.Add(new Tuple<string, double>(rowNames[i], Convert.ToDouble(lines[i], provider)));
            }
        }
    }
}
