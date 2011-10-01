using System;
using System.Collections.Generic;

namespace OrderedJobs.Tests
{
    public interface Sequence
    {
        String GetSequence(string[] instructions);
    }

    public class SequenceImp : Sequence
    {
        public String GetSequence(string[] instructions)
        {
            return String.Join("", GetJobs(instructions));
        }

        private String[] GetJobs(string[] instructions)
        {
            var jobs = new List<String>();
            foreach (var instruction in instructions)
            {
                jobs.Add(GetJob(instruction));
            }
            return jobs.ToArray();
        }

        private String GetJob(string instruction)
        {
            return instruction[0].ToString();
        }
    }
    
}