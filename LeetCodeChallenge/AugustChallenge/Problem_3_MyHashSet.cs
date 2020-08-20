using LeetCodeChallenge.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustChallenge
{
    // https://www.youtube.com/watch?v=FIBZeUpvw4s
    [TestClass]
    public class Problem_1_MyHashSet
    {
        //Design HashSet

        //Design a HashSet without using any built-in hash table libraries.

        //To be specific, your design should include these functions:

        //add(value) : Insert a value into the HashSet.
        // contains(value) : Return whether the value exists in the HashSet or not.
        // remove(value): Remove a value in the HashSet.If the value does not exist in the HashSet, do nothing.

        // Example:

        // MyHashSet hashSet = new MyHashSet();
        //    hashSet.add(1);         
        //hashSet.add(2);         
        //hashSet.contains(1);    // returns true
        //hashSet.contains(3);    // returns false (not found)
        //hashSet.add(2);          
        //hashSet.contains(2);    // returns true
        //hashSet.remove(2);          
        //hashSet.contains(2);    // returns false (already removed)

        //Note:

        //All values will be in the range of[0, 1000000].
        //The number of operations will be in the range of[1, 10000].
        //Please do not use the built-in HashSet library.

        //["MyHashSet","add","add","contains","contains","add","contains","remove","contains"]
        //[[],[1],[2],[1],[3],[2],[2],[2],[2]]
        //[null,null,null,true,false,null,true,null,false]

        [TestMethod]
        public void MyHashSet()
        {
            MyHashSet obj = new MyHashSet();
            obj.Add(1);
            obj.Remove(1);
            bool param_3 = obj.Contains(1);
        }
    }
}
