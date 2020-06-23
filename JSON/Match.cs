using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public class Match : IMatch
    {
        bool validity;
        string remainingText;

        public Match(bool isValid, string remainingText)
        {
            validity = isValid;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return validity;
        }

        public string RemainingText()
        {
            return remainingText;
        }
    }
}
