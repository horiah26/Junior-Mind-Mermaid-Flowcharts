using System.Collections.Generic;

namespace Flowcharts
{
    public class TextSizeList
    {
        readonly List<TextSizePair> list = new List<TextSizePair> { };
        public TextSizeList()
        {
            Create();
        }

        public List<TextSizePair> GetList()
        {
            return list;
        }

        public void Create()
        {
            list.Add(TextOperations.Pair(1.4, 'a'));
            list.Add(TextOperations.Pair(2.2, 'A'));

            list.Add(TextOperations.Pair(1.5, 'b'));
            list.Add(TextOperations.Pair(2.1, 'B'));

            list.Add(TextOperations.Pair(1.4, 'c'));
            list.Add(TextOperations.Pair(2.1, 'C'));

            list.Add(TextOperations.Pair(1.6, 'd'));
            list.Add(TextOperations.Pair(2.2, 'D'));

            list.Add(TextOperations.Pair(1.4, 'e'));
            list.Add(TextOperations.Pair(1.9, 'E'));

            list.Add(TextOperations.Pair(1.2, 'f'));
            list.Add(TextOperations.Pair(1.8, 'F'));

            list.Add(TextOperations.Pair(1.5, 'g'));
            list.Add(TextOperations.Pair(2.2, 'G'));

            list.Add(TextOperations.Pair(1.5, 'h'));
            list.Add(TextOperations.Pair(2.2, 'H'));

            list.Add(TextOperations.Pair(1, 'i'));
            list.Add(TextOperations.Pair(1, 'I'));

            list.Add(TextOperations.Pair(1, 'j'));
            list.Add(TextOperations.Pair(1.3, 'J'));

            list.Add(TextOperations.Pair(1.5, 'k'));
            list.Add(TextOperations.Pair(2.2, 'K'));

            list.Add(TextOperations.Pair(1, 'l'));
            list.Add(TextOperations.Pair(1.8, 'L'));

            list.Add(TextOperations.Pair(2.3, 'm'));
            list.Add(TextOperations.Pair(2.7, 'M'));

            list.Add(TextOperations.Pair(1.5, 'n'));
            list.Add(TextOperations.Pair(2.2, 'N'));

            list.Add(TextOperations.Pair(1.6, 'o'));
            list.Add(TextOperations.Pair(2.2, 'O'));

            list.Add(TextOperations.Pair(1.6, 'p'));
            list.Add(TextOperations.Pair(2.2, 'P'));

            list.Add(TextOperations.Pair(1.5, 'q'));
            list.Add(TextOperations.Pair(2.2, 'Q'));

            list.Add(TextOperations.Pair(1.1, 'r'));
            list.Add(TextOperations.Pair(2.1, 'R'));

            list.Add(TextOperations.Pair(1.3, 's'));
            list.Add(TextOperations.Pair(1.6, 'S'));

            list.Add(TextOperations.Pair(1, 't'));
            list.Add(TextOperations.Pair(1.9, 'T'));

            list.Add(TextOperations.Pair(1.5, 'u'));
            list.Add(TextOperations.Pair(2, 'U'));

            list.Add(TextOperations.Pair(2.4, 'w'));
            list.Add(TextOperations.Pair(2.9, 'W'));

            list.Add(TextOperations.Pair(1.4, 'x'));
            list.Add(TextOperations.Pair(2.2, 'X'));

            list.Add(TextOperations.Pair(1.5, 'y'));
            list.Add(TextOperations.Pair(2.2, 'Y'));

            list.Add(TextOperations.Pair(1.3, 'z'));
            list.Add(TextOperations.Pair(1.8, 'Z'));

            list.Add(TextOperations.Pair(1.6, '0'));
            list.Add(TextOperations.Pair(1.6, '1'));
            list.Add(TextOperations.Pair(1.6, '2'));
            list.Add(TextOperations.Pair(1.6, '3'));
            list.Add(TextOperations.Pair(1.6, '4'));
            list.Add(TextOperations.Pair(1.6, '5'));
            list.Add(TextOperations.Pair(1.6, '6'));
            list.Add(TextOperations.Pair(1.6, '7'));
            list.Add(TextOperations.Pair(1.6, '8'));
            list.Add(TextOperations.Pair(1.6, '9'));

            list.Add(TextOperations.Pair(1, ' '));
            list.Add(TextOperations.Pair(2, '?'));
        }
    }
}