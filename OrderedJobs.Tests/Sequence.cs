using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderedJobs.Tests
{
    class Sequence
    {
        public string Output(string input)
        {
            var sequence = String.Empty;

            foreach (var line in SplitLines(input))
            {
                sequence += ParseJob(line);
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
