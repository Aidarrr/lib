using System;
using System.Net;
using System.Text.Json;

namespace SimpleHTTP
{
    class Program
    {
        static Output GetOutputObject(Input input)
        {
            Output output = new Output();
            output.CalcSum(input.Sums, input.K);
            output.CalcMul(input.Muls);
            output.SortInputs(input.Muls, input.Sums);
            return output;
        }

        static void Main(string[] args)
        {
            string port = Console.ReadLine();
            Client client = new Client();
            
            try
            {
                while (!client.Ping(port)) {}

                string jsonInput = null;
                while (jsonInput == null)
                {
                    jsonInput = client.GetInputData(port);
                }

                Console.WriteLine("Входные данные для задачи: {0}", jsonInput);

                Input input = JsonSerializer.Deserialize<Input>(jsonInput);
                Output output = GetOutputObject(input);
                string jsonOutput = JsonSerializer.Serialize(output);

                Console.WriteLine("Ответ на задачу: {0}", jsonOutput);

                while (!client.WriteAnswer(port, jsonOutput)) { }
                Console.WriteLine("Ответ сервера: {0}", client.answerForSolution);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
