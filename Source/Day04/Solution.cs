using System.IO;

namespace AdventOfCode.Day04;

public class Solution : BaseSolution
{
    public Solution() : base(4, "Overlaps")
    {
    }

    public override string GetPart1Answer()
    {
        var sum = 0;

        foreach (var line in File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day4.txt"))
        {
            if(IsOverlapAll(line))
            {
                sum++;
            }
        }

        return sum.ToString();

    }

    public override string GetPart2Answer()
    {
        var sum = 0;

        foreach (var line in File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day4.txt"))
        {
            if (IsOverlapAny(line))
            {
                sum++;
            }

        }

        return sum.ToString();
    }

    public bool IsOverlapAll(string line)
    {
        var section1 = line.Split(',')[0];
        var section2 = line.Split(',')[1];

        var startSection1 = int.Parse(section1.Split('-')[0]);
        var endSection1 = int.Parse(section1.Split('-')[1]);

        var startSection2 = int.Parse(section2.Split('-')[0]);
        var endSection2 = int.Parse(section2.Split('-')[1]);

        return (startSection1 <= startSection2 && endSection1 >= endSection2) || (startSection2 <= startSection1 && endSection2 >= endSection1);
    }

    public bool IsOverlapAny(string line)
    {

        var section1 = line.Split(',')[0];
        var section2 = line.Split(',')[1];

        var startSection1 = int.Parse(section1.Split('-')[0]);
        var endSection1 = int.Parse(section1.Split('-')[1]);

        var startSection2 = int.Parse(section2.Split('-')[0]);
        var endSection2 = int.Parse(section2.Split('-')[1]);


        return (endSection1 >= startSection2) && (endSection2 >= startSection1); ;
    }
}
