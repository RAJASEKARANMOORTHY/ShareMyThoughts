using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MayChallenge
{
    [TestClass]
    public class Problem_1_FirstBadVersion : VersionControl
    {

        //First Bad Version [ https://leetcode.com/problems/first-bad-version/ ]
        //You are a product manager and currently leading a team to develop a new product.Unfortunately, the latest version of your product fails the quality check.Since each version is developed based on the previous version, all the versions after a bad version are also bad.

        //Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

        //You are given an API bool isBadVersion(version) which will return whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.

        //Example:

        //Given n = 5, and version = 4 is the first bad version.

        //call isBadVersion(3) -> false
        //call isBadVersion(5) -> true
        //call isBadVersion(4) -> true

        //Then 4 is the first bad version.

        [TestMethod]
        public void FirstBadVersion()
        {
            Versions = 5;
            BadVersion = 4;
            Assert.AreEqual(BadVersion, FirstBadVersion(Versions));

            Versions = 1000000;
            BadVersion = 500000;
            var watch =Stopwatch.StartNew();
            Assert.AreEqual(BadVersion, FirstBadVersion(Versions));
            watch.Stop();
        }

        public int FirstBadVersion(int n)
        {
            int start = 1;
            int end = n;

            while (start <= end)
            {
                int middle = (start + (end - start) / 2);

                if (IsBadVersion(middle))
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return start;
        }
    }

    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */
    public class VersionControl
    {
        protected int Versions;
        protected int BadVersion;

        public bool IsBadVersion(int version)
        {
            return version >= BadVersion;
        }
    }
}
