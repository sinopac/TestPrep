using System.Collections.Generic;
using System.Linq;

namespace MyTestPrep
{
    public static class Robot
    {
        public static bool IsRobotBounded(string instructions)
        {
            var dir = new int[4][] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

            var currentDir = 0;
            var currentPosition = (0, 0);

            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case 'G':
                        currentPosition.Item1 += dir[currentDir][0];
                        currentPosition.Item2 += dir[currentDir][1];
                        break;

                    case 'L':
                        currentDir = (currentDir + 3) % 4;
                        break;

                    case 'R':
                        currentDir = (currentDir + 1) % 4;
                        break;
                }
            }

            return currentPosition == (0, 0) || currentDir != 0;
        }
    }
}