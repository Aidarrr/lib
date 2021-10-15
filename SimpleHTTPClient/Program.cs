using System;
using System.Text;

namespace lab2
{
    class Program
    {
      
        static void Main(string[] args)
        {
            String port = Console.ReadLine();

            var vars = new Vars();
            while (!vars.Ping(port))
            {

            }
            String inp_str = null;
            while (inp_str == null)
            {
                inp_str= vars.GetInputData(port);
            }
            var json = new JSON();
            Ser.Input inp = json.Deserialize<Ser.Input>(inp_str);
            Ser.Output outp = new Ser.Output(inp);
            var outp_str = json.Serialize<Ser.Output>(outp);
            while (!vars.WriteAnswer(port, Encoding.Default.GetBytes(outp_str)))
            {

            }
        }
    }
}