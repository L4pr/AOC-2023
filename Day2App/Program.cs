

using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day2App\\Day2.txt"; // Replace with the actual file path
        string[] content = new string[0];
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

        int totalScore = 0;
        
        foreach (var line in content)
        {
            string[] game = line.Split(": ");
            string[] grabs = game[1].Split("; ");
            int maxRed = 0;
            int maxBlue = 0;
            int maxGreen = 0;

            foreach (var grab in grabs)
            {
                string[] types = grab.Split(", ");
                foreach (var type in types)
                {
                    string[] amountPerType = type.Split(" ");
                    if (amountPerType[1].Equals("red"))
                    {
                        int amount = int.Parse(amountPerType[0]);
                        if (amount > maxRed)
                        {
                            maxRed = amount;
                        }
                    }
                    if (amountPerType[1].Equals("green"))
                    {
                        int amount = int.Parse(amountPerType[0]);
                        if (amount > maxGreen)
                        {
                            maxGreen = amount;
                        }
                    }
                    if (amountPerType[1].Equals("blue"))
                    {
                        int amount = int.Parse(amountPerType[0]);
                        if (amount > maxBlue)
                        {
                            maxBlue = amount;
                        }
                    }
                }
            }

            totalScore = totalScore + (maxRed * maxBlue * maxGreen);


            // if (maxRed <= 12 && maxGreen <= 13 && maxBlue <= 14)
            // {
            //     string[] temp = game[0].Split(" ");
            //     Console.WriteLine(temp[1]);
            //     totalScore = totalScore + int.Parse(temp[1]);
            // }
        }
        
        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        Console.WriteLine("total score: " + totalScore);
    }
}