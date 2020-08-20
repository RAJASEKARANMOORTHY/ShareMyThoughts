using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class clsOrangesRotting
    {
        // 994. Rotting Oranges [https://leetcode.com/problems/rotting-oranges/]
        //In a given grid, each cell can have one of three values:

        //the value 0 representing an empty cell;
        //the value 1 representing a fresh orange;
        //the value 2 representing a rotten orange.
        //Every minute, any fresh orange that is adjacent (4-directionally) to a rotten orange becomes rotten.

        //Return the minimum number of minutes that must elapse until no cell has a fresh orange.If this is impossible, return -1 instead.

        //Input: [[2,1,1], [1,1,0], [0,1,1]]
        //Output: 4
        //Example 2:

        //Input: [[2,1,1],[0,1,1],[1,0,1]]
        //Output: -1
        //Explanation:  The orange in the bottom left corner(row 2, column 0) is never rotten, because rotting only happens 4-directionally.
        //Example 3:

        //Input: [[0,2]]
        //Output: 0
        //Explanation:  Since there are already no fresh oranges at minute 0, the answer is just 0.

        //Note:

        //1 <= grid.length <= 10
        //1 <= grid[0].length <= 10
        //grid[i][j] is only 0, 1, or 2.


        [TestMethod]
        public void OrangesRotting()
        {
            var result_1 = OrangesRotting(new int[3][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } });
            var result_2 = OrangesRotting(new int[3][] { new int[] { 2, 1, 1 }, new int[] { 0, 1, 1 }, new int[] { 1, 0, 1 } });
            var result_3 = OrangesRotting(new int[1][] { new int[] { 0, 2 } });
        }
        public int OrangesRotting(int[][] grid)
        {
            Queue<int[]> queue = new Queue<int[]>();
            int freshFruits = 0;

            int rows = grid.Length, columns = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (grid[row][column] == 2) //Rotten
                        queue.Enqueue(new int[] { row, column });
                    else if (grid[row][column] == 1)
                        freshFruits += 1;
                }
            }
            int[][] adjacents = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            int minutes = 0;

            while (queue.Count > 0 && freshFruits > 0)
            {
                int queueSize = queue.Count;
                minutes += 1;
                while (queueSize > 0)
                {
                    var current = queue.Dequeue();

                    foreach (var adjacent in adjacents)
                    {
                        int adjacentRow = adjacent[0] + current[0], adjacentColumn = adjacent[1] + current[1];

                        if (adjacentRow >= 0 && adjacentRow < rows && adjacentColumn >= 0 && adjacentColumn < columns && grid[adjacentRow][adjacentColumn] == 1) // If Fresh
                        {
                            grid[adjacentRow][adjacentColumn] = 2; // Rotten
                            freshFruits--;
                            queue.Enqueue(new int[] { adjacentRow, adjacentColumn });
                        }
                    }

                    queueSize--;
                }

            }
            return freshFruits > 0 ? -1 : minutes;
        }
    }
}
