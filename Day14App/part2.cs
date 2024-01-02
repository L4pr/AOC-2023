using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day14App
{
    public class Part2
    {
        private static char[][] content = new char[0][];
        private static Dictionary<string, int> _trace = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day14App\\Day14.txt"; // Replace with the actual file path

            try
            {
                // Read all text from the file and convert to char[][]
                content = File.ReadAllLines(path).Select(line => line.ToCharArray()).ToArray();
            }
            catch (IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("A general exception has been thrown!");
                Console.WriteLine(e.ToString());
                return;
            }

            char[][] grid = Cycle(content);
            
            for (int i = 1; i < 1000000000; i++)
            {
                grid = Cycle(grid);
                string gridKey = GetStringRepresentation(grid);

                if (_trace.TryGetValue(gridKey, out var start))
                {
                    int period = i - start;
                    int offset = (1000000000 - 1 - start) % period;
                    for (int j = 0; j < offset; j++)
                    {
                        grid = Cycle(grid);
                    }
                    break;
                }

                _trace[gridKey] = i;
            }

            int total = 0;
            int pointAmount = content.Length;
            foreach (var line in grid)
            {
                foreach (var character in line)
                {
                    if (character == 'O')
                    {
                        total += pointAmount;
                    }
                }

                pointAmount -= 1;
            }

            Console.WriteLine($"Total: {total}");
        }

        private static char[][] Cycle(char[][] content)
        {
            char[][] grid = TiltNorth(content);
            grid = RotateClockwise(grid);
            grid = TiltNorth(grid);
            grid = RotateClockwise(grid);
            grid = TiltNorth(grid);
            grid = RotateClockwise(grid);
            grid = TiltNorth(grid);
            grid = RotateClockwise(grid);
            return grid;
        }

        private static char[][] RotateClockwise(char[][] content)
        {
            int newRows = content[0].Length;
            int newCols = content.Length;

            char[][] rotated = new char[newRows][];
            for (int i = 0; i < newRows; i++)
            {
                rotated[i] = new char[newCols];
                for (int j = 0; j < newCols; j++)
                {
                    rotated[i][j] = content[newCols - 1 - j][i];
                }
            }

            return rotated;
        }

        private static char[][] TiltNorth(char[][] content)
        {
            int rows = content.Length;
            int cols = content[0].Length;

            char[][] grid = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = new char[cols];
                Array.Fill(grid[i], '.');
            }

            for (int col = 0; col < cols; col++)
            {
                int amountWhiteSpace = 0;
                int placeInColumn = 0;
                for (int row = 0; row < rows; row++)
                {
                    char currentChar = content[row][col];
                    if (currentChar == 'O')
                    {
                        grid[placeInColumn][col] = 'O';
                        placeInColumn++;
                    } 
                    else if (currentChar == '#')
                    {
                        for (int k = 0; k < amountWhiteSpace; k++)
                        {
                            placeInColumn++;
                        }
                        
                        grid[placeInColumn][col] = '#';
                        
                        placeInColumn++;
                        amountWhiteSpace = 0;
                    }
                    else
                    {
                        amountWhiteSpace += 1;
                    }
                }
            }

            return grid;
        }

        // Helper method to convert a char[][] to a single string for dictionary key
        private static string GetStringRepresentation(char[][] grid)
        {
            return string.Join("\n", grid.Select(row => new string(row)));
        }
    }
}
