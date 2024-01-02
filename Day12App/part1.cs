// namespace Day12App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//     Random random = new Random();
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day12App\\Day12.txt"; // Replace with the actual file path
//
//         try
//         {
//             // Read all text from the file in one operation
//             content = File.ReadAllLines(path);
//
//             Console.WriteLine(content);
//         }
//         catch (IOException e)
//         {
//             Console.WriteLine("An IO exception has been thrown!");
//             Console.WriteLine(e.ToString());
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine("A general exception has been thrown!");
//             Console.WriteLine(e.ToString());
//         }
//
//         int total = 0;
//
//         foreach (var line in content)
//         {
//             string configuration = line.Split(" ")[0];
//             List<int> numbers = new List<int>();
//             foreach (var number in line.Split(" ")[1].Split(","))
//             {
//                 numbers.Add(int.Parse(number));
//             }
//
//             total += checkAllConfigurations(configuration, numbers);
//         }
//         
//         Console.WriteLine(total);
//     }
//
//     // returns amount of valid configurations
//     private static int checkAllConfigurations(string configuration, List<int> numbers)
//     {
//         int totalBroken = 0;
//         foreach (var number in numbers)
//         {
//             totalBroken += number;
//         }
//
//         int amountBroken = 0;
//         int amountUnknown = 0;
//         foreach (var spring in configuration)
//         {
//             if (spring == '#')
//             {
//                 amountBroken += 1;
//             }
//             else if (spring == '?')
//             {
//                 amountUnknown += 1;
//             }
//         }
//
//         int amountUnknownToBroken = totalBroken - amountBroken;
//         
//         
//
//         List<int> CombinationList = new List<int>();
//         CombinationList = GenerateCombinations(amountUnknown, amountUnknownToBroken);
//         
//         int amountValidConfigurations = 0;
//         foreach (var CombinationInt in CombinationList)
//         {
//             amountBroken = 0;
//             int positionInCombinationInt = 0;
//             string tryCombination = "";
//             for (int j = 0; j < configuration.Length; j++)
//             {
//                 if (configuration[j] == '#')
//                 {
//                     tryCombination += "#";
//                 }
//                 else if (configuration[j] == '.')
//                 {
//                     tryCombination += ".";
//                 }
//                 else if (configuration[j] == '?')
//                 {
//                     if (amountBroken < amountUnknownToBroken)
//                     {
//                         if (((CombinationInt >> (amountUnknown - positionInCombinationInt - 1)) & 1) == 1)
//                         {
//                             tryCombination += "#";
//                             amountBroken += 1;
//                         }
//                         else
//                         {
//                             tryCombination += ".";
//                         }
//                         
//                         positionInCombinationInt += 1;
//                     }
//                     else
//                     {
//                         tryCombination += ".";
//                     }
//                 }
//             }
//
//             if (checkIfValidConfiguration(tryCombination, numbers))
//             {
//                 amountValidConfigurations += 1;
//             }
//         }
//         
//         
//         
//         
//         
//         return amountValidConfigurations;
//     }
//
//
//     private static Boolean checkIfValidConfiguration(string configuration, List<int> numbers)
//     {
//         int indexNumbers = 0;
//         bool lastValueBroken = false;
//         int amountBrokenInARow = 0;
//         foreach (var spring in configuration)
//         {
//             if (indexNumbers < numbers.Count)
//             {
//                 if (spring == '#')
//                 {
//                     amountBrokenInARow += 1;
//                     if (!lastValueBroken)
//                     {
//                         lastValueBroken = true;
//                     }
//                 } 
//                 else if (spring == '.')
//                 {
//                     if (lastValueBroken)
//                     {
//                         lastValueBroken = false;
//                         if (amountBrokenInARow != numbers[indexNumbers])
//                         {
//                             return false;
//                         }
//
//                         amountBrokenInARow = 0;
//                         indexNumbers += 1;
//                     }
//                 }
//             }
//             else
//             {
//                 if (spring == '#')
//                 {
//                     return false;
//                 }
//             }
//         }
//
//         if (lastValueBroken)
//         {
//             if (amountBrokenInARow != numbers[indexNumbers])
//             {
//                 return false;
//             }
//         }
//
//
//
//         return true;
//     }
//     
//     private static List<int> GenerateCombinations(int bitLength, int onesCount)
//     {
//         var combinations = new List<int>();
//         GenerateCombinationsRecursive(0, 0, bitLength, onesCount, combinations);
//         return combinations;
//     }
//
//     private static void GenerateCombinationsRecursive(int current, int position, int bitLength, int onesCount, List<int> combinations)
//     {
//         if (onesCount == 0)
//         {
//             combinations.Add(current);
//             return;
//         }
//         if (position == bitLength)
//         {
//             return;
//         }
//
//         // Place a '1' in the current position
//         GenerateCombinationsRecursive(current | (1 << position), position + 1, bitLength, onesCount - 1, combinations);
//
//         // Don't place a '1' and continue if more 1's can be placed
//         if (bitLength - position > onesCount)
//         {
//             GenerateCombinationsRecursive(current, position + 1, bitLength, onesCount, combinations);
//         }
//     }
// }