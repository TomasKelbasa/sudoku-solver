using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Sudoku
    {

        public List<List<int>> Numbers { get; set; }

        public Sudoku() { }

        public static bool ValidateRow(List<int> r)
        {
            List<int> row = new List<int>();
            foreach(var o in r)
            {
                row.Add(o);
            }
            if(row.Count != 9) return false;
            for(int i  = 0; i < row.Count; i++)
            {
                if (row[i] == 0) row.RemoveAt(i);
            }

            if(row.Equals(row.Distinct())) return true;
            return false;
        }

        public static bool Validate(List<List<int>> num)
        {
            List<List<int>> numbers = DeepClone(num);
            foreach(var i in numbers)
            {
                if(!ValidateRow(i)) return false;
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                List<int> list = new List<int>();
                for(int e = 0; e < numbers.Count; e++)
                {
                    list.Add(numbers[e][i]);
                }
                if(!ValidateRow(list)) return false;
            }

            for(int a = 0; a < 3; a++)
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

            }
            else
            {
                throw new FileNotFoundException(filename);
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
    }
}
