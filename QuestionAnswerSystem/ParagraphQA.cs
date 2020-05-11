using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QuestionAnswerSystem
{
    public class ParagraphQA : InputReader
    {
        public ParagraphQA(string p, string[] q, string a)
        {
            paragraph = p;
            questions = q.ToList();
            answer = a;
        }
        public ParagraphQA(string FilePath) : base (FilePath)
        {
        }
        public string paragraph { get; set; }
        public List<string> questions { get; set; }
        public string answer { get; set; }
        public bool isValidInput { get; set; }
        enum InputType { paragraph, question, answer }

        // Input file segregated to paragraph, questions and answers.
        public void GetRequiredEntities()
        {
            int lineCount = 0;

            if (lines != null && lines.Count() == clsConstant.MAXLINES)
            {
                int n = lines.Count();
                foreach (string line in lines)
                {
                    if (lineCount == 0)
                    {
                        if (!(ValidateEntity(InputType.paragraph, line)))
                            return;
                        paragraph = line;
                    }

                    else if (lineCount > 0 && lineCount < 6)
                    {
                        if (!(ValidateEntity(InputType.question, line)))
                            return;
                        if (questions == null)
                        {
                            questions = new List<string>();
                        }

                        questions.Add(line);
                    }

                    else if (lineCount == 6)
                    {
                        if (!(ValidateEntity(InputType.answer, line)))
                            return;
                        answer = line;
                    }

                    lineCount++;
                }
            }
            else
            {
                isValidInput = false;
                return;
            }
        }

        // Just added minimum Validation criteria
        private bool ValidateEntity(InputType inputType, string line)
        {
            switch (inputType)
            {
                case InputType.paragraph:
                    // More criteria needed. Just to show the usecase
                    isValidInput = line != null && line.Count() > clsConstant.MINSENTENCESIZE && line.Contains('.') && line.Length <= clsConstant.MAXSENTENCELENGTH;
                    break;

                case InputType.question:
                    isValidInput = line != null && line.Count() > 0 && line.EndsWith('?');
                    break;

                case InputType.answer:
                    isValidInput = line != null && line.Count() > 0 && line.Contains(';');
                    break;

                default:
                    break;
            }

            return isValidInput;
        }
    }
}
