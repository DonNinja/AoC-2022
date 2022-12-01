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
                    results = CalculateThreeHighest(numbers);
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
            int[] highestSums = new int[3];
            int currTotal = 0;

            foreach (string num in numbers) {
                if (num != "") {
                    currTotal += int.Parse(num);
                }
                if (num == "" || num == numbers.Last()) {
                    int lowestNumber = -1;
                    int index = 0;

                    for (int i = 0; i < highestSums.Length; i++) {
                        if (lowestNumber == -1 || lowestNumber > highestSums[i]) {
                            lowestNumber = highestSums[i];
                            index = i;
                        }
                    }
                    if (currTotal > lowestNumber) {
                        highestSums[index] = currTotal;
                    }

                    currTotal = 0;
                }
            }

            int returnSum = 0;

            foreach (var num in highestSums) {
                returnSum += num;
            }

            return returnSum;
        }
    }
}
