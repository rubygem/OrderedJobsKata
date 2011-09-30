using System;

namespace OrderedJobs.Tests
{
    internal class Sequence
    {
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
    }
}