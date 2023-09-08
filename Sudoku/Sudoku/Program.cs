// See https://aka.ms/new-console-template for more information
using Sudoku;

string defaultFilePath = @"C:\Users\tomas\Desktop\Hard sudoku.txt";

if (args.Length > 0)
{
    if (File.Exists(args[0]))
    {
        defaultFilePath = args[0];
    }
    else
    {
        Console.WriteLine("File not found, proceeding with default file");
    }

}


Sudoku.Sudoku s = new Sudoku.Sudoku(Sudoku.Sudoku.GetSudokuFromFile(defaultFilePath));
s.PrintNumbers();

var start = DateTime.Now;
s.Solve();
var finish = DateTime.Now;
Console.WriteLine("\nFinished in: " + (finish - start).TotalMilliseconds + " ms");
Console.WriteLine("Solved Sudoku: ");

s.PrintNumbers();