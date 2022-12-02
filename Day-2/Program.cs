using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Day_2 {
    internal class Program {
        /*
         * Rock, Paper, Scissors
         * P1: A, B, C
         * P2: X, Y, Z
         * Scores: 1, 2, 3
         */

        //! If win, 8 points
        //  If draw, 3 points
        //? If loss, 0 points
        const int win = 6;
        const int draw = 3;
        const int loss = 0;

        static Dictionary<string, int> scoreMap = new Dictionary<string, int> {
            { "X", 1 },
            { "Y", 2 },
            { "Z", 3 },
        };

        static Dictionary<string, string> keyLosesValueMap = new Dictionary<string, string> {
            { "X", "B" },
            { "Y", "C" },
            { "Z", "A" },
            { "A", "Y" },
            { "B", "Z" },
            { "C", "X" }
        };

        static Dictionary<string, string> keyWinsValueMap = new Dictionary<string, string> {
            { "B", "X" },
            { "C", "Y" },
            { "A", "Z" },
            { "Y", "A" },
            { "Z", "B" },
            { "X", "C" }
        };

        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            //Console.WriteLine($"The results came in and are: {CalculateOneGame(data)}");
            Console.WriteLine($"The results came in and are: {PredictResult(data)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static int CalculateOneGame(string[] data) {

            int results = 0;

            foreach (string game in data) {
                string[] plays = game.Split(' ');
                int oldResult = results;

                results += scoreMap[plays[1]];

                if (keyLosesValueMap[plays[0]] == plays[1]) {
                    results += win;
                }
                else if (keyLosesValueMap[plays[1]] == plays[0]) {
                    results += loss;
                }
                else {
                    results += draw;
                }
            }

            return results;
        }

        static int PredictResult(string[] data) {
            int results = 0;

            Dictionary<string, int> matchScoreMap = new Dictionary<string, int> {
                { "X", loss },
                { "Y", draw },
                { "Z", win }
            };

            foreach (string game in data) {
                string[] plays = game.Split(' ');

                Dictionary<string, string> choiceMap = new Dictionary<string, string> {
                    { "X", keyWinsValueMap[plays[0]] },
                    { "Y", plays[1] },
                    { "Z", keyLosesValueMap[plays[0]] },
                };

                string choice = choiceMap[plays[1]];

                Console.WriteLine($"The system chooses {choice}");

                results += matchScoreMap[plays[1]];
                results += scoreMap[choice];
            }

            return results;
        }
    }
}
