using System.IO;
using System.Linq;

namespace AdventOfCode.Day06;

public class Solution : BaseSolution
{
    public Solution() : base(6, "Coded Marker")
    {
    }

    public override string GetPart1Answer()
    {
        return FindMarker(File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day6.txt")[0], 4);
    }

    public override string GetPart2Answer()
    {
          return FindMarker(File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day6.txt")[0], 14);
    }

    public string FindMarker(string input, int charsNeeded)
    {
        int marker = 0;

        while (!IsUnique(input.Substring(marker, charsNeeded)))
        {
            marker++;
        }

        marker += charsNeeded;

        return marker.ToString();
    }

    public bool IsUnique(string input)
    {
        return input.Distinct().Count() == input.Length;
    }

}
