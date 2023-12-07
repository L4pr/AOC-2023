


using System.Collections;

class Program
{
    
    private static string[] content = new string[0];
    
    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day3App\\Day3.txt"; // Replace with the actual file path
        
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

        int total = 0;
        
        for (int i = 0; i < content.Length; i++)
        {
            Boolean numberFound = false;
            string foundNumber = "";
            ArrayList iCoordinate = new ArrayList();
            ArrayList jCoordinate = new ArrayList();
            for (int j = 0; j < content[i].Length; j++)
            {
                int result = 0;


                if (numberFound)
                {
                    if (int.TryParse(content[i][j].ToString(), out result))
                    {
                        foundNumber = foundNumber + content[i][j].ToString();
                        iCoordinate.Add(i);
                        jCoordinate.Add(j);
                    }
                    else
                    {
                       
                        if (HasCharacterAround(iCoordinate, jCoordinate))
                        {
                            total = total + int.Parse(foundNumber);
                            Console.WriteLine(foundNumber);
                        }

                        numberFound = false;
                        iCoordinate.Clear();
                        jCoordinate.Clear();
                    }
                } 
                else if (int.TryParse(content[i][j].ToString(), out result))
                {
                    foundNumber = content[i][j].ToString();
                    numberFound = true;
                    iCoordinate.Add(i);
                    jCoordinate.Add(j);
                }
            }
        }
        
        Console.WriteLine(total);
    }


    private static Boolean HasCharacterAround(ArrayList iCoordinate, ArrayList jCoordinate)
    {
        for (int k = 0; k < iCoordinate.Count; k++)
        {
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k] - 1))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k], (int)jCoordinate[k] + 1))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k] + 1))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k]))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k] + 1, (int)jCoordinate[k]))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k] - 1))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k], (int)jCoordinate[k] - 1))
            {
                return true;
            }
            if (IsCharacter((int)iCoordinate[k] - 1, (int)jCoordinate[k] + 1))
            {
                return true;
            }
            
        }
    
        return false;
    }
    
    private static Boolean IsCharacter(int i, int j)
    {
        if (i < 0 || i > 139)
        {
            return false;
        }
        
        if (j < 0 || j > 139)
        {
            return false;
        }
        
        // if (i < 0 || i > 9)
        // {
        //     return false;
        // }
        //
        // if (j < 0 || j > 9)
        // {
        //     return false;
        // }
        // if (content[i][j].ToString() == "*" || content[i][j].ToString() == "+" ||
        //     content[i][j].ToString() == "#" || content[i][j].ToString() == "!" || content[i][j].ToString() == "@" || content[i][j].ToString() == "%" || content[i][j].ToString() == "&" || content[i][j].ToString() == "/" ||content[i][j].ToString() == "=" || content[i][j].ToString() == "$")
        // {
        //     return true;
        // }

        if (content[i][j].ToString() == "." || content[i][j].ToString() == "1" || content[i][j].ToString() == "2" ||
            content[i][j].ToString() == "3" || content[i][j].ToString() == "4" || content[i][j].ToString() == "5" ||
            content[i][j].ToString() == "6" || content[i][j].ToString() == "7" || content[i][j].ToString() == "8" ||
            content[i][j].ToString() == "9" || content[i][j].ToString() == "0")
        {
            return false;
        }
        
        return true;
    }
    
    

}
