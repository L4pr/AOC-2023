// using System.Xml.Schema;
//
// namespace Day20App;
//
// public class part1
// {
//     private static string[] content = new string[0];
//
//
//     static void Main(string[] args)
//     {
//         string path =
//             "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day20App\\Day20.txt"; // Replace with the actual file path
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
//         
//         List<string> outputsBroadcast = new List<string>();
//
//         foreach (var line in content)
//         {
//             if (line[0] == '%')
//             {
//                 string name = line.Split(" -> ")[0].Substring(1);
//                 kindOfSwitch.Add(name , "flip");
//                 List<string> outputs = new List<string>();
//                 foreach (var output in line.Split(" -> ")[1].Split(", "))
//                 {
//                     outputs.Add(output);
//                 }
//                 FlipFlop.Add(name, (false, outputs));
//             }
//             else if (line[0] == '&')
//             {
//                 string name = line.Split(" -> ")[0].Substring(1);
//                 kindOfSwitch.Add(name , "con");
//                 List<string> outputs = new List<string>();
//                 foreach (var output in line.Split(" -> ")[1].Split(", "))
//                 {
//                     outputs.Add(output);
//                 }
//                 Dictionary<string, string> memoryTable = new Dictionary<string, string>();
//                 Conjunction.Add(name, (memoryTable, outputs));
//             }
//             else
//             {
//                 foreach (var output in line.Split(" -> ")[1].Split(", "))
//                 {
//                     outputsBroadcast.Add(output);
//                 }
//             }
//         }
//
//         foreach (var temp in FlipFlop)  
//         {
//             foreach (var value in temp.Value.Item2)
//             {
//                 if (Conjunction.ContainsKey(value))
//                 {
//                     Conjunction[value].Item1.TryAdd(temp.Key, "low");
//                 }
//             }
//         }
//
//
//         
//         
//         (int, int) total = (0, 0);
//         for (int i = 0; i < 1000; i++)
//         {
//             var temp = runPulses(outputsBroadcast);
//             total.Item1 += temp.Item1;
//             total.Item2 += temp.Item2;
//         }
//         Console.WriteLine(total.Item1 * total.Item2);
//     }
//
//     static Dictionary<string, string> kindOfSwitch = new Dictionary<string, string>();
//     static Dictionary<string, (Boolean, List<string>)> FlipFlop = new Dictionary<string, (Boolean, List<string>)>();
//     // name, (memoryTable, outputs)
//     // memoryTable: (nameInput, typePulse)
//     static Dictionary<string, (Dictionary<string, string>, List<string>)> Conjunction = 
//         new Dictionary<string, (Dictionary<string, string>, List<string>)>();
//
//
//     private static (int, int) runPulses(List<string> outputsBroadcast)
//     {
//         int HighPulses = 0;
//         int LowPulses = 1;
//         
//         Queue<(string, string, string)> queue = new Queue<(string, string, string)>();
//
//         foreach (var output in outputsBroadcast)
//         {
//             queue.Enqueue((output, "low", "broadcast"));
//         }
//
//         while (queue.Count > 0)
//         {
//             Boolean isLow = true;
//             (string, string, string) item = queue.Dequeue();
//             if (item.Item2 == "low")
//             {
//                 LowPulses += 1;
//             }
//             else
//             {
//                 HighPulses += 1;
//                 isLow = false;
//             }
//
//             if (!kindOfSwitch.ContainsKey(item.Item1))
//             {
//                 continue;
//             }
//             
//             if (kindOfSwitch[item.Item1] == "flip")
//             {
//                 if (isLow)
//                 {
//                     var valueTuple = FlipFlop[item.Item1];
//                     if (valueTuple.Item1)
//                     {
//                         foreach (var temp in valueTuple.Item2)
//                         {
//                             queue.Enqueue((temp, "low", item.Item1));
//                         }
//
//                         valueTuple.Item1 = false;
//                     }
//                     else
//                     {
//                         foreach (var temp in valueTuple.Item2)
//                         {
//                             queue.Enqueue((temp, "high", item.Item1));
//                         }
//
//                         valueTuple.Item1 = true;
//                     }
//
//                     FlipFlop[item.Item1] = valueTuple;
//                 }
//             }
//             else
//             {
//                 Conjunction[item.Item1].Item1[item.Item3] = item.Item2;
//                 Boolean allHigh = true;
//                 foreach (var dic in Conjunction[item.Item1].Item1)
//                 {
//                     if (dic.Value != "high")
//                     {
//                         allHigh = false;
//                         break;
//                     }
//                 }
//                 
//                 var valueTuple = Conjunction[item.Item1];
//                 if (allHigh)
//                 {
//                     foreach (var temp in valueTuple.Item2)
//                     {
//                         queue.Enqueue((temp, "low", item.Item1));
//                     }
//                 }
//                 else
//                 {
//                     foreach (var temp in valueTuple.Item2)
//                     {
//                         queue.Enqueue((temp, "high", item.Item1));
//                     }
//                 }
//             }
//         }
//
//         
//         (int, int) result = (LowPulses, HighPulses);
//         return result;
//     }
// }