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
            var jobs = string.Empty;
            foreach (var instruction in instructions)
            {
                jobs = jobs + instruction[0];
            }

            return jobs;
        }
    }
    
}