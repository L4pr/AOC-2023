// namespace Day14App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day14App\\Day14.txt"; // Replace with the actual file path
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
//
//         int total = 0;
//         for (int i = 0; i < content[0].Length; i++)
//         {
//             int amountWhiteSpace = 0;
//             List<int> column = new List<int>();
//             for (int j = 0; j < content.Length; j++)
//             {
//                 if (content[j][i] == 'O')
//                 {
//                     column.Add(1);
//                 }
//                 else if (content[j][i] == '#')
//                 {
//                     for (int k = 0; k < amountWhiteSpace; k++)
//                     {
//                         column.Add(0);
//                     }
//                     
//                     column.Add(0);
//                     
//                     amountWhiteSpace = 0;
//                 }
//                 else
//                 {
//                     amountWhiteSpace += 1;
//                 }
//             }
//
//             foreach (var VARIABLE in column)
//             {
//                 Console.Write(VARIABLE);
//             }
//             Console.WriteLine(" ");
//             int pointAmount = content.Length;
//             foreach (var line in column)
//             {
//                 total += line * pointAmount;
//
//
//                 pointAmount -= 1;
//             }
//         }
//
//         Console.WriteLine(total);
//     }
// }