using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Collections;
using AmazonOnlineAssessment.DataStructure;

namespace AmazonOnlineAssessment
{
    [TestClass]
    public class GetTopTopys
    {
        [TestMethod]
        public void getTopToys_PriorityQueue()
        {

            int numCompetitors = 3, topNCompetitors = 2;
            string[] competitors = new string[] { "anacell", "cetracular", "betacellular" };
            int numReviews = 3;
            string[] reviews = new string[] {  "Anacell provides the best services in the city",
                    "betacellular has awesome services",
                    "Best services provided by anacell, everyone should use anacell"};
            var result_1 = getTopToys_PriorityQueue(numCompetitors, topNCompetitors, competitors, numReviews, reviews);

            numCompetitors = 5;
            topNCompetitors = 3;
            competitors = new string[] { "anacell", "betacellular", "cetracular", "deltacellular", "eurocell" };
            numReviews = 5;
            reviews = new string[] {
                                   "I love anacell Best services; Best services provided by anacell",
                                  "betacellular has great services",
                                  "deltacellular provides much better services than betacellular",
                                  "cetracular is worse than anacell",
                                  "Betacellular is better than deltacellular."};

            var result_2 = getTopToys_PriorityQueue(numCompetitors, topNCompetitors, competitors, numReviews, reviews);
        }

        private IList<string> getTopToys_PriorityQueue(int numCompetitors, int topNCompetitors, string[] competitors, int numReviews, string[] reviews)
        {
            IList<string> lstToys = new List<string>();
            Func<string, int> getNumberOfOccurence = delegate (string competitor)
             {
                 return reviews.Count(itm => itm.Contains(competitor));
             };

            PriorityQueue<QueueItem> priorityQueue = new PriorityQueue<QueueItem>();
            foreach (var competitor in competitors)
            {
                priorityQueue.Enqueue(new QueueItem(competitor, getNumberOfOccurence(competitor)));
            }

            int kFrequent = topNCompetitors;
            while (priorityQueue.Size > 0 && kFrequent > 0)
            {
                var current = priorityQueue.Dequeue();
                lstToys.Add((string)current.Value);
                kFrequent--;
            }

            return lstToys;
        }
    }
}
