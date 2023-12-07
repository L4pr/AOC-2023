



using System.Collections;
using System.Text.RegularExpressions;

public class Program2
{

    private static string[] content = new string[0];

    // static void Main(string[] args)
    // {
    //     string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day6App\\Day6.txt"; // Replace with the actual file path
    //
    //     try
    //     {
    //         // Read all text from the file in one operation
    //         content = File.ReadAllLines(path);
    //
    //         Console.WriteLine(content);
    //     }
    //     catch (IOException e)
    //     {
    //         Console.WriteLine("An IO exception has been thrown!");
    //         Console.WriteLine(e.ToString());
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine("A general exception has been thrown!");
    //         Console.WriteLine(e.ToString());
    //     }
    //
    //
    //     Console.WriteLine(content[0]);
    //     Console.WriteLine(content[1]);
    //
    //
    //     ArrayList Times = new ArrayList();
    //     ArrayList Distances = new ArrayList();
    //     for (int i = 1; i < Regex.Split(content[0], @"\s+").Length; i++)
    //     {
    //         Times.Add(int.Parse(Regex.Split(content[0], @"\s+")[i]));
    //         Distances.Add(int.Parse(Regex.Split(content[1], @"\s+")[i]));
    //     }
    //
    //
    //     int totalResult = 1;
    //     
    //     for (int i = 0; i < Times.Count; i++)
    //     {
    //         int scorePerTime = 0;
    //         for (int j = 0; j <= (int)Times[i]; j++)
    //         {
    //             int time = (int)Times[i];
    //             int distanceTraveled = (time - j) * j;
    //             if (distanceTraveled > (int)Distances[i])
    //             {
    //                 scorePerTime += 1;
    //             }
    //         }
    //         Console.WriteLine(scorePerTime);
    //         totalResult = totalResult * scorePerTime;
    //
    //     }
    //
    //     Console.WriteLine(totalResult);
    // }
}
