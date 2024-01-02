// namespace Day18App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day18App\\Day18.txt"; // Replace with the actual file path
//
//         try
//         {
//             // Read all text from the file in one operation
//             content = File.ReadAllLines(path);
//
//
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
//         int steps = 0;
//         List<ValueTuple<int, int>> Coordinates = new List<(int, int)>();
//
//         ValueTuple<int, int> currentCoords = (0, 0);
//
//         foreach (var line in content)
//         {
//             string direction = line.Split(" ")[0];
//             int amountSteps = int.Parse(line.Split(" ")[1]);
//             ValueTuple<int, int> numberDirection;
//             if (direction == "U")
//             {
//                 numberDirection = (1, 0);
//                 currentCoords = (currentCoords.Item1 + amountSteps, currentCoords.Item2);
//             }
//             else if (direction == "D")
//             {
//                 numberDirection = (-1, 0);
//                 currentCoords = (currentCoords.Item1 - amountSteps, currentCoords.Item2);
//             }
//             else if (direction == "L")
//             {
//                 numberDirection = (0, -1);
//                 currentCoords = (currentCoords.Item1, currentCoords.Item2 - amountSteps);
//             }
//             else
//             {
//                 numberDirection = (0, 1);
//                 currentCoords = (currentCoords.Item1, currentCoords.Item2 + amountSteps);
//             }
//             
//             Coordinates.Add(currentCoords);
//
//             steps += amountSteps;
//         }
//         
//         
//         
//         
//         int som1 = 0;
//         int som2 = 0;
//         for (int i = 0; i < Coordinates.Count - 1; i++)
//         {
//             var Coordinate = (ValueTuple<int, int>)Coordinates[i];
//             var Coordinate1 = (ValueTuple<int, int>)Coordinates[i + 1];
//             som1 += Coordinate.Item1 * Coordinate1.Item2;
//             som2 += Coordinate1.Item1 * Coordinate.Item2;
//         }
//
//         int result = (Math.Abs(som1 - som2) / 2) + (steps / 2) + 1;
//         
//         Console.WriteLine(result);
//         
//     }
// }