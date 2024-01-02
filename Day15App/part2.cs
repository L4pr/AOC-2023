namespace Day15App;

public class part2
{
    private static string[] content2 = new string[0];
    
    
    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day15App\\Day15.txt"; // Replace with the actual file path

        try
        {
            // Read all text from the file in one operation
            content2 = File.ReadAllLines(path);
            
            
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
        
        List<List<ValueTuple<string, int>>> boxes = new List<List<ValueTuple<string, int>>>();

        for (int i = 0; i < 256; i++)
        {
            boxes.Add(new List<(string, int)>());
        }
        
        
        
        string[] content = content2[0].Split(",");

        foreach (var lens in content)
        {
            int operationPlace = 0;
            for (int i = 1; i < 20; i++)
            {
                if (lens[i] == '-' || lens[i] == '=')
                {
                    operationPlace = i;
                    break;
                } 
            }

            string label = lens.Substring(0, operationPlace);
            int hashcode = Hash(label);

            if (lens[operationPlace] == '=')
            {
                int valueLocation = -1;

                for (int i = 0; i < boxes[hashcode].Count; i++)
                {
                    if (boxes[hashcode][i].Item1 == label)
                    {
                        valueLocation = i;
                        break;
                    }
                }
                if (valueLocation != -1)
                {
                    
                    boxes[hashcode][valueLocation] = (label, lens[lens.Length - 1] - '0');
                }
                else
                {
                    boxes[hashcode].Add((label, lens[lens.Length - 1] - '0'));
                }
            }
            else
            {
                int valueLocation = -1;

                for (int i = 0; i < boxes[hashcode].Count; i++)
                {
                    if (boxes[hashcode][i].Item1 == label)
                    {
                        valueLocation = i;
                        break;
                    }
                }
                if (valueLocation != -1)
                {
                    boxes[hashcode].RemoveAt(valueLocation);
                    int boxCount = boxes[hashcode].Count;
                    // for (int i = valueLocation; i < boxCount - 1; i++)
                    // {
                    //     boxes[hashcode][i] = boxes[hashcode][i + 1];
                    //     boxes[hashcode].RemoveAt(i + 1);
                    // }
                }
            }
        }

        long total = 0;
        for (int i = 0; i < 256; i++)
        {
            for (int j = 0; j < boxes[i].Count; j++)
            {
                total += (i + 1) * (j + 1) * (boxes[i][j].Item2);
            }
        }

        Console.WriteLine("total is: " + total);
        
    }

    private static int Hash(string input)
    {

        int result = 0;
        foreach (var character in input)
        {
            result = ((result + ((int)character)) * 17) % 256;
        }

        return result;
    }
}