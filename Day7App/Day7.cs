using System.Collections;
using System.Diagnostics;

namespace Day7App;

public class Day7
{
    private static string[] content = new string[0];
    
    private static Dictionary<string, int> CardsNumber = new Dictionary<string, int>{
        {"A", 12},
        {"K", 11},
        {"Q", 10},
        {"T", 9},
        {"9", 8},
        {"8", 7},
        {"7", 6},
        {"6", 5},
        {"5", 4},
        {"4", 3},
        {"3", 2},
        {"2", 1},
        {"J", 0}
        };
    

    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        
        
        string path = "C:\\Users\\renzo\\Desktop\\AdventOfCode\\Day7App\\Day7.txt"; // Replace with the actual file path

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
        
        

        Dictionary<string, int> handsWithWinnings = new Dictionary<string, int>();
        ArrayList hands = new ArrayList();
        
        foreach (var line in content)
        {
            string[] temp = line.Split(" ");
            handsWithWinnings.Add(temp[0], int.Parse(temp[1]));

            
            
            if (hands.Count == 0)
            {
                hands.Add(temp[0]);
                continue;
            }

            for (int i = 0; i <= hands.Count; i++)
            {
                if (i == hands.Count)
                {
                    hands.Add(temp[0]);
                    break;
                }
                if (isBetter(temp[0], (string)hands[i]))
                {
                    continue;
                }
                
                hands.Insert(i, temp[0]);
                break;
            }
        }


        long result = 0;
        for (int i = 1; i <= hands.Count; i++)
        {
            result = result + (handsWithWinnings[(string)hands[i - 1]] * i);
        }

        Console.WriteLine("The result is: " + result);

        stopwatch.Stop();
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
    }
    
    // returns true if hand1 is better than hand2
    public static Boolean isBetter(string hand1, string hand2)
    {
        int[] hand1Cards = new int[12];
        int hand1Jokers = 0;
        int[] hand2Cards = new int[12];
        int hand2Jokers = 0;

        foreach (var card in hand1)
        {
            int cardValue = CardsNumber[card.ToString()];
            if (cardValue == 0)
            {
                hand1Jokers += 1;
            }
            else
            {
                hand1Cards[cardValue - 1] += 1;
            }
        }
        foreach (var card in hand2)
        {
            int cardValue = CardsNumber[card.ToString()];
            if (cardValue == 0)
            {
                hand2Jokers += 1;
            }
            else
            {
                hand2Cards[cardValue - 1] += 1;
            }
        }

        int maxHand1 = hand1Cards.Max();
        hand1Cards[Array.IndexOf(hand1Cards, maxHand1)] = 0;
        int secondMaxHand1 = hand1Cards.Max();
        int scoreHand1 = 0;
        if (maxHand1 == 5 || maxHand1 + hand1Jokers >= 5)
        {
            scoreHand1 = 7;
        } else if (maxHand1 == 4 || maxHand1 + hand1Jokers >= 4)
        {
            scoreHand1 = 6;
        } else if (maxHand1 == 3 || maxHand1 + hand1Jokers >= 3)
        {
            hand1Jokers -= (3 - maxHand1);
            if (secondMaxHand1 == 2 || secondMaxHand1 + hand1Jokers >= 2)
            {
                scoreHand1 = 5;
            }
            else
            {
                scoreHand1 = 4;
            }
        } else if (maxHand1 == 2 || maxHand1 + hand1Jokers >= 2)
        {
            hand1Jokers -= (2 - maxHand1);
            if (secondMaxHand1 == 2 || secondMaxHand1 + hand1Jokers >= 2)
            {
                scoreHand1 = 3;
            }
            else
            {
                scoreHand1 = 2;
            }
        }
        else
        {
            scoreHand1 = 1;
        }
        int maxHand2 = hand2Cards.Max();
        hand2Cards[Array.IndexOf(hand2Cards, maxHand2)] = 0;
        int secondMaxHand2 = hand2Cards.Max();
        int scoreHand2 = 0;
        if (maxHand2 == 5 || maxHand2 + hand2Jokers >= 5)
        {
            scoreHand2 = 7;
        } else if (maxHand2 == 4 || maxHand2 + hand2Jokers >= 4)
        {
            scoreHand2 = 6;
        } else if (maxHand2 == 3 || maxHand2 + hand2Jokers >= 3)
        {
            hand2Jokers -= (3 - maxHand2);
            if (secondMaxHand2 == 2 || secondMaxHand2 + hand2Jokers >= 2)
            {
                scoreHand2 = 5;
            }
            else
            {
                scoreHand2 = 4;
            }
        } else if (maxHand2 == 2 || maxHand2 + hand2Jokers >= 2)
        {
            hand2Jokers -= (2 - maxHand2);
            if (secondMaxHand2 == 2 || secondMaxHand2 + hand2Jokers >= 2)
            {
                scoreHand2 = 3;
            }
            else
            {
                scoreHand2 = 2;
            }
        }
        else
        {
            scoreHand2 = 1;
        }

        if (scoreHand1 > scoreHand2)
        {
            return true;
        }

        if (scoreHand1 < scoreHand2)
        {
            return false;
        }

        for (int i = 0; i < 5; i++)
        {
            if (CardsNumber[hand1[i].ToString()] > CardsNumber[hand2[i].ToString()])
            {
                return true;
            } 
            if (CardsNumber[hand1[i].ToString()] < CardsNumber[hand2[i].ToString()])
            {
                return false;
            }
        }

        return true;
    }
}