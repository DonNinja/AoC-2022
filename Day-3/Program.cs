using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3 {
    internal class Program {
        static char[] lowerList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char) i).ToArray();
        static char[] upperList = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char) c).ToArray();
        static IEnumerable<char> alphabetList = lowerList.Concat(upperList);

        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            Console.WriteLine($"The results came in and are: {Part1(data)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static int GetLetterValue(char letter) {
            for (int i = 0; i < alphabetList.Count(); i++) {
                if (alphabetList.ElementAt(i) == letter) {
                    return i + 1;
                }
            }

            return -1;
        }

        static int Part1(string[] data) {
            int results = 0;

            foreach (string bag in data) {
                if (bag.Length == 0 || bag.Length % 2 == 1) continue;

                int bagSplit = bag.Length / 2;
                string[] compartments = new string[] {
                    bag.Substring(0, bagSplit),
                    bag.Substring(bagSplit, bagSplit)
                };

                HashSet<string> parts = new HashSet<string>();

                foreach (char letter in compartments[0].ToCharArray()) {
                    if (parts.TryGetValue(letter.ToString(), out var outLetter)) continue;

                    foreach (char secondLetter in compartments[1]) {
                        if (secondLetter == letter) {
                            parts.Add(letter.ToString());
                            results += GetLetterValue(secondLetter);
                            break;
                        }
                    }
                }
            }


            return results;
        }

        static int Part2(string[] data) {
            int results = 0;

            //for (int i = 0; i < data.Length; i += 3) {
            //    if (data.Length - i - 3 < 0) break;

            //    string[] bags = new string[3] {
            //        data[i],
            //        data[i + 1],
            //        data[i + 2]
            //    };

            //    foreach (char letter in bags[0]) {
            //        HashSet<string> 

            //    }
            //}

            return results;
        }
    }
}
