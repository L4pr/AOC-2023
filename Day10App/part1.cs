using System.Collections;
using System.Diagnostics;

namespace Day10App;

public class part1
{
    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day10App\\Day10.txt"; // Replace with the actual file path

        try
        {
            // Read all text from the file in one operation
            content = File.ReadAllLines(path);

            Console.WriteLine(content);
        }
        catch (IOException e)
        {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("A general exception has been thrown!");
            Console.WriteLine(e.ToString());
        }

        var startCoords = (i: 0, j: 0);
        var currentCoords = (i: 0, j: 0);

        for (int i = 0; i < content.Length; i++)
        {
            for (int j = 0; j < content[i].Length; j++)
            {
                if (content[i][j] == 'S')
                {
                    startCoords.i = i;
                    startCoords.j = j;

                    goto endLoops;
                }
            }
        }

        endLoops:
        var direction = (1, 0);
        var positionChar = content[startCoords.i + direction.Item1][startCoords.j + direction.Item2];
        if (positionChar == '|' || positionChar == '7' || positionChar == 'F')
        {
            currentCoords.i = startCoords.i + 1;
            currentCoords.j = startCoords.j;
        }
        else
        {
            direction = (0, 1);
            positionChar = content[startCoords.i + direction.Item1][startCoords.j + direction.Item2];
            if (positionChar == '-' || positionChar == '7' || positionChar == 'J')
            {
                currentCoords.i = startCoords.i;
                currentCoords.j = startCoords.j + 1;
            }
            else
            {
                direction = (-1, 0);
                positionChar = content[startCoords.i + direction.Item1][startCoords.j + direction.Item2];
                if (positionChar == '|' || positionChar == 'J' || positionChar == 'L')
                {
                    currentCoords.i = startCoords.i - 1;
                    currentCoords.j = startCoords.j;
                }
                else
                {
                    return;
                }
            } 
        }

        ArrayList Coordinates = new ArrayList();
        Coordinates.Add(startCoords);


        int steps = 0;

        while (true)
        {
            positionChar = content[currentCoords.i][currentCoords.j];
            switch (positionChar)
            {
                case '|':
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
                case '-':
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
                case '7':
                    direction = (direction.Item2, direction.Item1);
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
                case 'L':
                    direction = (direction.Item2, direction.Item1);
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
                case 'F':
                    direction = (-direction.Item2, -direction.Item1);
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
                case 'J':
                    direction = (-direction.Item2, -direction.Item1);
                    currentCoords.i = currentCoords.i + direction.Item1;
                    currentCoords.j = currentCoords.j + direction.Item2;
                    break;
            }

            var CoordinateSend = (currentCoords.i, currentCoords.j);
            Coordinates.Add(CoordinateSend);

            steps += 1;
            
            if (startCoords.Equals(currentCoords))
            {
                break;
            }
        }

        Coordinates.Add(startCoords);

        int som1 = 0;
        int som2 = 0;
        for (int i = 0; i < Coordinates.Count - 1; i++)
        {
            var Coordinate = (ValueTuple<int, int>)Coordinates[i];
            var Coordinate1 = (ValueTuple<int, int>)Coordinates[i + 1];
            som1 += Coordinate.Item1 * Coordinate1.Item2;
            som2 += Coordinate1.Item1 * Coordinate.Item2;
        }

        int result = (Math.Abs(som1 - som2) / 2) - (steps / 2);
        
        Console.WriteLine(result);
    }
    
    
    
}