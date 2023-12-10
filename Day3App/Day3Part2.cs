using System.Collections;
using System.Diagnostics;

namespace Day3App;

public class Day3Part2
{
    private static string[] tempContent = new string[0];
    private static string[] content;
    
    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day3App\\Day3.txt"; // Replace with the actual file path
        
        try
        {
            // Read all text from the file in one operation
            tempContent = File.ReadAllLines(path);
            content = new string[tempContent.Length + 2];
            
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

        String dotline = "";
        for (int i = 0; i < tempContent[0].Length + 2; i++)
        {
            dotline += ".";
        }

        
        content[0] = dotline;
        for (int i = 0; i < tempContent.Length; i++)
        {
            content[i + 1] = "." + tempContent[i] + ".";
        }
        content[tempContent.Length + 1] = dotline;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        ArrayList gearCoordnate = new ArrayList();
        Dictionary<int, int> numbersAroundGear = new Dictionary<int, int>();
        ArrayList iCoordinate = new ArrayList();
        ArrayList jCoordinate = new ArrayList();
        ArrayList foundNumbers = new ArrayList();
        ArrayList numbersWithGearCoords = new ArrayList();

        for (int i = 0; i < content.Length; i++)
        {
            for (int j = 0; j < content[i].Length; j++)
            {
                if (IsCharacter(i, j))
                {
                    int coords = (i << 16) + j;
                    gearCoordnate.Add(coords);
                    numbersAroundGear.Add(coords, 0);
                }
            }
        }
        
        
        for (int i = 0; i < content.Length; i++)
        {
            Boolean numberFound = false;
            string foundNumber = "";
            
            int x = 0;
            int y = 0;
            for (int j = 0; j < content[i].Length; j++)
            {
                int result = 0;

                

                if (numberFound)
                {
                    if (int.TryParse(content[i][j].ToString(), out result))
                    {
                        foundNumber = foundNumber + content[i][j].ToString();
                        x = (x << 8) + i;
                        y = (y << 8) + j;
                    }
                    else
                    {
                        int[] CoordsGears = HasCharacterAround(x, y);
                        CoordsGears = CoordsGears.Distinct().ToArray();
                        if (CoordsGears.Length > 0)
                        {
                            foundNumbers.Add(int.Parse(foundNumber));
                            iCoordinate.Add(x);
                            jCoordinate.Add(y);
                            numbersWithGearCoords.Add(CoordsGears);
                            foreach (var gear in CoordsGears)
                            {
                                numbersAroundGear[gear] += 1;
                            }
                        }

                        foundNumber = "";
                        numberFound = false;
                        x = 0;
                        y = 0;
                    }
                } 
                else if (int.TryParse(content[i][j].ToString(), out result))
                {
                    foundNumber = content[i][j].ToString();
                    numberFound = true;
                    x = i;
                    y = j;
                }
            }
        }

        int total = 0;
        
        foreach (var gear in gearCoordnate)
        {
            if (numbersAroundGear[(int)gear] == 2)
            {
                ArrayList values = new ArrayList();
                
                foreach (var VARIABLE in numbersWithGearCoords)
                {
                    for (int i = 0; i < ((int[])VARIABLE).Length; i++)
                    {
                        if ((int)((int[])VARIABLE)[i] == (int)gear)
                        {
                            values.Add(foundNumbers[numbersWithGearCoords.IndexOf(VARIABLE)]);
                        }

                        if (values.Count == 2)
                        {
                            break;
                        }
                    }
                    if (values.Count == 2)
                    {
                        break;
                    }
                }

                total += (int)values[0] * (int)values[1];

                values.Clear();
            }
        }

        stopwatch.Stop();
        Console.WriteLine(total);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");





    }


    private static int[] HasCharacterAround(int x, int y)
    {
        ArrayList iCoordinate = new ArrayList();
        while (x != 0)
        {
            iCoordinate.Add(x & 0xFF);
            x = x >> 8;
        }
        ArrayList jCoordinate = new ArrayList();
        while (y != 0)
        {
            jCoordinate.Add(y & 0xFF);
            y = y >> 8;
        }

        ArrayList result = new ArrayList();
        
        for (int k = 0; k < iCoordinate.Count; k++)
        {
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k] - 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] + 1, (int)jCoordinate[k] - 1));
            }
            if (IsCharacter((int)iCoordinate[k], (int)jCoordinate[k] + 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k], (int)jCoordinate[k] + 1));
            }
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k] + 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] + 1, (int)jCoordinate[k] + 1));
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k]))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] - 1, (int)jCoordinate[k]));
            }
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k]))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] + 1, (int)jCoordinate[k]));
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k] - 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] - 1, (int)jCoordinate[k] - 1));
            }
            if (IsCharacter((int)iCoordinate[k], (int)jCoordinate[k] - 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k], (int)jCoordinate[k] - 1));
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k] + 1))
            {
                result.Add(getBinaryCoords((int)iCoordinate[k] - 1, (int)jCoordinate[k] + 1));
            }
            
        }

        int[] result2 = new int[result.Count];

        for (int i = 0; i < result.Count; i++)
        {
            result2[i] = (int)result[i];
        }
        return result2;
    }
    
    private static Boolean IsCharacter(int i, int j)
    {
        if (content[i][j].ToString() == "*")
        {
            return true;
        }
        
        return false;
    }

    private static int getBinaryCoords(int i, int j)
    {
        return (i << 16) + j;
    }
}