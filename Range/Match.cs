using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    public class Match : IMatch
    {
        bool Validity { get; set; }
        string TexNotUsed { get; set; }

        public Match(bool isvalid, string remainingText)
        {
            Validity = isvalid;
            TexNotUsed = remainingText;
        }

        public void SetRemaining(string text)
        {
            TexNotUsed = text;
        }

        public bool IsEqual(bool that)
        {
            return Validity == that;
        }

        public bool IsValid()
        {
            return Validity;
        }
        public void SetTrue()
        {
            Validity = true;
        }

        public void SetFalse()
        {
            Validity = false;
        }

        public bool Success()
        {
            return Validity;
        }

        public string RemainingText()
        {
            return TexNotUsed;
        }
    }
}
