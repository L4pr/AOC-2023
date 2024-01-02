// using System.Collections;
// using System.Runtime.InteropServices.JavaScript;
//
// namespace Day11App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//     
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day11App\\Day11.txt"; // Replace with the actual file path
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
//         List<string> data = new List<string>();
//         foreach (var line in content)
//         {
//             data.Add(line);
//         }
//     
//         string dotLine = "";
//         for (int i = 0; i < content[0].Length; i++)
//         {
//             dotLine += ".";
//         }
//     
//         for (int i = 0; i < data.Count; i++)
//         {
//             if (data[i].Equals(dotLine))
//             {
//                 data.Insert(i, dotLine);
//                 i++;
//             }
//         }
//     
//     
//         int k = 0;
//         while (true)
//         {
//             bool checkAllDot = data.All(s => s[k].Equals('.'));
//             if (checkAllDot)
//             {
//                 for (int j = 0; j < data.Count; j++)
//                 {
//                     data[j] = data[j].Insert(k, ".");
//                 }
//     
//                 k++;
//             }
//     
//             k++;
//             if (k == data[0].Length)
//             {
//                 break;
//             }
//             
//         }
//     
//         List<ValueTuple<int, int>> CoordsGalaxy = new List<ValueTuple<int, int>>();
//     
//         for (int i = 0; i < data.Count; i++)
//         {
//             for (int j = 0; j < data[0].Length; j++)
//             {
//                 if (data[i][j] == '#')
//                 {
//                     CoordsGalaxy.Add((i, j));
//                 }
//             }
//         }
//     
//     
//         int total = 0;
//         for (int i = 0; i < CoordsGalaxy.Count; i++)
//         {
//             for (int j = i; j < CoordsGalaxy.Count; j++)
//             {
//                 total += (Math.Abs(CoordsGalaxy[i].Item1 - CoordsGalaxy[j].Item1) + Math.Abs(CoordsGalaxy[i].Item2 - CoordsGalaxy[j].Item2));
//             }
//         }
//         
//         Console.WriteLine("result: " + total);
//     }
// }