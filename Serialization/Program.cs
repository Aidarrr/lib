using System;
using System.Text.Json;
using System.Xml.Serialization;
using System.IO;

namespace Serialization
{
    class Program
    {
        private Output GetOutputObject(Input input)
        {
            Output output = new Output();
            output.CalcSum(input.Sums, input.K);
            output.CalcMul(input.Muls);
            output.SortInputs(input.Muls, input.Sums);
            return output;
        }

        public string GetSerializedOutputJSON(string jsonInput)
        {
            Input input = JsonSerializer.Deserialize<Input>(jsonInput);
            Output output = GetOutputObject(input);
            string jsonOutput = JsonSerializer.Serialize(output);
            return jsonOutput;
        }

        public Input DeserializeXML(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Input));
            StreamReader reader = new StreamReader(filePath);
            Input input = (Input)serializer.Deserialize(reader);
            reader.Close();
            return input;
        }

        public static void SerializeToXML(Output output, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Output));
            StreamWriter writer = new StreamWriter(xmlFilePath);
            xmlSerializer.Serialize(writer, output);
            writer.Close();
        }

        public void SerializeOutputXML(string inputXmlFile, string outputXmlFile)
        {
            Input input = DeserializeXML(inputXmlFile);
            Output output = GetOutputObject(input);
            SerializeToXML(output, outputXmlFile);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            string serializationType = Console.ReadLine();

            if (serializationType.Equals("json"))
            {
                string jsonInput = Console.ReadLine();
                Console.WriteLine(program.GetSerializedOutputJSON(jsonInput));
            } 
            else if (serializationType.Equals("xml"))
            {
                string inputXmlFile = Console.ReadLine();
                string outputXmlFile = Console.ReadLine();
                program.SerializeOutputXML(inputXmlFile, outputXmlFile);
                Console.WriteLine("Сериализованный объект ответа получен в файле " + outputXmlFile);
            }
        }
    }
}
