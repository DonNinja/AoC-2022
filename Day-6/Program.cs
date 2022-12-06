using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6 {
    internal class Program {
        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            //Part1(data);
            Console.WriteLine($"The results came in and are: {GetPackage(data, 14)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static int GetPackage(string[] data, int length) {
            string marker = "";
            string line = data[0];

            for (int i = 0; i < line.Length; i++) {
                char letter = line[i];
                int letterIndex = marker.IndexOf(letter);
                if (letterIndex != -1) {
                    marker = marker.Substring(letterIndex + 1);
                }
                marker += letter;
                if (marker.Length == length) {
                    return i + 1;
                }
            }

            return -1;
        }
    }
}
