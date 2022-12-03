using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Day03;

public class Solution : BaseSolution
{
    public Solution() : base(3, "RuckSomething")
    {
    }

    public override string GetPart1Answer()
    {
        var sum = 0;

        foreach (var line in File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day3.txt"))
        {
            sum += GetCode(line);
        }

        return string.Empty;
    }

    public override string GetPart2Answer()
    {
        var sum = 0;

        var allLines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day3.txt");

        for (var i = 0; i < allLines.Length - 2; i += 3)
        {
            sum += GetTripCode(allLines[i], allLines[i + 1], allLines[i + 2]);
        }

        return string.Empty;
    }

    public int GetCode(string line)
    {
        var firstHalf = line.Substring(0, line.Length / 2);
        var secondHalf = line.Replace(firstHalf, "");

        foreach (var find in firstHalf.ToCharArray())
        {
            if (secondHalf.IndexOf(find) >= 0)
            {
                return (int)find - 96 >= 0 ? (int)find - 96 : (int)find - 38;
            }
        }

        //Oops?
        return 1000;
    }

    public int GetTripCode(string line1, string line2, string line3)
    {

        foreach (var find in line1.ToCharArray())
        {
            if (line2.IndexOf(find) >= 0 && line3.IndexOf(find) >= 0)
                return (int)find - 96 >= 0 ? (int)find - 96 : (int)find - 38;

        }

        return 1000;
    }
}
