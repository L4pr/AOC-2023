namespace Day18App;

public class part2
{
    private static string[] content = new string[0];


    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day18App\\Day18.txt"; // Replace with the actual file path

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

        long steps = 0;
        List<ValueTuple<long, long>> Coordinates = new List<(long, long)>();

        ValueTuple<long, long> currentCoords = (0, 0);

        foreach (var line in content)
        {
            string hexString = line.Split("#")[1].Split(")")[0];
            long hexNumber = Convert.ToInt32(hexString, 16);
            long direction = hexNumber & 0xf;
            long amountSteps = hexNumber >> 4;
            
            if (direction == 3)
            {
                currentCoords = (currentCoords.Item1 + amountSteps, currentCoords.Item2);
            }
            else if (direction == 1)
            {
                currentCoords = (currentCoords.Item1 - amountSteps, currentCoords.Item2);
            }
            else if (direction == 2)
            {
                currentCoords = (currentCoords.Item1, currentCoords.Item2 - amountSteps);
            }
            else
            {
                currentCoords = (currentCoords.Item1, currentCoords.Item2 + amountSteps);
            }
            
            Coordinates.Add(currentCoords);

            steps += amountSteps;
        }
        
        
        
        
        long som1 = 0;
        long som2 = 0;
        for (int i = 0; i < Coordinates.Count - 1; i++)
        {
            var Coordinate = (ValueTuple<long, long>)Coordinates[i];
            var Coordinate1 = (ValueTuple<long, long>)Coordinates[i + 1];
            som1 += Coordinate.Item1 * Coordinate1.Item2;
            som2 += Coordinate1.Item1 * Coordinate.Item2;
        }

        long result = (Math.Abs(som1 - som2) / 2) + (steps / 2) + 1;
        
        Console.WriteLine(result);
        
    }
}