using System;
using System.Collections.Generic;

namespace Instructions
{
    public interface ISequence
    {
        List<String> GetSequence(string[] instructions);
    }
}