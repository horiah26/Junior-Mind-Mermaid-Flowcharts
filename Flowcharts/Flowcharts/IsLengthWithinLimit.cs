using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class IsLengthWithinLimit : ITextValidator
    {
        public IsLengthWithinLimit()
        {            
        }

        public void Check(string text)
        {
            int limit = 85;

            if (text.Length > limit)
            {
                throw new ArgumentException($"Text length cannot exceed {0} characters" + limit);
            }
        }
    }
}
