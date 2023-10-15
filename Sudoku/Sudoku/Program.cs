// See https://aka.ms/new-console-template for more information
using Sudoku;


// Old time for 50 sudoku: 53839,2957 ms
// New time for 50 sudoku: 

List<Sudoku.Sudoku> sudokuList = new List<Sudoku.Sudoku>();

using (StreamReader sr = new StreamReader("./sudoku.txt"))
{
    string line = "";
    Sudoku.Sudoku s = new Sudoku.Sudoku();
    List<List<int>> nums = new List<List<int>>();
    do
    {
        line = sr.ReadLine();
        if (line[0] != 'G')
        {
            nums.Add(line.ToCharArray().Select(a => a - 48).ToList());
        }
        else
        {
            s.Numbers = nums;
            sudokuList.Add(s);
            s = new Sudoku.Sudoku();
            nums = new List<List<int>>();
        }
    } while (!sr.EndOfStream);
}

sudokuList.Remove(sudokuList[0]);


var start = DateTime.Now;


foreach (var sud in sudokuList)
{
    sud.Solve();
    sud.PrintNumbers();
}


var finish = DateTime.Now;
Console.WriteLine("\nFinished in: " + (finish - start).TotalMilliseconds + " ms");
