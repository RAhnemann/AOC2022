using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day05;

public class Solution : BaseSolution
{
    public Solution() : base(5, "Get Stacked")
    {
    }

    public override string GetPart1Answer()
    {
        var sum = 0;

        var lines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day5.txt");

        var stacklines = new List<string>();

        var counter = 0;

        for (int i = 0; !string.IsNullOrEmpty(lines[i]); i++)
        {
            stacklines.Add(lines[i]);
            counter++;
        }

        stacklines.RemoveAt(stacklines.Count - 1);

        var stacks = ParseStacks(stacklines);


        foreach (var line in lines.Skip(counter + 1))
        {
            ProcessMove(stacks, line);

        }

        string concat = string.Empty;

        stacks.ForEach(s => concat += (s[0]));


        return String.Join("", stacks);

    }

    public override string GetPart2Answer()
    {
        var sum = 0;

        var lines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day5.txt");

        var stacklines = new List<string>();

        var counter = 0;

        for (int i = 0; !string.IsNullOrEmpty(lines[i]); i++)
        {
            stacklines.Add(lines[i]);
            counter++;
        }

        stacklines.RemoveAt(stacklines.Count - 1);

        var stacks = ParseStacks(stacklines);


        foreach (var line in lines.Skip(counter + 1))
        {
            ProcessMoveInTact(stacks, line);

        }

        string concat = string.Empty;

        stacks.ForEach(s => concat += (s[0]));


        return String.Join("", stacks);
    }

    public void ProcessMove(List<List<string>> stacks, string instruction)
    {
        var match = Regex.Match(instruction, @"move ([0-9]{1,2}) from ([0-9]{1,2}) to ([0-9]{1,2})");

        var count = int.Parse(match.Groups[1].Value);
        var source = int.Parse(match.Groups[2].Value);
        var dest = int.Parse(match.Groups[3].Value);

        for (int i = 0; i < count; i++)
        {
            stacks[dest - 1].Insert(0, stacks[source - 1][0]);
            stacks[source - 1].RemoveAt(0);
        }
    }
    public void ProcessMoveInTact(List<List<string>> stacks, string instruction)
    {
        var match = Regex.Match(instruction, @"move ([0-9]{1,2}) from ([0-9]{1,2}) to ([0-9]{1,2})");

        var count = int.Parse(match.Groups[1].Value);
        var source = int.Parse(match.Groups[2].Value);
        var dest = int.Parse(match.Groups[3].Value);


        var movedCrates = stacks[source - 1].GetRange(0, count);
        stacks[dest - 1].InsertRange(0, movedCrates);
        stacks[source - 1].RemoveRange(0, count);

    }
    public List<List<string>> ParseStacks(List<string> lines)
    {

        //Find how many stacks we have
        string longest = lines.OrderByDescending(s => s.Replace(" ", "").Length).First();

        int columns = longest.Replace(" ", "").Length / 3;

        List<List<string>> stacks = new List<List<string>>();

        for (int i = 0; i < columns; i++)
            stacks.Add(new List<string>());

        lines.ForEach(l => l = l + " ");

        foreach (string line in lines)
        {
            for (int i = 1; i <= columns; i++)
            {
                int start = (i - 1) * 4;

                var parsedCrate = line.Substring(start, 3);

                if (!string.IsNullOrWhiteSpace(parsedCrate))
                {
                    stacks[i - 1].Add(parsedCrate.Replace("[", "").Replace("]", ""));
                }
            }
        }

        return stacks;
    }



}
