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
            Instruction = instruction.Split(new string[]{"=>"}, StringSplitOptions.RemoveEmptyEntries);
            Name = Instruction[0].Trim();
            if (Instruction.Length > 1) Dependency = new Job(Instruction[1].Trim());
        }

        private string[] Instruction { get; set; }

        public String Name { get; set; }

        public Job Dependency { get; set; }
    }
}