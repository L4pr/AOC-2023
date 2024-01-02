namespace Day19App;

public class part2
{
    private static string[] content = new string[0];


    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day19App\\Day19.txt"; // Replace with the actual file path

        try
        {
            // Read all text from the file in one operation
            content = File.ReadAllLines(path);


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

        int emptyLineIndex = 0;
        // qqz{s>2770:qs,m<1801:hdj,R}
        Dictionary<string, List<(string, string)>> rules =
            new Dictionary<string, List<(string, string)>>();
        for (int i = 0; i < content.Length; i++)
        {
            if (content[i] == "")
            {
                emptyLineIndex = i;
                break;
            }

            string[] nameAndRule = content[i].Split("{");
            List<(string, string)> rule = new List<(string, string)>();
            string[] stringRules = nameAndRule[1].Split(",");

            foreach (var stringRule in stringRules)
            {
                if (stringRule.Split(":").Length != 2)
                {
                    rule.Add(("true", stringRule.Split("}")[0]));
                }
                else
                {
                    rule.Add((stringRule.Split(":")[0], stringRule.Split(":")[1]));
                }
            }
            
            rules.Add(nameAndRule[0], rule);
        }

        List<(int, int, int, int)> parts = new List<(int, int, int, int)>();
        for (int i = emptyLineIndex + 1; i < content.Length; i++)
        {
            string[] lineParts = content[i].Split(",");
            parts.Add((x: int.Parse(lineParts[0].Split("=")[1]), m: int.Parse(lineParts[1].Split("=")[1]),
                a: int.Parse(lineParts[2].Split("=")[1]), s: int.Parse(lineParts[3].Split("=")[1].Split("}")[0])));
        }

        int total = 0;

        foreach (var part in parts)
        {
            Boolean isAccepted = false;
            string currentName = "in";
            while (true)
            {
                if (currentName == "A")
                {
                    total += part.Item1 + part.Item2 + part.Item3 + part.Item4;
                    Console.WriteLine(part.Item1 + part.Item2 + part.Item3 + part.Item4);
                    break;
                }
                if (currentName == "R")
                {
                    break;
                }
                
                List<(string, string)> rule = rules[currentName];

                foreach (var temp in rule)
                {
                    if (temp.Item1 == "true")
                    {
                        currentName = temp.Item2;
                        break;
                    }
                    
                    int number = int.Parse(temp.Item1.Substring(2));
                    
                    int itemIndex;
                    if (temp.Item1[0] == 'x')
                    {
                        itemIndex = 0;
                    }
                    else if (temp.Item1[0] == 'm')
                    {
                        itemIndex = 1;
                    }
                    else if (temp.Item1[0] == 'a')
                    {
                        itemIndex = 2;
                    }
                    else
                    {
                        itemIndex = 3;
                    }
                    
                    if (temp.Item1[1] == '<')
                    {
                        if (itemIndex == 0)
                        {
                            if (number > part.Item1)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 1)
                        {
                            if (number > part.Item2)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 2)
                        {
                            if (number > part.Item3)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 3)
                        {
                            if (number > part.Item4)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (itemIndex == 0)
                        {
                            if (number < part.Item1)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 1)
                        {
                            if (number < part.Item2)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 2)
                        {
                            if (number < part.Item3)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                        else if (itemIndex == 3)
                        {
                            if (number < part.Item4)
                            {
                                currentName = temp.Item2;
                                break;
                            }
                        }
                    }
                    
                    
                }
                
                
            }

        }
        
        Console.WriteLine(total);
    }
}