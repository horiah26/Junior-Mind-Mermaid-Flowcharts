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
            list.Add(new TextSizePair(1.4, 'a'));
            list.Add(new TextSizePair(2.2, 'A'));

            list.Add(new TextSizePair(1.5, 'b'));
            list.Add(new TextSizePair(2.1, 'B'));

            list.Add(new TextSizePair(1.4, 'c'));
            list.Add(new TextSizePair(2.1, 'C'));

            list.Add(new TextSizePair(1.6, 'd'));
            list.Add(new TextSizePair(2.2, 'D'));

            list.Add(new TextSizePair(1.4, 'e'));
            list.Add(new TextSizePair(1.9, 'E'));

            list.Add(new TextSizePair(1.2, 'f'));
            list.Add(new TextSizePair(1.8, 'F'));

            list.Add(new TextSizePair(1.5, 'g'));
            list.Add(new TextSizePair(2.2, 'G'));

            list.Add(new TextSizePair(1.5, 'h'));
            list.Add(new TextSizePair(2.2, 'H'));

            list.Add(new TextSizePair(1, 'i'));
            list.Add(new TextSizePair(1, 'I'));

            list.Add(new TextSizePair(1, 'j'));
            list.Add(new TextSizePair(1.3, 'J'));

            list.Add(new TextSizePair(1.5, 'k'));
            list.Add(new TextSizePair(2.2, 'K'));

            list.Add(new TextSizePair(1, 'l'));
            list.Add(new TextSizePair(1.8, 'L'));

            list.Add(new TextSizePair(2.3, 'm'));
            list.Add(new TextSizePair(2.7, 'M'));

            list.Add(new TextSizePair(1.5, 'n'));
            list.Add(new TextSizePair(2.2, 'N'));

            list.Add(new TextSizePair(1.6, 'o'));
            list.Add(new TextSizePair(2.2, 'O'));

            list.Add(new TextSizePair(1.6, 'p'));
            list.Add(new TextSizePair(2.2, 'P'));

            list.Add(new TextSizePair(1.5, 'q'));
            list.Add(new TextSizePair(2.2, 'Q'));

            list.Add(new TextSizePair(1.1, 'r'));
            list.Add(new TextSizePair(2.1, 'R'));

            list.Add(new TextSizePair(1.3, 's'));
            list.Add(new TextSizePair(1.6, 'S'));

            list.Add(new TextSizePair(1, 't'));
            list.Add(new TextSizePair(1.9, 'T'));

            list.Add(new TextSizePair(1.5, 'u'));
            list.Add(new TextSizePair(2, 'U'));

            list.Add(new TextSizePair(2.4, 'w'));
            list.Add(new TextSizePair(2.9, 'W'));

            list.Add(new TextSizePair(1.4, 'x'));
            list.Add(new TextSizePair(2.2, 'X'));

            list.Add(new TextSizePair(1.5, 'y'));
            list.Add(new TextSizePair(2.2, 'Y'));

            list.Add(new TextSizePair(1.3, 'z'));
            list.Add(new TextSizePair(1.8, 'Z'));

            list.Add(new TextSizePair(1.6, '0'));
            list.Add(new TextSizePair(1.6, '1'));
            list.Add(new TextSizePair(1.6, '2'));
            list.Add(new TextSizePair(1.6, '3'));
            list.Add(new TextSizePair(1.6, '4'));
            list.Add(new TextSizePair(1.6, '5'));
            list.Add(new TextSizePair(1.6, '6'));
            list.Add(new TextSizePair(1.6, '7'));
            list.Add(new TextSizePair(1.6, '8'));
            list.Add(new TextSizePair(1.6, '9'));

            list.Add(new TextSizePair(1, ' '));
            list.Add(new TextSizePair(2, '?'));
        }
    }
}