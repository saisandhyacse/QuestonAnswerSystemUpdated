using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace QuestionAnswerSystem.Test
{
    class InputReaderTest
    {
        [Test]
        public void TestEmptyFile()
        {
            var para = new ParagraphQA("Input7");
            CollectionAssert.AreEqual(para.GetLines(), new string[] { });
        }

        [Test]
        public void ValidateFile()
        {
            string[] lval = { "Zebra is an Animal.", "Chennai is my city.", "Who are you?", "How are things?" };
            var para = new InputReader();
            var inputLoader = new InputReader("InputTest");
            CollectionAssert.AreEqual(inputLoader.GetLines(), lval);
        }

        [Test]
        public void ValidateParagraph()
        {
            ParagraphQA para = new ParagraphQA("InputTest");
            string[] lval = { "Zebra is an Animal.", "Chennai is my city.", "Who are you?", "How are things?" };
            CollectionAssert.AreEqual(para.GetLines(), lval);

            para.GetRequiredEntities();
            Assert.AreEqual(para.isValidInput, false);

            ParagraphQA para1 = new ParagraphQA("Input5");
            para1.GetLines();
            Assert.AreEqual(para1.lines.Count(), 7);
            String s = "Zebras are several species of African equids (horse family) united by their distinctive black and white stripes. Their stripes come in different patterns, unique to each individual. They are generally         social animals that live in small harems to large herds. Unlike their closest relatives, horses and donkeys, zebras have never been truly domesticated. There are three species of zebras: the plains zebra,the Grévy's zebra and the mountain zebra. The plains zebra and the mountain zebra belong to the subgenus Hippotigris, but Grévy's zebrais the sole species of subgenus Dolichohippus. The latter resembles an ass, to which it is closely related, while the former two are more horse-like. All three belong to the genus Equus, along with other living equids. The unique stripes of zebras make them one of the animals most familiar to people. They occur in a variety of habitats,such as grasslands, savannas, woodlands, thorny scrublands, mountains, and coastal hills. However, various anthropogenic factors have had a severe impact on zebra populations, in particular hunting for skins and habitat destruction. Grévy's zebra and the mountain zebra are endangered. While plains zebras are much more plentiful,  one subspecies - the Quagga - became extinct in the late 19th century. Though there is currently a plan, called the Quagga Project,           that aims to breed zebras that are phenotypically similar to the Quagga, in a process called breeding back.";
            para1.GetRequiredEntities();
            Assert.AreEqual(para1.isValidInput, true);
            Assert.AreEqual(para1.paragraph, s);
        }

        [Test]
        public void ValidateQuestion()
        {
            ParagraphQA para = new ParagraphQA("Input1");
            para.GetLines();
            para.GetRequiredEntities();
            Assert.AreEqual(para.isValidInput, false);
            ParagraphQA para2 = new ParagraphQA("Input2");
            para2.GetLines();
            para2.GetRequiredEntities();
            Assert.AreEqual(para2.isValidInput, true);
            Assert.AreEqual(para2.questions.Count, 5);
            Assert.AreEqual(para2.questions[1], "What is the aim of the Quagga Project?");
        }

        [Test]
        public void ValidateAnswer()
        {
            ParagraphQA para2 = new ParagraphQA("Input5");
            para2.GetLines();
            para2.GetRequiredEntities();
            Assert.AreEqual(para2.isValidInput, true);
            Assert.AreEqual(para2.answer, "No valid answer;No valid answer;No valid answer;No valid answer;No valid answer;");
        }
    }
}
