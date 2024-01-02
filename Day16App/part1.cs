namespace Day16App;

public class part1
{
    private static string[] content = new string[0];
    private static int[][] map;

    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day16App\\Day16.txt"; // Replace with the actual file path

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

        map = new int[content.Length][];
        for (int i = 0; i < content.Length; i++)
        {   
            int[] intLine = new int[content[0].Length];
            map[i] = intLine;
        }

        int maxTotal = 0;
        
        for (int k = 0; k < content.Length; k++)
        {
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    map[i][j] = 0;
                }
            }
            doLaser((0, 1), (k, 0));

            int total = 0;
            
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (map[i][j] == 1)
                    {
                        total += 1;
                    }
                }
            }

            if (total > maxTotal)
            {
                maxTotal = total;
            }
            
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    map[i][j] = 0;
                }
            }
            doLaser((0, -1), (k, content[0].Length - 1));

            total = 0;
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (map[i][j] == 1)
                    {
                        total += 1;
                    }
                }
            }

            if (total > maxTotal)
            {
                maxTotal = total;
            }

            Console.WriteLine(k);
        }
        
        for (int k = 0; k < content[0].Length; k++)
        {
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    map[i][j] = 0;
                }
            }
            doLaser((1, 0), (0, k));

            int total = 0;
            
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (map[i][j] == 1)
                    {
                        total += 1;
                    }
                }
            }

            if (total > maxTotal)
            {
                maxTotal = total;
            }
            
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    map[i][j] = 0;
                }
            }
            doLaser((-1, 0), (content.Length - 1, k));

            total = 0;
            
            for (int i = 0; i < content.Length; i++)
            {
                for (int j = 0; j < content[0].Length; j++)
                {
                    if (map[i][j] == 1)
                    {
                        total += 1;
                    }
                }
            }

            if (total > maxTotal)
            {
                maxTotal = total;
            }
            Console.WriteLine(k);
        }
        
        Console.WriteLine(maxTotal);
        
    }

    
    
    private static void doLaser(ValueTuple<int, int> initialDirection, ValueTuple<int, int> initialCoordinates)
    {
        List<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>> CoordinatesBeen =
            new List<((int, int), (int, int))>();
        Stack<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>> stack = new Stack<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>>();
        stack.Push((initialDirection, initialCoordinates));

        while (stack.Count > 0)
        {
            var (direction, coordinates) = stack.Pop();

            if (CoordinatesBeen.Contains((direction, coordinates)))
            {
                continue;
            }
            else
            {
                CoordinatesBeen.Add((direction, coordinates));
            }

            if (coordinates.Item1 < 0 || coordinates.Item1 >= content.Length || coordinates.Item2 < 0 ||
                coordinates.Item2 >= content[0].Length)
            {
                continue;
            }

            char currentChar = content[coordinates.Item1][coordinates.Item2];
            map[coordinates.Item1][coordinates.Item2] = 1;



            if (currentChar == '.')
            {
                stack.Push((direction, (coordinates.Item1 + direction.Item1, coordinates.Item2 + direction.Item2)));
            }
            else if (currentChar == '/')
            {
                if (direction == (1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, -1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, 1))
                {
                    ValueTuple<int, int> newDirection = (-1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (-1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, 1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, -1))
                {
                    ValueTuple<int, int> newDirection = (1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
            }
            else if (currentChar == '\\')
            {
                if (direction == (1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, 1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, 1))
                {
                    ValueTuple<int, int> newDirection = (1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (-1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, -1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, -1))
                {
                    ValueTuple<int, int> newDirection = (-1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
            }
            else if (currentChar == '-')
            {
                if (direction == (1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, -1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                    newDirection = (0, 1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, 1))
                {
                    stack.Push((direction, (coordinates.Item1 + direction.Item1, coordinates.Item2 + direction.Item2)));
                }
                else if (direction == (-1, 0))
                {
                    ValueTuple<int, int> newDirection = (0, -1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                    newDirection = (0, 1);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (0, -1))
                {
                    stack.Push((direction, (coordinates.Item1 + direction.Item1, coordinates.Item2 + direction.Item2)));
                }
            }
            else if (currentChar == '|')
            {
                if (direction == (1, 0))
                {
                    stack.Push((direction, (coordinates.Item1 + direction.Item1, coordinates.Item2 + direction.Item2)));
                }
                else if (direction == (0, 1))
                {
                    ValueTuple<int, int> newDirection = (1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                    newDirection = (-1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
                else if (direction == (-1, 0))
                {
                    stack.Push((direction, (coordinates.Item1 + direction.Item1, coordinates.Item2 + direction.Item2)));
                }
                else if (direction == (0, -1))
                {
                    ValueTuple<int, int> newDirection = (1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                    newDirection = (-1, 0);
                    stack.Push((newDirection,
                        (coordinates.Item1 + newDirection.Item1, coordinates.Item2 + newDirection.Item2)));
                }
            }
            else
            {
                Console.WriteLine("unknown element");
            }
        }
    }
}