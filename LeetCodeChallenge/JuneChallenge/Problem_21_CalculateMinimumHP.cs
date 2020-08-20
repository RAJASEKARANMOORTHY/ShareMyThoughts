using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuneChallenge
{
    [TestClass]
    public class Problem_21_CalculateMinimumHP
    {
        // https://www.youtube.com/watch?v=m1-cA3XU9fk
        //The demons had captured the princess(P) and imprisoned her in the bottom-right corner of a dungeon.The dungeon consists of M x N rooms laid out in a 2D grid.Our valiant knight(K) was initially positioned in the top-left room and must fight his way through the dungeon to rescue the princess.
        //The knight has an initial health point represented by a positive integer.If at any point his health point drops to 0 or below, he dies immediately.
        //Some of the rooms are guarded by demons, so the knight loses health (negative integers) upon entering these rooms; other rooms are either empty(0's) or contain magic orbs that increase the knight's health (positive integers).
        //In order to reach the princess as quickly as possible, the knight decides to move only rightward or downward in each step.
        //Write a function to determine the knight's minimum initial health so that he is able to rescue the princess.
        //For example, given the dungeon below, the initial health of the knight must be at least 7 if he follows the optimal path RIGHT-> RIGHT -> DOWN -> DOWN.

        //-2 (K)  -3	3
        //-5	-10	1
        //10	30	-5 (P)

        //Note:

        //The knight's health has no upper bound.
        //Any room can contain threats or power-ups, even the first room the knight enters and the bottom-right room where the princess is imprisoned.


        [TestMethod]
        public void CalculateMinimumHP()
        {
            var result_1 = CalculateMinimumHP(new int[][] {
                new int[] {-2,-3,3},
                new int[] {-5,-10,1},
                new int[] {10,30,-5},
            });
        }

        public int CalculateMinimumHP(int[][] dungeon)
        {
            (int rows, int columns) = (dungeon.Length, dungeon[0].Length);

            int[][] deepArray = new int[rows][];
            for (int row = 0; row < rows; row++)
                deepArray[row] = new int[columns];

            deepArray[rows - 1][columns - 1] = Math.Max(1 - dungeon[rows - 1][columns - 1], 1);

            for (int column = columns - 2; column >= 0; column--)
                deepArray[rows - 1][column] = Math.Max(deepArray[rows - 1][column + 1] - dungeon[rows - 1][column], 1);

            for (int row = rows - 2; row >= 0; row--)
                deepArray[row][columns - 1] = Math.Max(deepArray[row + 1][columns - 1] - dungeon[row][columns - 1], 1);


            for (int row = rows - 2; row >= 0; row--)
            {
                for (int column = columns - 2; column >= 0; column--)
                {
                    int value = dungeon[row][column];
                    int minmum = Math.Min(deepArray[row + 1][column], deepArray[row][column + 1]);
                    deepArray[row][column] = Math.Max(minmum - value, 1);
                }
            }

            return deepArray[0][0];
        }
    }
}


