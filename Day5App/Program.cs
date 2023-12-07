


using System.Collections;

class Program
{


    private static Dictionary<long, long> seedToSoilSourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> soilToFertilizerSourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> fertilizerToWaterSourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> waterToLightSourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> lightToTemperatureSourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> temperatureToHumiditySourceRange = new Dictionary<long, long>();
    private static Dictionary<long, long> humidityToLocationSourceRange = new Dictionary<long, long>();

    // Source range start, difference +
    private static Dictionary<long, long> seedToSoilDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> soilToFertilizerDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> fertilizerToWaterDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> waterToLightDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> lightToTemperatureDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> temperatureToHumidityDestination = new Dictionary<long, long>();
    private static Dictionary<long, long> humidityToLocationDestination = new Dictionary<long, long>();

    private static int seedToSoilLine = 3;
    private static int soilToFertilizerLine = 22;
    private static int fertilizerToWaterLine = 50;
    private static int waterToLightLine = 99;
    private static int lightToTemperatureLine = 109;
    private static int temperatureToHumidityLine = 126;
    private static int humidityToLocationLine = 168;

    private static string[] content = new string[0];

    // static void Main(string[] args)
    // {
    //     string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day5App\\Day5.txt"; // Replace with the actual file path
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
    //     Dictionary<long, long> rangesSeeds = new Dictionary<long, long>();
    //     string[] seedSplit = content[0].Split(" ");
    //     for (int i = 1; i < seedSplit.Length; i += 2)
    //     {
    //         rangesSeeds.Add(long.Parse(seedSplit[i]), long.Parse(seedSplit[i + 1]));
    //     }
    //
    //     for (int i = seedToSoilLine; i < soilToFertilizerLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         seedToSoilSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         seedToSoilDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = soilToFertilizerLine; i < fertilizerToWaterLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         soilToFertilizerSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         soilToFertilizerDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = fertilizerToWaterLine; i < waterToLightLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         fertilizerToWaterSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         fertilizerToWaterDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = waterToLightLine; i < lightToTemperatureLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         waterToLightSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         waterToLightDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = lightToTemperatureLine; i < temperatureToHumidityLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         lightToTemperatureSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         lightToTemperatureDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = temperatureToHumidityLine; i < humidityToLocationLine - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         temperatureToHumiditySourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         temperatureToHumidityDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //     for (int i = humidityToLocationLine; i < content.Length - 2; i++)
    //     {
    //         string[] line = content[i].Split(" ");
    //         humidityToLocationSourceRange.Add(long.Parse(line[1]), long.Parse(line[1]) + long.Parse(line[2]));
    //         humidityToLocationDestination.Add(long.Parse(line[1]), long.Parse(line[0]) - long.Parse(line[1]));
    //     }
    //
    //     long lowestValue = 100000000000000;
    //     foreach (var seed in rangesSeeds)
    //     {
    //         long lowestValueSeed = 10000000000000;
    //         for (long i = seed.Key; i < seed.Key + seed.Value; i++)
    //         {
    //             long temp = getLocationKey(i);
    //             if (temp < lowestValueSeed)
    //             {
    //                 lowestValueSeed = temp;
    //             }
    //         }
    //
    //         Console.WriteLine(lowestValueSeed);
    //         
    //         if (lowestValueSeed < lowestValue)
    //         {
    //             lowestValue = lowestValueSeed;
    //         }
    //     }
    //     
    //     Console.WriteLine(lowestValue);
    //     
    //     
    // }


//     private static long getLocationKey(long i)
//     {
//         long result = i;
//         foreach (var range in seedToSoilSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + seedToSoilDestination[range.Key];
//                 break;
//             }
//         }
//         foreach (var range in soilToFertilizerSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + soilToFertilizerDestination[range.Key];
//                 break;
//             }
//         }
//         foreach (var range in fertilizerToWaterSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + fertilizerToWaterDestination[range.Key];
//                 break;
//             }
//         }
//         foreach (var range in waterToLightSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + waterToLightDestination[range.Key];
//                 break;
//             }
//         }
//         foreach (var range in lightToTemperatureSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + lightToTemperatureDestination[range.Key];
//                 break;
//             }
//         }
//         foreach (var range in temperatureToHumiditySourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + temperatureToHumidityDestination[range.Key];
//                 break;
//             }
//         }
//
//         foreach (var range in humidityToLocationSourceRange)
//         {
//             if (range.Key <= result && range.Value > result)
//             {
//                 result = result + humidityToLocationDestination[range.Key];
//                 break;
//             }
//         }
//
//         return result;
//     }
}