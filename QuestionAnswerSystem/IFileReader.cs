using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionAnswerSystem
{
    interface IFileReader
    {
        public void ReadFile();

        public string[] GetLines();
    }
}
