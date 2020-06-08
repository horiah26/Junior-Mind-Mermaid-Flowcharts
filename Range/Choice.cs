using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Range
{
    public interface IPattern
    {
        bool Match(string text);
    }

    public class Choice : IPattern
    {
        public IPattern[] Patterns;

        public Choice(params IPattern[] patterns)
        {
            this.Patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in Patterns)
            {
                if (pattern.Match(text) == false)
                {
                    return false;                    
                }
            }

            return true;
        }
    }
}
