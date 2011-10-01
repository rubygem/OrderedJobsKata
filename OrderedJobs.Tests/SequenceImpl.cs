﻿using System;
using System.Collections.Generic;

namespace OrderedJobs.Tests
{
    public interface Sequence
    {
        String GetSequence(string[] isAny);
    }

    public class SequenceImp : Sequence
    {
        private string _resultingSequence;

        public SequenceImp(string instructions)
        {
            var jobList = new List<String>();
            foreach (var instruction in SplitInstructions(instructions))
            {
                if(instruction.Length > 1) jobList.Add(instruction[0].ToString());
            }
            _resultingSequence = String.Join("", jobList);
        }

        public SequenceImp()
        {
        }

        private string[] SplitInstructions(string instructions)
        {
            return instructions.Split('\n');
        }

        public String GetSequence()
        {
            return _resultingSequence;
        }

        public String GetSequence(string[] isAny)
        {
            throw new NotImplementedException();
        }
    }
    
}