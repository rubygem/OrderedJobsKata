using System;

namespace OrderedJobs
{
    public abstract class IJob
    {
        public String JobName;
    }

    public class Job : IJob
    {
        public Job(string instruction)
        {
            JobName = instruction[0].ToString();
        }

        public String JobName { get; set; }
    }
}