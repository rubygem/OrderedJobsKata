using System;

namespace OrderedJobs
{
    public interface ISequence
    {
        String GetSequence(string[] instructions);
    }
}