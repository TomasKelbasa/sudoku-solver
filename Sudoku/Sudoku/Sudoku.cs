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
            if(Validate(numbers)) Numbers = numbers;
        }

        public static bool ValidateRow(List<int> r)
        {
            if (r.Count != 9) return false;

            List<int> row = new List<int>();
            for (int i = 0; i < r.Count; i++)
            {
                if (r[i] != 0) row.Add(r[i]);
            }
            if(row.Count.Equals(row.Distinct().Count())) return true;
            
            return false;
        }

        public static bool Validate(List<List<int>> num)
        {
            List<List<int>> numbers = DeepClone(num);
            foreach(var i in numbers)
            {
                if(!ValidateRow(i)) return false;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> list = new List<int>();
                for(int e = 0; e < numbers.Count; e++)
                {
                    list.Add(numbers[e][i]);
                }
                if(!ValidateRow(list)) return false;
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
                            ints.Add(numbers[a * 3 + x][b * 3 + y]);
                        }
                    }
                    if(!ValidateRow(ints)) return false;
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
                        if(x.Trim() == "X")
                        {
                            l.Add(0);
                        }
                        else
                        {
                            if (Regex.IsMatch(x.Trim(), @"^[0-9xX]$")) l.Add(int.Parse(x.Trim()));
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
            while (true)
            {
                if (++unknown[current] > 9)
                {
                    unknown[current] = 0;
                    current--;
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
                        if(NumCopy.SelectMany(row => row).Count(value => value == 0) == 0)
                        {
                            Numbers = NumCopy;
                            return true;
                        }
                        else
                        {
                            current++;
                        }
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

        public void PrintNumbers()
        {
            foreach(var v in Numbers)
            {
                foreach (var n in v)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }

        public static void PrintNumbers(List<List<int>> num)
        {
            foreach (var v in num)
            {
                foreach (var n in v)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
