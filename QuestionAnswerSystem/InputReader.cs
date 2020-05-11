using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace QuestionAnswerSystem
{
    public class InputReader : IFileReader
    {
        public InputReader()
        {

        }
        public InputReader(string FilePath)
        {
            _filePath = @"E:\" + FilePath + ".txt";
        }

        private readonly string _filePath;

        public string[] lines { get; set; }

      
        public void ReadFile()
        {
            try
            {
                string text = File.ReadAllText(_filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found");
            }
        }


        public string[] GetLines()
        {
            try
            {

                lines = File.ReadAllLines(_filePath);
            }
            catch (FileNotFoundException e)
            {

            }

            return lines;
        }

    }
}