using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Names = new List<string>();
            Names.Add("Iman");
            Names.Add("Ali");
            Names.Add("Reza");
            Names.Add("Sara");

            var Result = from n in Names select n;

            Names.Add("Goli...........");

            foreach (string name in Result)
            {
                Console.WriteLine(name);
            }

            Console.ReadKey();
        }
    }
}
