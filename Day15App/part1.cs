// namespace Day15App;
//
// public class part1
// {
//     private static string[] content2 = new string[0];
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day15App\\Day15.txt"; // Replace with the actual file path
//
//         try
//         {
//             // Read all text from the file in one operation
//             content2 = File.ReadAllLines(path);
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
//         string[] content = content2[0].Split(",");
//
//         long total = 0;
//         long result = 0;
//         foreach (var value in content)
//         {
//             result = 0;
//             foreach (var character in value)
//             {
//                 result = ((result + ((int)character)) * 17) % 256;
//             }
//             total += result;
//         }
//         
//         Console.WriteLine(total);
//     }
// }