using System.Collections;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Day8App;

public class part1
{
    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day8App\\Day8.txt"; // Replace with the actual file path

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

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string LRInstruction = content[0];

        Dictionary<string, string[]> Instructions = new Dictionary<string, string[]>();
        
        for (int i = 2; i < content.Length; i++)
        {
            string line = content[i];
            string input = line.Split(" = ")[0];
            string[] LR = line.Split("(")[1].Split(")")[0].Split(", ");
            Instructions.Add(input, LR);
        }

        ArrayList startPos = new ArrayList();
        foreach (var temp in Instructions)
        {
            if (temp.Key[2] == 'A')
            {
                startPos.Add(temp.Key);
            }
        }



        ArrayList periods = new ArrayList();
        foreach (string startPo in startPos)
        {

            var currentPos = startPo;
            long steps = 0;
            int index = 0;
            while (true)
            {
                int LRNumber = 0;
                if (LRInstruction[index] == 'R')
                {
                    LRNumber = 1;
                }

                currentPos = Instructions[currentPos][LRNumber];
            
                steps++;
                index = (index + 1) % LRInstruction.Length;

                if (currentPos[2] == 'Z')
                {
                    periods.Add(steps);
                    break;
                }
            }
        }
        
        long lcm = (long)periods[0];
        for (int i = 1; i < periods.Count; i++) {
            lcm = lcmMethod(lcm, (long)periods[i]);
        }
        
        
        Console.WriteLine("Result is: " + lcm);

        stopwatch.Stop();


        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
    }
    
    
    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long lcmMethod(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
}