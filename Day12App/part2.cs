namespace Day12App;

public class part2
{
    private static string[] content = new string[0];
    Random random = new Random();

    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day12App\\Day12.txt"; // Replace with the actual file path

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

        // testinput:
        // ???.### 1,1,3
        // .??..??...?##. 1,1,3
        // ?#?#?#?#?#?#?#? 1,3,1,6
        // ????.#...#... 4,1,1
        // ????.######..#####. 1,6,5
        // ?###???????? 3,2,1
    
        // supposed output: 1 + 4 + 1 + 1 + 4 + 10 = 21;
        // actual output: 15;
        
        part2 p = new part2();
        p.run();
    }

    private void run()
    {
        int total = content.Sum(line => CalculateArrangements(line));
        Console.WriteLine($"Total arrangements: {total}");
    }
    
    private int CalculateArrangements(string line)
    {
        string[] parts = line.Split(' ');
        string configuration = parts[0];
        int[] numbers = parts[1].Split(',').Select(int.Parse).ToArray();

        return count(configuration, numbers);
    }

    private int count(string cfg, int[] nums)
    {
        if (string.IsNullOrEmpty(cfg))
        {
            return nums.Length == 0 ? 1 : 0;
        }

        if (nums.Length == 0)
        {
            return cfg.Contains("#") ? 0 : 1;
            
        }

        int result = 0;

        if (".?".Contains(cfg[0]))
        {
            result += count(cfg.Remove(0, 1), nums);
            
        }

        if ("#?".Contains(cfg[0]))
        {
            
            if (nums[0] < cfg.Length && !cfg.Substring(0, nums[0]).Contains(".") && (nums[0] == cfg.Length || cfg[nums[0]] != '#'))
            {
                int[] newNums = nums.Skip(1).ToArray();
                result += count(cfg.Remove(0, (nums[0] + 1)), newNums);
                
            }
        }
        return result;
        
    }
    
}