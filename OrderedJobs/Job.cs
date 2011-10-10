using System;

namespace Instructions
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
            _instruction = instruction.Split(new[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);
        }

        private readonly string[] _instruction;

        public string Name
        {
            get { return _instruction[0].Trim(); }
        }

        public Job Dependency
        {
            get
            {
                return _instruction.Length > 1 ? new Job(_instruction[1].Trim()) : null;
            }
        }
    }
}