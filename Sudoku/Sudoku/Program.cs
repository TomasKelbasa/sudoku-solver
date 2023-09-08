// See https://aka.ms/new-console-template for more information
using Sudoku;

Console.WriteLine("Hello, World!");
Sudoku.Sudoku.PrintNumbers(Sudoku.Sudoku.GetSudokuFromFile(@"C:\Users\tomas\Desktop\Sudoku_example.txt"));

Sudoku.Sudoku s = new Sudoku.Sudoku(Sudoku.Sudoku.GetSudokuFromFile(@"C:\Users\tomas\Desktop\Sudoku_example.txt"));

var start = DateTime.Now;
Console.WriteLine(s.Solve());
var finish = DateTime.Now;
Console.WriteLine("Finished in: " + (finish - start).TotalSeconds);

s.PrintNumbers();