using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class OrderedJobsKata
    {
        [Test]
        public void EmptyStringReturnsEmptySequence()
        {
            String input = "";
            String result = input;
            Assert.That(result, Is.EqualTo(""));
        }
    
        [Test]
        public void JobAReturnsA()
        {
            String input = "a =>";
            String result = GetJob(input);
            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void JobsABCReturnsABC()
        {
            var line1 = "a =>\n";
            var line2 = "b =>\n";
            var line3 = "c =>";

            String input = line1 + line2 + line3;

            String[] lines = input.Split('\n');
            String inputLine1 = lines[0];
            String inputLine2 = lines[1];
            String inputLine3 = lines[2];

            String result = String.Format("{0}{1}{2}", 
                GetJob(inputLine1), 
                GetJob(inputLine2), 
                GetJob(inputLine3));

            Assert.That(result, Is.EqualTo("abc"));
        }

        private String GetJob(String input)
        {
            return input[0].ToString();
        }
    }
}