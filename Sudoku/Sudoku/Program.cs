// See https://aka.ms/new-console-template for more information
using Sudoku;


// Old time for 50 sudoku: 53839,2957 ms
// New time for 50 sudoku: 42987,1667 ms
// Final time: 41929,3791 ms

List<Sudoku.Sudoku> sudokuList = new List<Sudoku.Sudoku>();

using (StreamReader sr = new StreamReader("./sudoku.txt"))
{
    string line = "";
    List<List<int>> nums = new List<List<int>>();
    sr.ReadLine();

    do
    {
        line = sr.ReadLine();
        if (line[0] != 'G')
        {
            nums.Add(line.ToCharArray().Select(a => a - 48).ToList());
        }
        else
        {
            sudokuList.Add(new Sudoku.Sudoku(nums));
            nums = new List<List<int>>();
        }
    } while (!sr.EndOfStream);
}



var start = DateTime.Now;


foreach (var sud in sudokuList)
{
    sud.Solve();
    sud.PrintNumbers();
}


var finish = DateTime.Now;
Console.WriteLine("\nFinished in: " + (finish - start).TotalMilliseconds + " ms");
