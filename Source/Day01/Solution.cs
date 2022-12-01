using System.IO;
using System.Linq;

namespace AdventOfCode.Day01;

public class Solution : BaseSolution
{
    public Solution() : base(1, "Hungry Elves")
    {
    }

    public override string GetPart1Answer()
    {
        List<string> lines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day1.txt").ToList();

        int maxSum = 0;
            
        int runTotal = 0;

        foreach(string line in lines)
        {
            if(string.IsNullOrEmpty(line))
            {
                if (runTotal > maxSum)
                    maxSum = runTotal;

                runTotal = 0;
            }
            else
            {
                runTotal += int.Parse(line);
            }
        }    

        return maxSum.ToString();
    }

    public override string GetPart2Answer()
    {
        List<string> lines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day1.txt").ToList();

        List<int> sums = new List<int>();

        int runTotal = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                sums.Add(runTotal);

                runTotal = 0;
            }
            else
            {
                runTotal += int.Parse(line);
            }
        }

        sums.Sort();
        sums.Reverse();
        return (sums[0] + sums[1] + sums[2]).ToString();
    }
}