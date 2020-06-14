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
         Match match = new Match(false, "");

        public Choice(params IPattern[] patterns)
        {
            this.Patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (var pattern in Patterns)
            {
                if (pattern.Match(text).Success() == true)
                {
                    match.SetTrue();
                }
                else if (string.IsNullOrEmpty(text))
                {
                     match.SetFalse();
                     return match;                    
                }
            }

            return match;
        }
    }
}