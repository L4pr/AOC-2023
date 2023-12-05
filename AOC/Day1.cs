using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace AOC;

public class Day1
{
    static void Main(string[] args)
    {
        string path = @"Day1.txt"; // Replace with the actual file path
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
        ArrayList numbers = new ArrayList();
        foreach (var line in content)
        {
            int firstNumber = 0;
            Boolean firstNumberBool = true;
            int lastNumber = 0;
            foreach (var character in line)
            {
                int result;
                
                if (int.TryParse(character.ToString(), out result))
                {
                    if (firstNumberBool)
                    {
                        firstNumber = result;
                        firstNumberBool = false;
                    }
                    lastNumber = result;
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
        Console.WriteLine(total);
        
    }
}