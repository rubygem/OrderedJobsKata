using System;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _resultingSequence;

        public Sequence(string input)
        {
            if (String.IsNullOrEmpty(input)) _resultingSequence = String.Empty;
            else CalculateSequence(input);
        }

        private void CalculateSequence(string instruction)
        {
            _resultingSequence = ParseJob(instruction);
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
            return _resultingSequence;
        }
    }
}