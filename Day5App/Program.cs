


class Program
{

    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day5App\\Day5.txt"; // Replace with the actual file path

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
        
        
        
        
        
        
        
    }
}