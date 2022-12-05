using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day_5 {
    class NewStack {
        LinkedList<char> stack = new LinkedList<char>();

        public NewStack() {
            stack.Clear();
        }

        public void PushPopulate(char c) {
            stack.AddFirst(c);
        }

        public void Push(char c) {
            stack.AddLast(c);
        }

        public char Pop() {
            char returnChar = stack.Last();
            stack.RemoveLast();

            return returnChar;
        }

        public bool IsEmpty() {
            return stack.Count == 0;
        }

        public void DisplayCrates() {
            foreach (char crate in stack.Reverse()) {
                Console.Write($"[{crate}] ");
            }
            Console.WriteLine();
        }

        public char GetTop() {
            return stack.Reverse().First();
        }
    }

    public enum ReadState {
        Stacks,
        Movements
    }

    internal class Program {
        static NewStack[] stacks = new NewStack[10];

        static void Main(string[] args) {
            string filepath = args[0];

            string[] data = File.ReadAllLines(filepath);

            //Part1(data);
            Console.WriteLine($"The results came in and are: {Part1(data)}");

            Console.WriteLine("(Press enter to quit)");
            Console.ReadLine();
        }

        static string Part1(string[] data) {
            ReadState readState = ReadState.Stacks;
            string firstCrates = "";

            for (int i = 0; i < data.Length; i++) {
                string line = data[i];
                if (line == "") {
                    readState = ReadState.Movements;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Starting movements");
                    Console.ForegroundColor = ConsoleColor.White;

                    continue;
                }
                if (readState == ReadState.Stacks) {
                    ReadLines(line);
                }
                else {
                    //MoveOneByOne(line);
                    MoveTogether(line);
                }
            }
            foreach (NewStack s in stacks) {
                if (s == null) break;

                s.DisplayCrates();
            }

            foreach (NewStack s in stacks) {
                if (s == null) break;

                firstCrates = new string(firstCrates.Append(s.GetTop()).ToArray());
            }

            return firstCrates;
        }

        static void ReadLines(string line) {
            int stackNumber = 0;
            Regex regex = new Regex(@"[a-zA-Z]");
            for (int i = 1; i <= line.Length - 1; i += 4) {
                if (stacks[stackNumber] == null) {
                    stacks[stackNumber] = new NewStack();
                }

                if (regex.IsMatch(line[i].ToString())) {
                    stacks[stackNumber].PushPopulate(line[i]);
                }
                stackNumber++;
            }
        }

        static void MoveOneByOne(string line) {
            int amount = GetNextNumber(ref line);

            int stackIndex = GetNextNumber(ref line);
            NewStack stackFrom = stacks[stackIndex - 1];
            stackIndex = GetNextNumber(ref line);
            NewStack stackTo = stacks[stackIndex - 1];

            Move(stackFrom, stackTo, amount);
        }

        static void MoveTogether(string line) {
            int amount = GetNextNumber(ref line);

            int stackIndex = GetNextNumber(ref line);
            NewStack stackFrom = stacks[stackIndex - 1];

            NewStack bufferStack = new NewStack();

            stackIndex = GetNextNumber(ref line);
            NewStack stackTo = stacks[stackIndex - 1];

            Move(stackFrom, bufferStack, amount);
            Move(bufferStack, stackTo, amount);
        }

        static void Move(NewStack stackFrom, NewStack stackTo, int amount) {
            if (stackFrom != null) {
                for (int i = 0; i < amount; i++) {
                    char move = stackFrom.Pop();
                    stackTo.Push(move);
                }
            }
        }

        static int GetNextNumber(ref string line) {
            Regex isDigit = new Regex(@"[0-9]");
            IEnumerable<char> charList = line.SkipWhile(x => !char.IsDigit(x));
            line = new string(charList.ToArray());

            int returnNumber = int.Parse(new string (line.TakeWhile(x => char.IsDigit(x)).ToArray()));
            line = new string(line.SkipWhile(x => char.IsDigit(x)).ToArray());
            return returnNumber;
        }
    }
}
