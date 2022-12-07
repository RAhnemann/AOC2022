using System.IO;

namespace AdventOfCode.Day07;

public class Solution : BaseSolution
{
    public Solution() : base(7, "File Dirs")
    {
        commands = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day7.txt");
    }

    public string[] commands;
    public aocDir Root { get; set; }
    public aocDir Current { get; set; }

    public List<aocDir> SizedDirs = new List<aocDir>();

    public void ParseCommands()
    {
        for (int i = 0; i <= commands.Length - 1; i++)
        {
            var command = commands[i];

            if (command == "$ ls")
            {
                continue;

            }
            else if (command == "$ cd ..")
            {
                Current = Current.Parent;
            }
            else if (command == "$ cd /")
            {
                Current = Root;
            }
            else if (command.StartsWith("$ cd "))
            {
                Current = Current.Subs.Find(d => d.Name == command.Replace("$ cd ", ""));
            }
            else
            {
                if (commands[i].StartsWith("dir"))
                {
                    //Found a subdir. Add it
                    Current.Subs.Add(new aocDir(Current) { Name = commands[i].Split(' ')[1] });
                }

                //Found a file
                Current.Files.Add(new aocFile() { Size = int.Parse(commands[i].Split(" ")[0]), Name = commands[i].Split(" ")[1] });
            }
        }
    }

    public override string GetPart1Answer()
    {
        Root = new aocDir(null);

        Current = Root;
        ParseCommands();

        FindTinyDirs(Root, 1000000);

        int summedSizes = 0;
        SizedDirs.ForEach(d => summedSizes += d.GetSize());

        return summedSizes.ToString();
    }


    public override string GetPart2Answer()
    {
        SizedDirs = new List<aocDir>();
        Root = new aocDir(null);

        Current = Root;
        ParseCommands();

        int maxSize = 70000000;
        int unused = maxSize - Root.GetSize();
        int spaceNeeded = 30000000 - unused;

        FindBigDirs(Root, spaceNeeded);

        SizedDirs.Sort(delegate (aocDir d1, aocDir d2) { return d1.GetSize().CompareTo(d2.GetSize()); });

        return SizedDirs[0].GetSize().ToString();
    }

    public void FindTinyDirs(aocDir dir, int maxSize)
    {
        if (dir.GetSize() < maxSize)
        {
            SizedDirs.Add(dir);
        }

        foreach (var subD in dir.Subs)
            FindTinyDirs(subD, maxSize);
    }

    public void FindBigDirs(aocDir dir, int maxSize)
    {
        if (dir.GetSize() > maxSize)
        {
            SizedDirs.Add(dir);
        }

        foreach (var subD in dir.Subs)
            FindBigDirs(subD, maxSize);
    }

    public class aocDir
    {
        public aocDir(aocDir parent)
        {
            Subs = new List<aocDir>();
            Files = new List<aocFile>();

            Parent = parent;
        }

        public aocDir Parent { get; set; }

        public string Name { get; set; }

        public List<aocDir> Subs { get; set; }

        public List<aocFile> Files { get; set; }

        public int GetSize()
        {
            var total = 0;

            Files.ForEach(f => total += f.Size);

            Subs.ForEach(s => total += s.GetSize());

            return total;
        }

        public override string ToString()
        {
            return Name;
        }

    }
    public class aocFile
    {
        public string Name { get; set; }

        public int Size { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Size}";
        }
    }
}
