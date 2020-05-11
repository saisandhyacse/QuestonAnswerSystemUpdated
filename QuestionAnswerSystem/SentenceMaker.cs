namespace QuestionAnswerSystem
{
    public class SentenceMaker : LineFormatter
    {
        public SentenceMaker()
        {

        }
        public string[] sentences { get; set; }

        public override void SplitSentence(string text, clsConstant.StringSplitPattern splitType)
        {
            sentences = text.Split(new char[] { '.', '?', '!' });
        }
    }
}