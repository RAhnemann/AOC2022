using System.IO;

namespace AdventOfCode.Day08;

public class Solution : BaseSolution
{

    int[][] grid; //Was tempted to try [,]...prob #problems
    public Solution() : base(8, "Trees")
    {
        string[] lines = File.ReadAllLines("D:\\Dev\\aoc2022\\Source\\Input\\Day8.txt");

        grid = new int[lines.Length][];

        for (int r = 0; r <= lines.Length - 1; r++)
        {
            int[] innerArray = new int[lines[0].Length];

            for (int c = 0; c <= lines[r].Length - 1; c++)
            {
                innerArray[c] = int.Parse(lines[r].ToCharArray()[c].ToString());
            }

            grid[r] = innerArray;
        }
    }

    public override string GetPart1Answer()
    {
        int visible = 0;
        for (int row = 0; row <= grid.Length - 1; row++)
        {
            for (int col = 0; col <= grid[row].Length - 1; col++)
            {
                bool l = IsVisibleLeft(row, col, grid);
                bool r = IsVisibleRight(row, col, grid);
                bool t = IsVisibleTop(row, col, grid);
                bool b = IsVisibleBottom(row, col, grid);


                if (l || r || t || b)
                    visible++;
            }

        }

        return visible.ToString();
    }

    public bool IsVisibleLeft(int row, int col, int[][] grid)
    {
        //Edge
        if (col == 0)
            return true;

        for (int i = 0; i < col; i++)
        {
            if (grid[row][col] <= grid[row][i])
                return false;
        }

        return true;
    }

    public bool IsVisibleRight(int row, int col, int[][] grid)
    {
        //Edge
        if (col == grid[row].Length - 1)
            return true;

        for (int i = col + 1; i <= grid[row].Length - 1; i++)
        {
            if (grid[row][col] <= grid[row][i])
                return false;
        }

        return true;
    }

    public bool IsVisibleTop(int row, int col, int[][] grid)
    {

        //Edge
        if (row == 0)
            return true;

        for (int i = 0; i < row; i++)
        {
            if (grid[row][col] <= grid[i][col])
                return false;
        }

        return true;
    }

    public bool IsVisibleBottom(int row, int col, int[][] grid)
    {

        //Edge
        if (row == grid.Length - 1)
            return true;

        for (int i = row + 1; i <= grid.Length - 1; i++)
        {
            if (grid[row][col] <= grid[i][col])
                return false;
        }

        return true;
    }

    public override string GetPart2Answer()
    {

        int max = 0;
        for (int row = 0; row <= grid.Length - 1; row++)
        {
            for (int col = 0; col <= grid[row].Length - 1; col++)
            {
                int l = VisibleCountLeft(row, col, grid);
                int r = VisibleCountRight(row, col, grid);
                int t = VisibleCountTop(row, col, grid);
                int b = VisibleCountBottom(row, col, grid);
                if (l * r * t * b > max)
                    max = l * r * t * b;
            }

        }

        return string.Empty;
    }

    public int VisibleCountLeft(int row, int col, int[][] grid)
    {
        //Edge
        if (col == 0)
            return 0;

        int leftDist = 0;

        for (int i = col - 1; i >= 0; i--)
        {
            leftDist++;
            if (grid[row][col] <= grid[row][i])
                break;
        }

        return leftDist;
    }

    public int VisibleCountRight(int row, int col, int[][] grid)
    {
        //Edge
        if (col == grid[row].Length - 1)
            return 0;

        int rightDist = 0;

        for (int i = col + 1; i <= grid[row].Length - 1; i++)
        {
            rightDist++;

            if (grid[row][col] <= grid[row][i])
                break;
        }

        return rightDist;
    }

    public int VisibleCountTop(int row, int col, int[][] grid)
    {

        //Edge
        if (row == 0)
            return 0;

        int topDist = 0;
        for (int i = row - 1; i >= 0; i--)
        {
            topDist++;
            if (grid[row][col] <= grid[i][col])
                break;
        }

        return topDist;
    }

    public int VisibleCountBottom(int row, int col, int[][] grid)
    {

        //Edge
        if (row == grid.Length - 1)
            return 0;

        int bottomDist = 0;
        for (int i = row + 1; i <= grid.Length - 1; i++)
        {
            bottomDist++;
            if (grid[row][col] <= grid[i][col])
                break;
        }

        return bottomDist;
    }
}
