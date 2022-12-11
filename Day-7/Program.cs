using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7 {
    internal class Program {
        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            //Part1(data);
            Console.WriteLine($"The results came in and are: {Part1(data)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static int Part1(string[] data) {
            int results = 0;
            foreach (string line in data) {
                Console.WriteLine(line);
            }

            return results;
        }
    }
}
