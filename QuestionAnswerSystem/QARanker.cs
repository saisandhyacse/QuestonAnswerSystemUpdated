using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionAnswerSystem
{
    public class QARanker
    {
        public QARanker()
        {

        }

        public QARanker(int i, int j, int k, int l, int x, int y, bool b)
        {
            questionId = i;
            answerID = j;
            questionCount = k;
            answerCount = l;
            TotalQCount = x;
            TotalACount = y;
            isSubstring = b;
        }

        public int questionId { get; set; }
        public int answerID { get; set; }
        public int questionCount { get;  set; }
        public int answerCount { get; set; }
        public int TotalQCount { get; set; }
        public int TotalACount { get; set; }
        public bool isSubstring { get; set; }
        public int Rank => CalculateRank();

        public int CalculateRank()
        {
            // we need some efficient algorithm here.
            int rank = ((questionCount * 100 / TotalQCount) + (answerCount * 100 / TotalACount)) + (questionCount + answerCount);
            rank = isSubstring ? rank + 5 : rank;
            return rank;
        }

        public int CalculateRank(int x, int y, int T1, int T2, bool isSubstr)
        {
            // we need some efficient algorithm here.
            int rank = ((x * 100 / T1) + (y * 100 / T2)) + (questionCount + answerCount);
            rank = isSubstr ? rank + 5 : rank;
            return rank;
        }

        // Check and Update Rank if needed.
        public void UpdateRank(int QCount, int ACount, int totalQTokens, int totalATokens, bool isSubstr)
        {
            if(CalculateRank(QCount, ACount, totalQTokens, totalATokens, isSubstr) > Rank)
            {
                this.questionCount = QCount;
                this.answerCount = ACount;
            }
        }

    }
}
