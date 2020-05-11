using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;

namespace QuestionAnswerSystem.Test
{
    class QASystemDriverTest
    {
        [Test]
        public void Check()
        {
            QASystemDriver QAVal = new QASystemDriver();
            string[] q = { "Which Zebras are endangered ?", "Which are the three species of zebras ?" };

            ParagraphQA inputData = new ParagraphQA("Grévy's zebra and the mountain zebra are endangered.", q, "Grévy's zebra and the mountain zebra;subgenus Hippotigris;");
            QAVal.MatchWordsInSentences(inputData);
            Collection<QARanker> xCol = new Collection<QARanker>();

            var x = new QARanker(1, 1, 2, 3, 2, 3, false);
            xCol.Add(x);
            var y = new QARanker(2, 1, 1, 4, 3, 4, false);
            xCol.Add(y);

            //CollectionAssert.AreEqual(xCol, QAVal.colQARank);
            //Assert.AreEqual(QAVal.colQARank[0].questionId, 1);
            //Assert.AreEqual(QAVal.colQARank[0].answerID, 1);
            //Assert.AreEqual(xCol[0].questionCount, QAVal.colQARank[0].questionCount);
            //Assert.AreEqual(xCol[0].answerCount, QAVal.colQARank[0].answerCount);
            //Assert.AreEqual(xCol[0].TotalQCount, QAVal.colQARank[0].TotalQCount);
            ////Assert.AreEqual(xCol[0].TotalACount, QAVal.colQARank[0].TotalACount);
            //Assert.AreEqual(xCol[0].Rank, QAVal.colQARank[0].Rank);

            xCol = new Collection<QARanker>();
            QASystemDriver QAVal1 = new QASystemDriver();
            string[] q1 = { "Which Zebras are endangered ?", "Which are the three species of zebras ?" };

            ParagraphQA inputData1 = new ParagraphQA("There are three species of zebras: the plains zebra, the Grévy's zebra and the mountain zebra", q1, "Grévy's zebra and the mountain zebra;the plains zebra, the Grévy's zebra and the mountain zebra;");
            QAVal1.MatchWordsInSentences(inputData1);
            Collection<QARanker> xCol1 = new Collection<QARanker>();

            var x1 = new QARanker(1, 1, 1, 3, 2, 3, true);
            xCol.Add(x1);
            var x2 = new QARanker(1, 2, 1, 4, 2, 4, false);
            var y1 = new QARanker(2, 1, 3, 3, 3, 3, false);
            var y2 = new QARanker(2, 2, 3, 4, 3, 4, false);
            xCol.Add(x1);
            xCol.Add(x2);
            xCol.Add(y1);
            xCol.Add(y2);
            Assert.AreEqual(QAVal1.colQARank[0].questionId, 1);
            Assert.AreEqual(QAVal1.colQARank[0].answerID, 1);
            Assert.AreEqual(xCol[0].questionCount, QAVal1.colQARank[0].questionCount);
            Assert.AreEqual(xCol[0].answerCount, QAVal1.colQARank[0].answerCount);
            Assert.AreEqual(xCol[0].TotalQCount, QAVal1.colQARank[0].TotalQCount);
            Assert.AreEqual(xCol[0].TotalACount, QAVal1.colQARank[0].TotalACount);
            Assert.AreEqual(xCol[0].Rank, QAVal1.colQARank[0].Rank);
        }

    }
}
