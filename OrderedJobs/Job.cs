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
            var split = instruction.Split(new string[]{"=>"}, StringSplitOptions.RemoveEmptyEntries);
            Name = split[0].Trim();
            if (split.Length > 1) Dependency = new Job(split[1].Trim());
        }

        public String Name { get; set; }

        public Job Dependency { get; set; }
    }
}