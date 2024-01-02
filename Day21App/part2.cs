namespace Day21App;

public class part2
{
    private static string[] content = new string[0];


    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day21App\\Day21.txt"; // Replace with the actual file path

        try
        {
            // Read all text from the file in one operation
            content = File.ReadAllLines(path);


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

        (int, int) homeCoordinates = (0,0);
        for (int i = 0; i < content.Length; i++)
        {
            for (int j = 0; j < content[0].Length; j++)
            {
                if (content[i][j] == 'S')
                {
                    homeCoordinates = (i, j);
                    break;
                }
            }

            if (homeCoordinates != (0, 0))
            {
                break;
            }
        }

        string newString = "";
        for (int i = 0; i < content[0].Length; i++)
        {
            if (i == homeCoordinates.Item2)
            {
                newString += '.';
            }
            else
            {
                newString += content[homeCoordinates.Item1][i];
            }
        }

        List<(int, int)> coordinates = new List<(int, int)>();
        coordinates.Add(homeCoordinates);
        
        for (int i = 0; i < 1000; i++)
        {
            coordinates = moveOneStep(coordinates);
        }

        Console.WriteLine(coordinates.Count);

    }

    private static List<(int, int)> moveOneStep(List<(int, int)> input)
    {
        List<(int, int)> newCoordinates = new List<(int, int)>();
        
        foreach (var Coordinate in input)
        {
            if (content[Math.Abs(Coordinate.Item1 + 1) % 11][Math.Abs(Coordinate.Item2) % 11] != '#' &
                !newCoordinates.Contains((Coordinate.Item1 + 1, Coordinate.Item2))) 
            {
                newCoordinates.Add((Coordinate.Item1 + 1, Coordinate.Item2));
            }
            if (content[Math.Abs(Coordinate.Item1 - 1) % 11][Math.Abs(Coordinate.Item2) % 11] != '#' &
                     !newCoordinates.Contains((Coordinate.Item1 - 1, Coordinate.Item2))) 
            {
                newCoordinates.Add((Coordinate.Item1 - 1, Coordinate.Item2));
            }
            if (content[Math.Abs(Coordinate.Item1) % 11][Math.Abs(Coordinate.Item2 + 1) % 11] != '#' &
                     !newCoordinates.Contains((Coordinate.Item1, Coordinate.Item2 + 1))) 
            {
                newCoordinates.Add((Coordinate.Item1, Coordinate.Item2 + 1));
            }
            if (content[Math.Abs(Coordinate.Item1) % 11][Math.Abs(Coordinate.Item2 - 1) % 11] != '#' &
                     !newCoordinates.Contains((Coordinate.Item1, Coordinate.Item2 - 1))) 
            {
                newCoordinates.Add((Coordinate.Item1, Coordinate.Item2 - 1));
            }
        }


        return newCoordinates;

    }
}