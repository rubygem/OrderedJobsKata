using System;

namespace OrderedJobs.Tests
{
    public class Job
    {
        public Job(string instruction)
        {
            JobName = instruction[0].ToString();
        }

        public String JobName { get; set; }
    }
}