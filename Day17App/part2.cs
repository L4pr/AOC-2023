using System.Reflection.Metadata.Ecma335;

namespace Day17App;

public class part2
{
    private static string[] content = new string[0];
    

    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day17App\\Day17.txt"; // Replace with the actual file path

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
            int[] lineNumbers = new int[content[0].Length];
            for (int j = 0; j < content[0].Length; j++)
            {
                lineNumbers[j] = (int)Char.GetNumericValue(content[i][j]);
            }

            map[i] = lineNumbers;
        }

        int minHeatLoss = FindMinHeatLoss(map);
        Console.WriteLine($"Minimum Heat Loss: {minHeatLoss}");
    }

    private static int[][] map;
    
    private static int FindMinHeatLoss(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        var pq = new SortedSet<Node>(); // A priority queue sorted by TotalHeatLoss
        var visited = new HashSet<(int, int, int, int)>(); // To check if a node with a given state has been visited

        // Directions: 0 - Up, 1 - Right, 2 - Down, 3 - Left
        pq.Add(new Node(0, 0, -1, 0, 0)); // Starting point

        while (pq.Count > 0)
        {
            var currentNode = pq.Min;
            pq.Remove(currentNode);

            // If we reach the bottom-right corner, return the heat loss
            if (currentNode.X == rows - 1 && currentNode.Y == cols - 1)
                return currentNode.TotalHeatLoss;

            // Avoid re-processing a node
            if (visited.Contains((currentNode.X, currentNode.Y, currentNode.Direction, currentNode.StepsInCurrentDirection)))
                continue;

            visited.Add((currentNode.X, currentNode.Y, currentNode.Direction, currentNode.StepsInCurrentDirection));

            foreach (var nextNode in GetNextMoves(currentNode, grid))
            {
                if (!visited.Contains((nextNode.X, nextNode.Y, nextNode.Direction, nextNode.StepsInCurrentDirection)))
                {
                    pq.Add(nextNode);
                }
            }
        }

        return -1; // Return -1 if no path is found
    }

    // Node class to represent each state in the grid
    private class Node : IComparable<Node>
    {
        public int X { get; } // X-coordinate
        public int Y { get; } // Y-coordinate
        public int Direction { get; } // Direction of approach
        public int StepsInCurrentDirection { get; } // Steps taken in the current direction
        public int TotalHeatLoss { get; set; } // Total heat loss so far

        public Node(int x, int y, int direction, int stepsInCurrentDirection, int totalHeatLoss)
        {
            X = x;
            Y = y;
            Direction = direction;
            StepsInCurrentDirection = stepsInCurrentDirection;
            TotalHeatLoss = totalHeatLoss;
        }

        public int CompareTo(Node other)
        {
            int comparison = TotalHeatLoss.CompareTo(other.TotalHeatLoss);
            if (comparison != 0) return comparison;

            comparison = X.CompareTo(other.X);
            if (comparison != 0) return comparison;

            comparison = Y.CompareTo(other.Y);
            if (comparison != 0) return comparison;

            comparison = Direction.CompareTo(other.Direction);
            if (comparison != 0) return comparison;

            return StepsInCurrentDirection.CompareTo(other.StepsInCurrentDirection);
        }
    }

    // Method to get possible next moves from a node
    private static List<Node> GetNextMoves(Node currentNode, int[][] grid)
    {
        List<Node> nextMoves = new List<Node>();
        int rows = grid.Length;
        int cols = grid[0].Length;

        // Check if the crucible can turn (or must continue straight)
        bool canTurn = currentNode.StepsInCurrentDirection >= 4;

        // Add the current direction for continuing straight, if not exceeding max steps
        if (currentNode.Direction != -1 && currentNode.StepsInCurrentDirection < 10)
        {
            AddNextMove(currentNode, directions[currentNode.Direction], false, rows, cols, nextMoves, grid);
        }

        // Add left and right turns if possible
        if (canTurn)
        {
            int leftTurn = (currentNode.Direction + 3) % 4;
            int rightTurn = (currentNode.Direction + 1) % 4;
            AddNextMove(currentNode, directions[leftTurn], true, rows, cols, nextMoves, grid);
            AddNextMove(currentNode, directions[rightTurn], true, rows, cols, nextMoves, grid);
        }

        return nextMoves;
    }

    
    
    private static int[][] directions = new int[][] {
        new int[] { -1, 0 }, // Up
        new int[] { 0, 1 },  // Right
        new int[] { 1, 0 },  // Down
        new int[] { 0, -1 }  // Left
    };
    
    private static void AddNextMove(Node currentNode, int[] direction, bool canTurn, int rows, int cols, List<Node> nextMoves, int[][] grid)
    {
        int newX = currentNode.X + direction[0];
        int newY = currentNode.Y + direction[1];
        int newDirection = GetDirectionIndex(direction);
        int newSteps = (newDirection == currentNode.Direction || currentNode.Direction == -1) ? currentNode.StepsInCurrentDirection + 1 : 1;

        if (newX >= 0 && newX < rows && newY >= 0 && newY < cols && (canTurn || newSteps <= 10))
        {
            int newHeatLoss = currentNode.TotalHeatLoss + (newX != 0 || newY != 0 ? grid[newX][newY] : 0); // Do not add the starting block's heat loss
            nextMoves.Add(new Node(newX, newY, newDirection, newSteps, newHeatLoss));
        }
    }
    
    private static int GetDirectionIndex(int[] direction)
    {
        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i][0] == direction[0] && directions[i][1] == direction[1])
            {
                return i;
            }
        }
        return -1; // Direction not found
    }


}