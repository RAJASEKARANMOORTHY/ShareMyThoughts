using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class clsWallsAndGates
    {
        // 286. Walls and Gates [https://leetcode.com/problems/walls-and-gates/]
        //You are given a m x n 2D grid initialized with these three possible values.

        //-1 - A wall or an obstacle.
        //0 - A gate.
        //INF - Infinity means an empty room.We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.
        //Fill each empty room with the distance to its nearest gate.If it is impossible to reach a gate, it should be filled with INF.

        //Example: 

        //Given the 2D grid:

        //INF  -1  0  INF
        //INF INF INF  -1
        //INF  -1 INF  -1
        //  0  -1 INF INF
        //After running your function, the 2D grid should be:

        //  3  -1   0   1
        //  2   2   1  -1
        //  1  -1   2  -1
        //  0  -1   3   4

        private int wall = -1;
        private int gate = 0;
        private int emptyRoom = int.MaxValue;

        [TestMethod]
        public void WallsAndGates()
        {
            int[][] rooms_1 = new int[4][]{
                new int[] { emptyRoom, wall, gate, emptyRoom},
                new int[] { emptyRoom, emptyRoom, emptyRoom, wall},
                new int[] { emptyRoom, wall, emptyRoom, wall},
                new int[] { gate, wall, emptyRoom, emptyRoom},
            };

            WallsAndGates(rooms_1);
        }

        public void WallsAndGates(int[][] rooms)
        {
            if (rooms.Length == 0)
                return;

            Queue<int[]> queue = new Queue<int[]>();
            int rows = rooms.Length, columns = rooms[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (rooms[row][column] == gate)
                    {
                        queue.Enqueue(new int[] { row, column });
                    }
                }
            }

            int[][] adjacents = new int[4][] {
                new int[] {1,0},
                new int[] {0,1},
                new int[] {-1,0},
                new int[] {0,-1},
            };

            while (queue.Count > 0)
            {
                int queueSize = queue.Count;

                while (queueSize > 0)
                {
                    var current = queue.Dequeue();

                    foreach(var adjacent in adjacents)
                    {
                        int adjacentRow = current[0] + adjacent[0], adjacentColumn = current[1] + adjacent[1];

                        if(adjacentRow >=0 && adjacentRow < rows && adjacentColumn >= 0 && adjacentColumn < columns && rooms[adjacentRow][adjacentColumn] == emptyRoom)
                        {
                            queue.Enqueue(new int[] { adjacentRow, adjacentColumn });
                            rooms[adjacentRow][adjacentColumn] = rooms[current[0]][current[1]] + 1;
                        }
                    }
                    queueSize--;
                }
            }
        }
    }
}
