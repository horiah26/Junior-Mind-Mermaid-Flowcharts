using System;
using System.Collections.Generic;
using System.Text;

namespace Flowcharts
{
    public class TextSizePair
    {
        public double value;
        public char letter;

        public TextSizePair(double value, char letter)
        {
            this.value = value;
            this.letter = letter;
        }

        //public bool ContainsLetter(char newLetter)
        //{
        //    return letter == newLetter;
        //}
    }
}
