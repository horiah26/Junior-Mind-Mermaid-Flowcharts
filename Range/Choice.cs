using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Range
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }

    public interface IPattern
    {
        IMatch Match(string text);
    }

    public class Choice : IPattern
    {
        IPattern[] Patterns;
         Match saatch = new Match(true, "sasa");

        public Choice(params IPattern[] patterns)
        {
            this.Patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (var pattern in Patterns)
            {
                if (pattern.Match(text) == saatch)
                {
                    return true;                    
                }
            }
              
            return false;
        }

        IMatch IPattern.Match(string text)
        {
            return saatch;
        }
    }
}