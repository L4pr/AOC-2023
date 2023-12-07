using System.Text.RegularExpressions;

namespace Day6App;

public class part2
{
    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day6App\\Day6.txt"; // Replace with the actual file path

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


        string timeString = "";
        string distanceString = "";
        for (long i = 1; i < Regex.Split(content[0], @"\s+").Length; i++)
        {
            timeString = timeString + Regex.Split(content[0], @"\s+")[i];
            distanceString = distanceString + Regex.Split(content[1], @"\s+")[i];
        }

        long time = long.Parse(timeString);
        long distance = long.Parse(distanceString);


        long scorePerTime = 0;
        for (long j = 0; j <= time; j++)
        {
            long distanceTraveled = (time - j) * j;
            if (distanceTraveled > distance)
            {
                scorePerTime += 1;
            }
        }

        Console.WriteLine(scorePerTime);
    }
}