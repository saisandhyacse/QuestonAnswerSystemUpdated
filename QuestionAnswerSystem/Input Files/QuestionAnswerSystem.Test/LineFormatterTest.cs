using NUnit.Framework;
using System.Linq;

namespace QuestionAnswerSystem.Test
{
    public class LineFormatterTests
    {
        [Test]
        public void ValidateSentence()
        {
            const string text = "Zebra is an animal. My city is Chennai.";
            var analyzer = new SentenceMaker();
            analyzer.SplitSentence(text, clsConstant.StringSplitPattern.sentenceForm);
           
          //  Assert.AreEqual(analyzer.sentences.Count(), 2);
            Assert.AreEqual(analyzer.sentences[0], "Zebra is an animal");
            Assert.AreEqual(analyzer.sentences[1], " My city is Chennai");

            const string text1 = ".!.123456789 is an invalid input......!!!!!!???????How are u?";
            var analyzer1 = new SentenceMaker();
            analyzer.SplitSentence(text1, clsConstant.StringSplitPattern.sentenceForm);

            //  Assert.AreEqual(analyzer.sentences.Count(), 2);
            Assert.AreEqual(analyzer.sentences[3], "123456789 is an invalid input");
            Assert.AreEqual(analyzer.sentences[analyzer.sentences.Count() - 2], "How are u");
        }
    } 
}