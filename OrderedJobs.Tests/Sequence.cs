using System;
using NUnit.Framework;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _input;

        public Sequence(string input)
        {
            _input = input;
        }

        public Sequence()
        {
        }

        public string Output(string input)
        {
            var sequence = String.Empty;

            if (!String.IsNullOrEmpty(input))
            {
                foreach (var line in SplitLines(input))
                {
                    sequence += ParseJob(line);
                }
            }
            return sequence;
        }

        private string[] SplitLines(string input)
        {
            return input.Split('\n');
        }

        private String ParseJob(String input)
        {
            return input[0].ToString();
        }

        public String Output()
        {
            return String.Empty;
        }
    }
}