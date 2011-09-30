using System;

namespace OrderedJobs.Tests
{
    public class Sequence
    {
        private string _resultingSequence;

        public Sequence(string instructions)
        {
            if (String.IsNullOrEmpty(instructions)) _resultingSequence = String.Empty;
            else CalculateSequence(instructions);
        }

        private void CalculateSequence(string instruction)
        {
            var job = ParseJob(instruction);
            _resultingSequence = job;
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