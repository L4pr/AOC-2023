// namespace Day13App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//     Random random = new Random();
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day13App\\Day13.txt"; // Replace with the actual file path
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
//         List<string[]> squares = new List<string[]>();
//         List<string> temp = new List<string>();
//         string[] tempString;
//         foreach (var line in content)
//         {
//             if (line == "")
//             {
//                 tempString = new string[temp.Count];
//                 for (int i = 0; i < temp.Count; i++)
//                 {
//                     tempString[i] = temp[i];
//                 }
//                 squares.Add(tempString);
//                 temp.Clear();
//             }
//             else
//             {
//                 temp.Add(line);   
//             }
//         }
//         tempString = new string[temp.Count];
//         for (int i = 0; i < temp.Count; i++)
//         {
//             tempString[i] = temp[i];
//         }
//         squares.Add(tempString);
//
//
//         Boolean matching = false;
//         int total = 0;
//         foreach (var square in squares)
//         {
//             for (int i = 0; i < square.Length - 1; i++)
//             {
//                 if (square[i] == square[i + 1] && matching == false)
//                 {
//                     matching = false;
//                     for (int j = 0; i + j + 1 < square.Length - 1 || i - j >= 0; j++)
//                     {
//                         if (i + j + 1 > square.Length - 1)
//                         {
//                             matching = true;
//                         } 
//                         else if (i - j < 0)
//                         {
//                             break;
//                         }
//                         else if (square[i - j] == square[i + j + 1])
//                         {
//                             matching = true;
//                         }
//                         else
//                         {
//                             matching = false;
//                             break;
//                         }
//                     }
//                 }
//                 if (matching)
//                 {
//                     total += (i + 1) * 100;
//                     break;
//                 }
//             }
//
//
//             string[] rotatedSquare = new string[square[0].Length];
//
//             foreach (var line in square)
//             {
//                 for (int i = 0; i < line.Length; i++)
//                 {
//                     rotatedSquare[i] += line[i];
//                 }
//             }
//             
//             matching = false;
//             for (int i = 0; i < rotatedSquare.Length - 1; i++)
//             {
//                 if (rotatedSquare[i] == rotatedSquare[i + 1] && matching == false)
//                 {
//                     matching = false;
//                     for (int j = 0; i + j + 1 < rotatedSquare.Length - 1 || i - j >= 0; j++)
//                     {
//                         if (i + j + 1 > rotatedSquare.Length - 1)
//                         {
//                             matching = true;
//                         } 
//                         else if (i - j < 0)
//                         {
//                             break;
//                         }
//                         else if (rotatedSquare[i - j] == rotatedSquare[i + j + 1])
//                         {
//                             matching = true;
//                         }
//                         else
//                         {
//                             matching = false;
//                             break;
//                         }
//                     }
//                 }
//                 if (matching)
//                 {
//                     matching = false;
//                     total += (i + 1);
//                     break;
//                 }
//             }
//             
//         }
//         
//         
//         Console.WriteLine(total);
//     }
// }