using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class TakeEmptyStrings
    {
        [Test]
        public void EmptyStringReturnsEmptySequence()
        {
            String input = "";
            String result = input;
            Assert.That(result, Is.EqualTo(""));
        }
    }

    [TestFixture]
    public class TakeSingleJob
    {
        [Test]
        public void JobAReturnsA()
        {
            String input = "a =>";
            String result = input[0].ToString();
            Assert.That(result, Is.EqualTo("a"));
        }
    }

    [TestFixture]
    public class MultipleJobs
    {
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

            String result = String.Format("{0}{1}{2}", inputLine1[0], inputLine2[0], inputLine3[0]);


            Assert.That(result, Is.EqualTo("abc"));
        }
    }
}