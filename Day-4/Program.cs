using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4 {
    internal class Program {
        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            Console.WriteLine($"The results came in and are: {Part1(data)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static int Part1(string[] data) {
            int results = 0;

            foreach (string item in data) {
                string[] sections = item.Split(',');

                int[] shortSection = new int[2];
                int[] longSection = new int[2];
                int minLength = int.MaxValue;

                for (int i = 0; i < sections.Length; i++) {
                    string[] parts = sections[i].Split('-');

                    int length = int.Parse(parts[1]) - int.Parse(parts[0]);
                    if (length < minLength) {
                        minLength = length;
                        longSection = shortSection;
                        shortSection = new int[2] { int.Parse(parts[0]), int.Parse(parts[1]) };
                    }
                    else {
                        longSection = new int[2] { int.Parse(parts[0]), int.Parse(parts[1]) };
                    }
                }

                if (shortSection[0] >= longSection[0] && shortSection[1] <= longSection[1]) results++;
            }

            return results;
        }

                return results;
        }
    }
}
