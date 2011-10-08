using System;

namespace OrderedJobs
{
    public abstract class IJob
    {
        public String JobName;
        private Job Dependency;
    }

    public class Job : IJob
    {
        public Job(string instruction)
        {
            Name = instruction[0].ToString();
        }

        public String Name { get; set; }

        public Job Dependency { get; set; }
    }
}