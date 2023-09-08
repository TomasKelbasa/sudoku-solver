// See https://aka.ms/new-console-template for more information
using Sudoku;

Console.WriteLine("Hello, World!");
Sudoku.Sudoku.PrintNumbers(Sudoku.Sudoku.GetSudokuFromFile(@"C:\Users\tomas\Desktop\Sudoku_example.txt"));
Console.WriteLine(Sudoku.Sudoku.Validate(Sudoku.Sudoku.GetSudokuFromFile(@"C:\Users\tomas\Desktop\Sudoku_example.txt")));