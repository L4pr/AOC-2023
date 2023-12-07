



using System.Collections;

class Program
{

    private static string[] content = new string[0];

    static void Main(string[] args)
    {
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day4App\\Day4.txt"; // Replace with the actual file path

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

        ArrayList TicketsPerCard = new ArrayList();
        for (int i = 0; i < content.Length; i++)
        {
            TicketsPerCard.Add(1);
        }

        for (int i = 0; i < 10; i++)
        {
            TicketsPerCard.Add(0);
        }
        
        for (int i = 0; i < content.Length; i++)
        {
            
            string[] numbersString = content[i].Split(": ");
            string[] WinningAndLosingNumbers = numbersString[1].Split(" | ");
            string[] WinningNumbers = WinningAndLosingNumbers[0].Split(" ");
            string[] YourNumbers = WinningAndLosingNumbers[1].Split(" ");
            
            int WinningNumbersAmount = 0;
            
            ArrayList WinningNumbersArray = new ArrayList();
            foreach (var WinningNumber in WinningNumbers)
            {
                
                int result;
                if (int.TryParse(WinningNumber, out result))
                {
                    WinningNumbersArray.Add(result);
                }
            }
            ArrayList YourNumbersArray = new ArrayList();
            foreach (var YourNumber in YourNumbers)
            {
                int result;
                if (int.TryParse(YourNumber, out result))
                {
                    YourNumbersArray.Add(result);
                }
            }

            
            
            foreach (var YourNumber in YourNumbersArray)
            {
                int result = WinningNumbersArray.IndexOf(YourNumber);
                if (result != -1)
                {
                    WinningNumbersAmount += 1;
                }
            }

            if (WinningNumbersAmount != 0)
            {
                for (int j = 1; j <= WinningNumbersAmount; j++)
                {
                    TicketsPerCard[i + j] = (int)TicketsPerCard[i + j] + (int)TicketsPerCard[i];
                }
            }
        }


        int TotalTickets = 0;
        foreach (var TicketsCard in TicketsPerCard)
        {
            TotalTickets += (int)TicketsCard;
        }

        Console.WriteLine(TotalTickets);


    }
}