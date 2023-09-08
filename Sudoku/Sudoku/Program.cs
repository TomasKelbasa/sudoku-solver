// See https://aka.ms/new-console-template for more information
using Sudoku;

Console.WriteLine("Hello, World!");

Sudoku.Sudoku s = new Sudoku.Sudoku(Sudoku.Sudoku.GetSudokuFromFile(@"C:\Users\tomas\Desktop\Hard sudoku.txt"));
s.PrintNumbers();

var start = DateTime.Now;
s.Solve();
var finish = DateTime.Now;
Console.WriteLine("\nFinished in: " + (finish - start).TotalMilliseconds + " ms");
Console.WriteLine("Solved Sudoku: ");

s.PrintNumbers();