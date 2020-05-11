using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionAnswerSystem.Test
{
    class TokenizerTest
    {

        [Test]
        public void ValidateTokens()
        {
            const string text = "Zebra is an animal. My city is Chennai.";
            var analyzer = new Tokenizer();
            analyzer.SplitSentence(text, clsConstant.StringSplitPattern.individualWords);

            //  Assert.AreEqual(analyzer.sentences.Count(), 2);
            Assert.AreEqual(analyzer.GetTotalWordCount(text), 8);
            Assert.AreEqual(analyzer.Tokens[0], "Zebra");

            const string text1 = ".!   .  123456789 is an invalid input......!!!!!!???????How are u?";
            var analyzer1 = new Tokenizer();
            analyzer.SplitSentence(text1, clsConstant.StringSplitPattern.individualWords);

            //  Assert.AreEqual(analyzer.sentences.Count(), 2);
            Assert.AreEqual(analyzer.Tokens[0], "123456789");
        }
    }
}
