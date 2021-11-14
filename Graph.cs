using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class Graph
    {
        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int rowCount = grid.Length;
            int colCount = grid[0].Length;
            int num_islands = 0;

            for (var rowIdx = 0; rowIdx < rowCount; ++rowIdx)
            {
                for (int colIdx = 0; colIdx < colCount; ++colIdx)
                {
                    if (grid[rowIdx][colIdx] == '1')
                    {
                        ++num_islands;
                        // Depth First Search
                        dfs(grid, rowIdx, colIdx);
                    }
                }
            }

            return num_islands;
        }

        private static void dfs(char[][] grid, int r, int c)
        {
            int nr = grid.Length;
            int nc = grid[0].Length;

            if (r < 0 || c < 0 || r >= nr || c >= nc || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0';
            dfs(grid, r - 1, c);
            dfs(grid, r + 1, c);
            dfs(grid, r, c - 1);
            dfs(grid, r, c + 1);
        }

        public static int GetFood(char[][] grid)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            var start = new int[2];
            var startFound = false;

            for (var i = 0; i < rows; i++)
            {
                if (startFound)
                    break;

                for (var j = 0; j < cols; j++)
                {
                    if (grid[i][j] == '*')
                    {
                        start[0] = i;
                        start[1] = j;
                        startFound = true;
                        break;
                    }
                }
            }

            if (!startFound)
                return -1;

            return Bfs(grid, start);
        }

        private static int Bfs(char[][] grid, int[] start)
        {
            (int Row, int Col)[] dirs = new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

            var rows = grid.Length;
            var cols = grid[0].Length;

            var visited = new bool[rows, cols];
            var queue = new Queue<(int R, int C)>();
            queue.Enqueue((start[0], start[1]));
            visited[start[0], start[1]] = true;

            var level = 0;

            while (queue.Count > 0)
            {
                var curNodes = queue.Count;

                for (var i = 0; i < curNodes; i++)
                {
                    var curPoint = queue.Dequeue();
                    var curRow = curPoint.R;
                    var curCol = curPoint.C;

                    if (grid[curRow][curCol] == '#')
                        return level;

                    foreach (var dir in dirs)
                    {
                        var newR = curRow + dir.Row;
                        var newC = curCol + dir.Col;

                        if (newR >= 0 && newC >= 0 && newR < rows && newC < cols
                                && !visited[newR, newC] && grid[newR][newC] != 'X')
                        {
                            queue.Enqueue((newR, newC));
                            visited[newR, newC] = true;
                        }
                    }
                }

                level++;
            }

            return -1; // Not found
        }
    }
}