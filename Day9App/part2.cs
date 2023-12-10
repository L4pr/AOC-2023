using System.Diagnostics;

namespace Day9App;

public class part2
{
    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day9App\\Day9.txt"; // Replace with the actual file path

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
        
        
        int total = 0;
        
        foreach (var line in content)
        {
            string[] valueString = line.Split(" ");

           
            int[] values = new int[valueString.Length];
            for (int i = 0; i < valueString.Length; i++)
            {
                values[i] = int.Parse(valueString[i]);
            }

            total += next(values);


        }
        
        
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
        Console.WriteLine(total);
        
        
        
        
    }
    
    private static int next(int[] values)
    {
        Boolean isAllNul = true;
        foreach (var tempValue in values)
        {
            if (tempValue != 0)
            {
                isAllNul = false;
                break;
            }
        }
        if (isAllNul)
        {
            return 0;
        }


        int[] result = new int[values.Length - 1];
        for (int i = 1; i < values.Length; i++)
        {
            result[i - 1] = values[i] - values[i - 1];
        }

        return values[0] - next(result);

    }
}