using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Sudoku
    {

        public List<List<int>> Numbers { get; set; }

        public Sudoku(List<List<int>> numbers) {
            if (Validate(numbers)) Numbers = numbers;
            else throw new Exception("Invalid numbers");
        }

        public static bool Validate(List<List<int>> num)
        {
            for (int i = 0; i < num.Count; i++)
            {
                List<int> row = new List<int>();
                List<int> col = new List<int>();
                for(int e = 0; e < num[i].Count; e++)
                {
                    if (row.Contains(num[i][e]) || col.Contains(num[e][i])) return false;
                    if(num[i][e] > 0) row.Add(num[i][e]);
                    if(num[e][i] > 0) col.Add(num[e][i]);
                };
            }
            for (int a = 0; a < 3; a++)
            {
                for(int b = 0; b < 3; b++)
                {
                    List<int> ints = new List<int>();
                    for(int x =  0; x < 3; x++)
                    {
                        for(int y = 0; y < 3; y++)
                        {
                            int n = num[a * 3 + x][b * 3 + y];
                            if (ints.Contains(n)) return false;
                            else if(n > 0) ints.Add(n);
                        }
                    }
                }
            }

            return true;
        }

        public static List<List<int>> GetSudokuFromFile(string filename)
        {
            if (File.Exists(filename))
            {
                string content = File.ReadAllText(filename);
                var lines = content.Split('\n');
                List<List<int>> numbers = new List<List<int>>();
                foreach(string line in lines)
                {
                    List<int> l = new List<int>();
                    string[] c = line.Split(" ");
                    foreach(var x in c)
                    {
                        var u = x.Trim();
                        if(u == "X")
                        {
                            l.Add(0);
                        }
                        else
                        {
                            if (Regex.IsMatch(u, @"^[0-9]$")) l.Add(int.Parse(u));
                            else l.Add(0);
                        }
                    }
                    numbers.Add(l);
                }
                return numbers;
            }
            else
            {
                throw new FileNotFoundException(filename);
            }
        }

        public bool Solve()
        {
            int zeroCount = Numbers.SelectMany(row => row).Count(value => value == 0);
            List<int> unknown = new List<int>();
            for(int i = 0; i < zeroCount; i++)
            {
                unknown.Add(0);
            }
            int current = 0;
            int itterations = 0;
            while (true)
            {
                itterations++;
                if (++unknown[current] > 9)
                {
                    unknown[current--] = 0;
                }
                else
                {
                    var NumCopy = DeepClone(Numbers);
                    int ix = 0;
                    for(int i = 0; i < NumCopy.Count; i++)
                    {
                        for(int j = 0; j < NumCopy[i].Count; j++)
                        {
                            if (NumCopy[i][j] == 0)
                            {
                                NumCopy[i][j] = unknown[ix++];
                            }
                        }
                    }
                    
                    if (Validate(NumCopy))
                    {
                        if(!NumCopy.SelectMany(row => row).Contains(0))
                        {
                            Numbers = NumCopy;
                            Console.WriteLine("\nNumber of itterations : " + itterations);
                            return true;
                        }
                        current++;
                        
                    }
                }
            }

        }

        static List<List<int>> DeepClone(List<List<int>> original)
        {
            List<List<int>> kopie = new List<List<int>>();

            foreach (List<int> podseznam in original)
            {
                List<int> kopiePodseznamu = new List<int>(podseznam);
                kopie.Add(kopiePodseznamu);
            }

            return kopie;
        }

        public static void PrintNumbers(List<List<int>> num)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            int a = -1;
            foreach(var v in num)
            {
                a++;
                if(a%3 == 0)
                {
                    Console.WriteLine("                      ");
                }
                int b = 2;
                foreach (var n in v)
                {
                    b++;
                    if(b%3 == 0)
                    {
                        Console.Write("  ");
                    }
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(n + " ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor= ConsoleColor.White;
                }
                Console.Write(" ");
                Console.WriteLine();
            }
            Console.WriteLine("                 ");
        }

        public void PrintNumbers()
        {
            PrintNumbers(Numbers);
        }
    }
}
