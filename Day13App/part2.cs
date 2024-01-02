using System.Xml.Schema;

namespace Day13App;

public class part2
{
    private static string[] content = new string[0];
    Random random = new Random();

    static void Main(string[] args)
    {
        string path =
            "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day13App\\Day13.txt"; // Replace with the actual file path

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

        List<char[][]> squares = new List<char[][]>();
        List<char[]> temp = new List<char[]>();
        char[][] tempString;
        foreach (var line in content)
        {
            if (line == "")
            {
                tempString = new char[temp.Count][];
                for (int i = 0; i < temp.Count; i++)
                {
                    tempString[i] = temp[i];
                }

                squares.Add(tempString);
                temp.Clear();
            }
        }

        tempString = new char[temp.Count][];
        for (int i = 0; i < temp.Count; i++)
        {
            tempString[i] = temp[i];
        }

        squares.Add(tempString);

        static List<string> Rotate90(List<string> source)
        {
            List<string> returnValue = new();

            for (int x = 0; x < source[0].Length; x++)
            {
                string newString = "";
                for (int y = source.Count - 1; y >= 0; y--)
                {
                    newString += source[y][x];
                }

                returnValue.Add(newString);
            }

            return returnValue;
        }

        static int FindSplit(List<string> source, int prevMatch = -1)
        {
            static bool CheckMatch(string A, string B, bool doSmudgeCheck)
            {
                int matches = Enumerable.Range(0, A.Length).Count(c => A[c] == B[c]);
                if (matches == A.Length) return true;
                if (doSmudgeCheck && matches == A.Length - 1) return true;

                return false;
            }

            bool doCleaning = prevMatch != -1;

            for (int y = 0; y < source.Count - 1; y++)
            {
                if (CheckMatch(source[y], source[y + 1], doCleaning))
                {
                    if (doCleaning && prevMatch == y + 1) continue; // skip prev seen.

                    bool isMatch = true;
                    int numToEdge = int.Min(y, source.Count - (y + 2));
                    for (int j = 1; j <= numToEdge; j++)
                    {
                        isMatch = CheckMatch(source[y - j], source[y + j + 1], doCleaning);
                    }

                    if (isMatch) return y + 1;
                }
            }

            return 0;
        }
    }
}