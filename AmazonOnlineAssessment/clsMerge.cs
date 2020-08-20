using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class clsMerge
    {
        [TestMethod]
        public void Merge()
        {
            var result_1 = Merge(new int[4][] { new int[] { 2, 6 }, new int[] { 1, 3 }, new int[] { 8, 10 }, new int[] { 15, 18 } });
            var result_2 = Merge(new int[2][] { new int[] { 1, 4 }, new int[] { 2, 3 } });
        }

        public int[][] Merge(int[][] intervals)
        {
            if(intervals.Length == 0)
                return new int[][] { };

            intervals = SortByColumn(intervals, 0);

            int min = intervals[0][0], max = intervals[0][1];
            List<int[]> mergedIntervals = new List<int[]>();

            for(int index = 1; index < intervals.Length; index++)
            {
                if(intervals[index][0] <= max)
                {
                    max = Math.Max(max, intervals[index][1]);
                } else
                {
                    mergedIntervals.Add(new int[] { min, max });
                    min = intervals[index][0];
                    max = intervals[index][1];
                }
            }

            mergedIntervals.Add(new int[] { min, max });

            return mergedIntervals.ToArray();
        }

        public int[][] SortByColumn(int[][] jaggedArray, int columnIndex)
        {
            Array.Sort(jaggedArray, new Comparison<int[]>((first, second) =>
            {
                if (first[columnIndex] < second[columnIndex])
                    return -1;
                else if (first[columnIndex] > second[columnIndex])
                    return 1;
                else
                    return 0;
            }));

            return jaggedArray;
        }
    }
}
