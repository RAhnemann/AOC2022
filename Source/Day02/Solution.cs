using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AdventOfCode.Day02;

public class Solution : BaseSolution
{
    public Solution() : base(2, "RPS")
    {
    }

    [Flags]
    public enum RPS
    {
        Rock = 1,
        A = 1,
        X = 1,
        Paper = 2,
        B = 2,
        Y = 2,
        Scissors = 4,
        C = 4,
        Z = 4
    }

    public enum WinScenarios
    {
        Rock = 5,
        Paper = 3,
        Scissors = 6

    }

    public override string GetPart1Answer()
    {
        var running = 0;

        foreach (var line in File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day2.txt"))
        {
            running += GetScore(line.Split(' ')[1], line.Split(' ')[0]);
        }
        return running.ToString();
    }

    public override string GetPart2Answer()
    {
        var running = 0;

        foreach (var line in File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day2.txt"))
        {
            running += GetScoreFromOutcome(line.Split(' ')[1], line.Split(' ')[0]);
        }
        return running.ToString();
    }

    public int GetScore(string meInput, string themInput)
    {
        RPS game;
        RPS me, them;

        Enum.TryParse(meInput, out me);
        Enum.TryParse(themInput, out them);

        game = (me | them);

        int score = meInput.ToCharArray()[0] - 87;

        //We threw the same thing
        if ((me & ~them) == 0)
        {
            score += 3;
        }
        else
        {
            //Win Scenario as a string
            string winner = Enum.Parse<WinScenarios>(((int)game).ToString()).ToString();

            //Check defined win scenario vs what I threw
            if ((int)Enum.Parse<RPS>(winner) == (int)me)
                score += 6;
        }

        return score;
    }

    //Clever was part 1. This is for points :D
    public int GetScoreFromOutcome(string scoreInput, string themInput)
    {
        int score = 0;
       switch(scoreInput)
        {
            case "X": //lose
                switch(themInput)
                {
                    case "A":
                        score += 3;
                        break;
                    case "B":
                        score += 1;
                        break;
                    case "C":
                        score += 2;
                        break;
                    default:
                        break;
                }
                break;

            case "Y": //draw
                switch (themInput)
                {
                    case "A":
                        score += 1;
                        break;
                    case "B":
                        score += 2;
                        break;
                    case "C":
                        score += 3;
                        break;
                    default:
                        break;
                }

                score += 3;
                break;

            case "Z": //win
                switch (themInput)
                {
                    case "A":
                        score += 2;
                        break;
                    case "B":
                        score += 3;
                        break;
                    case "C":
                        score += 1;
                        break;
                    default:
                        break;
                }

                score += 6;
                break;

            default:
                break;
        }
        return score;
    }
}
