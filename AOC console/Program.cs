// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\AOC console\\Day1.txt"; // Replace with the actual file path
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
        
        ArrayList numbers = new ArrayList();
        foreach (var line in content)
        {
            int firstNumber = 0;
            int firstNumberPos = 100;
            
            int lastNumber = 0;
            int lastNumberPos = 0;
            for(int i = 0; i < line.Count(); i++)
            {
                char character = line[i];
                int result;
                
                if (int.TryParse(character.ToString(), out result))
                {
                    if (i < firstNumberPos)
                    {
                        firstNumber = result;
                        firstNumberPos = i;
                    }
                    lastNumber = result;
                    lastNumberPos = i;
                }
            }

            for (int i = 0; i < line.Count(); i++)
            {
                Boolean numberFound = false;
                int foundNumber = 0;
                if (line.Count() - i > 2)
                {
                    string size3 = line.Substring(i, 3);
                    
                    
                    switch (size3)
                    {
                        case "one":
                            foundNumber = 1;
                            numberFound = true;
                            break;
                        case "two":
                            foundNumber = 2;
                            numberFound = true;
                            break;
                        case "six":
                            foundNumber = 6;
                            numberFound = true;
                            break;
                    }
                }
                if (line.Count() - i > 3 && !numberFound)
                {
                    string size4 = line.Substring(i, 4);
                    
                    
                    switch (size4)
                    {
                        case "four":
                            foundNumber = 4;
                            numberFound = true;
                            break;
                        case "five":
                            foundNumber = 5;
                            numberFound = true;
                            break;
                        case "nine":
                            foundNumber = 9;
                            numberFound = true;
                            break;
                    }
                }
                if (line.Count() - i > 4 && !numberFound)
                {
                    string size5 = line.Substring(i, 5);
                    
                    
                    switch (size5)
                    {
                        case "three":
                            foundNumber = 3;
                            numberFound = true;
                            break;
                        case "seven":
                            foundNumber = 7;
                            numberFound = true;
                            break;
                        case "eight":
                            foundNumber = 8;
                            numberFound = true;
                            break;
                    }
                }
                
               
                
                if (i < firstNumberPos && numberFound)
                {
                    firstNumber = foundNumber;
                    firstNumberPos = i;
                    
                }

                if (i > lastNumberPos && numberFound)
                {
                    lastNumber = foundNumber;
                    lastNumberPos = i;
                }
                
             
                
            }

            int result2 = 0;
            if (int.TryParse(firstNumber.ToString() + lastNumber.ToString(), out result2))
            {
                numbers.Add(result2);
            }
            
            

        }

        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        
        
        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
        Console.WriteLine(total);
        
    }
}