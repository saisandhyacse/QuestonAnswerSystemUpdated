using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Serialization;

namespace QuestionAnswerSystem
{
    public class QASystemDriver
    {
        LanguageInstructor LI = new LanguageInstructor();
        public Collection<QARanker> colQARank = new Collection<QARanker>();
        public void MatchWordsInSentences(ParagraphQA inputData)
        {
            // Get words from sentences
            SentenceMaker sf = new SentenceMaker();
            sf.SplitSentence(inputData.paragraph, clsConstant.StringSplitPattern.sentenceForm);

            foreach (var sentence in sf.sentences)
            {
                Tokenizer TSentence = new Tokenizer();
                GetTokens(TSentence, sentence);
                MatchQuestionAndAnswer(inputData, TSentence, sentence);
            }

            DisplayResult d = new DisplayResult();
            d.ShowResult(colQARank, inputData.answer);
        }

        private void MatchQuestionAndAnswer(ParagraphQA inputData, Tokenizer STokens, string sentence)
        {
            int Q_num = 0;
            foreach (var ques in inputData.questions)
            {
                // Get words from Questions
                Q_num++;
                Tokenizer Qtokens = new Tokenizer();
                GetTokens(Qtokens, ques);

                int Q_Count = CountHits(STokens, Qtokens);

                if (Q_Count > 0)
                {
                    // Split to respective Answers
                    Tokenizer AnswerList = new Tokenizer();
                    AnswerList.SplitSentence(inputData.answer, clsConstant.StringSplitPattern.wordsSeparatedBySemicolon);

                    int A_num = 0;
                    foreach (var ans in AnswerList.Tokens)
                    {
                        A_num++;

                        bool isSubstr = CheckIfPromisingSubstr(sentence, ans);
                        Tokenizer AnsTokens = new Tokenizer(); 


                        GetTokens(AnsTokens, ans);

                        int A_Count = CountHits(STokens, AnsTokens);

                        if (A_Count > 0)
                        {
                            //A_Count = isSubstr ? A_Count + 1 : A_Count;
                            CreateOrUpdateQARank(Q_num, A_num, Q_Count, A_Count, Qtokens.Tokens.Count, AnsTokens.Tokens.Count, isSubstr);
                        }
                    }
                }
            }
        }

        private bool CheckIfPromisingSubstr(string line, string answer)
        {
            StringComparison comp = StringComparison.OrdinalIgnoreCase;
            comp = StringComparison.OrdinalIgnoreCase;
            return (line.Contains(answer, comp));
        }

        // Create or Update Question-Answer pair for rank calculation
        private void CreateOrUpdateQARank(int question, int answer, int QCount, int ACount, int totalQTokens, int totalATokens, bool isSubstr)
        {
            QARanker lPair = colQARank.Where(l => l.questionId == question && l.answerID == answer).FirstOrDefault();

            if (lPair != null)
            {
                lPair.UpdateRank(QCount, ACount, totalQTokens, totalATokens, isSubstr);
            }
            else
            {
                QARanker QAR = new QARanker(question, answer, QCount, ACount, totalQTokens, totalATokens, isSubstr);
                colQARank.Add(QAR);
            }
        }

        private bool AddSubstringCheck(string s1, List<string> Sentence)
        {
            foreach (string s in Sentence)
            {
                if (s1.Equals(s.Substring(0, s.Length - 1), StringComparison.InvariantCultureIgnoreCase))
                    return true;

                if (s.Equals(s1.Substring(0, s1.Length - 1), StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        private void GetTokens(Tokenizer T, string line)
        {
            T.SplitSentence(line, clsConstant.StringSplitPattern.individualWords);

            // Ignore words provided by the Language Dictionary.
            T.Tokens = T.Tokens.Except(LI.IstrWordsIgnore).ToList();
        }

        // Get no of matching words
        private int CountHits(Tokenizer Line1, Tokenizer Line2)
        {
            List<string> lst = Line1.Tokens.Distinct().Intersect(Line2.Tokens).ToList();
            int Count = Line1.Tokens.Distinct().Intersect(Line2.Tokens).Count();

            var check = new List<string>();
            foreach(string s in Line2.Tokens.Distinct())
            {
                s.ToLower();
                if (lst.Any(s1 => s1.ToLower() == s))
                {
                    // do nothing;
                }
                else
                    check.Add(s);
            }    

            foreach (string s in check)
            {
                if (AddSubstringCheck(s, Line1.Tokens))
                    Count++;
            }

            return Count;
        }
    }
}
