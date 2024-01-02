using System.Diagnostics;

namespace Day11App;

public class part2
{
    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day11App\\Day11.txt"; // Replace with the actual file path

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
        
        List<string> data = new List<string>();
        foreach (var line in content)
        {
            data.Add(line);
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string dotLine = "";
        for (int i = 0; i < content[0].Length; i++)
        {
            dotLine += ".";
        }

        List<int> EmptyRows = new List<int>();
        for (int i = 0; i < data.Count; i++)
        {
            if (data[i].Equals(dotLine))
            {
                EmptyRows.Add(i);
            }
        }


        List<int> EmptyColumns = new List<int>();
        int k = 0;
        while (true)
        {
            bool checkAllDot = data.All(s => s[k].Equals('.'));
            if (checkAllDot)
            {
                EmptyColumns.Add(k);
            }

            k++;
            if (k == data[0].Length)
            {
                break;
            }
            
        }

        List<ValueTuple<int, int>> CoordsGalaxy = new List<ValueTuple<int, int>>();

        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < data[0].Length; j++)
            {
                if (data[i][j] == '#')
                {
                    CoordsGalaxy.Add((i, j));
                }
            }
        }


        long total = 0;
        int extraColumns;
        int extraRows;
        for (int i = 0; i < CoordsGalaxy.Count; i++)
        {
            for (int j = i; j < CoordsGalaxy.Count; j++)
            {
                extraColumns = 0;
                for (int l = CoordsGalaxy[j].Item2; l < CoordsGalaxy[i].Item2; l++)
                {
                    if (EmptyColumns.Contains(l))
                    {
                        extraColumns += 999999;
                    }
                }
                for (int l = CoordsGalaxy[i].Item2; l < CoordsGalaxy[j].Item2; l++)
                {
                    if (EmptyColumns.Contains(l))
                    {
                        extraColumns += 999999;
                    }
                }

                extraRows = 0;
                for (int l = CoordsGalaxy[j].Item1; l < CoordsGalaxy[i].Item1; l++)
                {
                    if (EmptyRows.Contains(l))
                    {
                        extraColumns += 999999;
                    }
                }
                for (int l = CoordsGalaxy[i].Item1; l < CoordsGalaxy[j].Item1; l++)
                {
                    if (EmptyRows.Contains(l))
                    {
                        extraColumns += 999999;
                    }
                }
                
                total += extraRows + extraColumns + (Math.Abs(CoordsGalaxy[i].Item1 - CoordsGalaxy[j].Item1) + Math.Abs(CoordsGalaxy[i].Item2 - CoordsGalaxy[j].Item2));
            }
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        Console.WriteLine("result: " + total);
    }
}