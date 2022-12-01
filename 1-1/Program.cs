using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_1 {
    internal class Program {
        static void Main(string[] args) {
            string[] numbers = File.ReadAllLines(args[1]);

            int results = 0;

            switch (args[0]) {
                case "1":
                    results = CalculateHighest(numbers);
                    break;
                case "2":
                    CalculateThreeHighest(numbers);
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Calculating highest total as {results}");

            Console.WriteLine("(Press Enter to exit)");
            Console.ReadLine();
        }

        static int CalculateHighest(string[] Numbers) {
            int highestTotal = 0;
            int currTotal = 0;

            foreach (string num in Numbers) {
                if (num == "") {
                    highestTotal = currTotal > highestTotal ? currTotal : highestTotal;
                    currTotal = 0;
                }
                else {
                    currTotal += int.Parse(num);
                }
            }

            return highestTotal;
        }

        static int CalculateThreeHighest(string[] numbers) {
            int[] highestInts = { 0, 0, 0 };

            foreach (string num in numbers) {

            }

            return highestInts.Sum();
        }
    }
}
