using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace QuestionAnswerSystem
{
    class Program
    {
        public static void Main()
        {
            // 
            // Sample Input files (Input1, Input2.. Input5).
            for (int inputCount = clsConstant.ONE; inputCount <= clsConstant.SEVEN; inputCount++)
            {
                Console.WriteLine("*****************Press any key to read data from Input" + inputCount + ".txt and Display the result ********************");
                Console.ReadKey();
                ParagraphQA inputData = new ParagraphQA("Input" + inputCount);
                inputData.GetLines();

                if (inputData.lines != null && inputData.lines.Length > 0)
                {
                    inputData.GetRequiredEntities();

                    if (!inputData.isValidInput)
                    {
                        Console.WriteLine("Input Data not in proper format");
                    }
                    else
                    {
                        QASystemDriver QASinstance = new QASystemDriver();
                        QASinstance.MatchWordsInSentences(inputData);
                    }
                }
                else
                {
                    Console.WriteLine("Empty file");
                }
               
            }

            // Keep the console window open in debug mode.  
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


    }

}
