using System.Collections;
using System.Diagnostics;

namespace Day5App;

public class Program2
{
    
    private static string[] content = new string[0];
    
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day5App\\Day5.txt"; // Replace with the actual file path

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
        
        Dictionary<long, long> rangesSeeds = new Dictionary<long, long>();
        string[] seedSplit = content[0].Split(" ");
        for (int i = 1; i < seedSplit.Length; i += 2)
        {
            rangesSeeds.Add(long.Parse(seedSplit[i]), long.Parse(seedSplit[i]) + long.Parse(seedSplit[i + 1]));
        }

        ArrayList data = new ArrayList();
        
        
        long[][] result = new long[content.Length][];
        
        int seedToSoilLine = 3;
        int soilToFertilizerLine = 22;
        int fertilizerToWaterLine = 50;
        int waterToLightLine = 99;
        int lightToTemperatureLine = 109;
        int temperatureToHumidityLine = 126;
        int humidityToLocationLine = 168;
        
        for (int i = 3; i < content.Length; i++)
        {
            string[] numbers = content[i].Split(' ');
            if (numbers.Length > 2)
            {
                result[i] = new long[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    result[i][j] = long.Parse(numbers[j]);
                }
            }
        }

        long rightLocation = 0;
        for (long i = 0; i < 10000000000; i++)
        {
            long location = i;
            for (long j = humidityToLocationLine; j < 192; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = temperatureToHumidityLine; j < humidityToLocationLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = lightToTemperatureLine; j < temperatureToHumidityLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = waterToLightLine; j < lightToTemperatureLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = fertilizerToWaterLine; j < waterToLightLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = soilToFertilizerLine; j < fertilizerToWaterLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }
            for (long j = seedToSoilLine; j < soilToFertilizerLine - 2; j++)
            {
                long temp = result[j][0];
                if (location >= temp)
                {
                    long temp2 = result[j][0] + result[j][2];
                    if (location < temp2)
                    {
                        location = location + (result[j][1] - result[j][0]);
                        break;
                    }
                }
            }

            foreach (var rangeSeed in rangesSeeds)
            {
                if (location > rangeSeed.Key && location < rangeSeed.Value)
                {
                    Console.WriteLine("The number is: " + i);
                    stopwatch.Stop();
                    Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
                    Environment.Exit(0);
                }
            }
        }
    }
}