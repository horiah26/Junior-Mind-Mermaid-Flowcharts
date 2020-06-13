using System;
using System.Collections.Generic;
using System.Text;

namespace Range
{
    class Match : IMatch
    {
        bool Validity { get; set; }
        string TexNotUsed { get; set; }

    public Match(bool isvalid, string remainingText)
        {
            Validity = isvalid;
            TexNotUsed = remainingText;
        }

        public bool IsEqual(bool that)
        {
            return Validity == that;
        }

        public void IsTrue()
        {
            Validity = true;
        }

        public void IsFalse()
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
